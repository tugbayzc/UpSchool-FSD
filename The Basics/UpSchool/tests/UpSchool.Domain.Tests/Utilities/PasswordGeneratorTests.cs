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
        public void Generate_ShoulReturnPasswordWithGiven()
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
            Assert.Contains(password, x=>char.IsDigit(x));
        }

    }
}
