using Application.Common.Helpers;

namespace Application.UnitTests.Common.Helpers;

public class MathHelperTests
{
    [Fact]
    public void IsEven_Returns_True()
    {
        //Arrange
        var mathHelper = new MathHelper();

        int evenNumber = 52;
        int secondEvenNumber = 6;

        //Act
        var result = mathHelper.IsEven(evenNumber);
        var secondResult = mathHelper.IsEven(secondEvenNumber);

        //Assert
        Assert.True(result);
        Assert.True(secondResult);
    }
    
    [Fact]
    public void IsEven_Returns_False()
    {
        //Arrange
        var mathHelper = new MathHelper();

        int oddNumber = 51;
        int secondOddNumber = 11;

        //Act
        var result = mathHelper.IsEven(oddNumber);
        var secondResult = mathHelper.IsEven(secondOddNumber);

        //Assert
        Assert.False(result);
        Assert.False(secondResult);
    }
}