using FakeItEasy;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Utilities;

namespace UpSchool.Domain.Tests.Utilities
{
    public class PasswordGeneratorTests
    {
        [Fact]
        public void Generate_ShoulReturnEmptyString_WhenNoCharactersAreIncluded()
        {
            //Arrange
            var passwordGenerator = new PasswordGenerator();

            var generatePasswordDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeLowercaseCharacters = false,
                IncludeNumbers = false,
                IncludeSpecialCharacters = false,
                IncludeUppercaseCharacters = false,
            };


            //Act
            var password = passwordGenerator.Generate(generatePasswordDto);

            //Assert
            Assert.Equal(string.Empty, password);
        }

        [Fact]
        public void Generate_ShoulReturnPasswordWithGivenLenght()
        {

            var ipHelper = A.Fake<IIPHelper>();

            A.CallTo(() => ipHelper.GetCurrentIPAddress()).Returns("195.142.70.227");

            var localDbMock = A.Fake<ILocalDB>();

            A.CallTo(() => localDbMock.IPs).Returns(new List<string>()
            {
                "192.168.1.11",
                "180.22.22.22",
                "155.166.177.188"
            });

            //var localDB = new LocalDB();

            //Arrange
            var passwordGenerator = new PasswordGenerator(ipHelper, localDbMock);

            var generatePasswordDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeLowercaseCharacters = true,
                IncludeNumbers = false,
                IncludeSpecialCharacters = true,
                IncludeUppercaseCharacters = false,
            };


            //Act
            var password = passwordGenerator.Generate(generatePasswordDto);

            //Assert
            Assert.Equal(generatePasswordDto.Length, password.Length);
        }

        [Fact]
        public void Generate_ShoulIncludeNumbers_WhenIncludeNumbersIsTrue()
        {
            //Arrange
            var passwordGenerator = new PasswordGenerator();

            var generatePasswordDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeLowercaseCharacters = true,
                IncludeNumbers = false,
                IncludeSpecialCharacters = true,
                IncludeUppercaseCharacters = false,
            };


            //Act
            var password = passwordGenerator.Generate(generatePasswordDto);

            //Assert
            Assert.Contains(password, x => char.IsDigit(x));

            //Bu şekilde de yazılabilir ama contains daha mantıklı!^
            //Assert.True(password.Any(x=>char.IsDigit(x)),password);
        }


        [Fact]
        public void Generate_ShouldIncludeSpecialCharacters_WhenSpecialCharactersIsTrue()
        {

            // Arrange

            var passwordGenerator = new PasswordGenerator();

            var generatePassworDto = new GeneratePasswordDto()
            {
                Length = 20,
                IncludeNumbers = true,
                IncludeLowercaseCharacters = true,
                IncludeUppercaseCharacters = true,
                IncludeSpecialCharacters = true,
            };

            var specialCharacters = "!@#$%^&*()";

            // Act
            var password = passwordGenerator.Generate(generatePassworDto);


            // Assert
            Assert.Contains(password, x => specialCharacters.Contains(x));
            //linq kullanarak contaiins metoduyla en doğru sonucu alıyoruz!

        }


    }
}

