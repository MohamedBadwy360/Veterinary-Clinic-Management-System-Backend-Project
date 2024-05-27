using VCMS.Core.Utilities;

namespace VCMS.UnitTests.VCMSCoreTests.UtilitiesTests;

public class StringValidationTests
{
    [Theory]
    [InlineData("Mohamed", true)]
    [InlineData("Mohamed Badwy", true)]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData("   ", false)]
    [InlineData("Moh+-amed", false)]
    [InlineData("Mohamed32", false)]
    [InlineData("$%Mohamed", false)]
    [InlineData("Mohamed.?", false)]
    [InlineData("12345", false)]
    public void IsAllLetters_CheckIfAllStringIsOnlyLetters_ReturnsTrueOrFalse(string str, bool expected)
    {
        // Arrange
        // Act
        var actual = StringValidations.IsAllLetters(str);
        // Assert
        Assert.True(expected == actual);
    }


    [Theory]
    [InlineData("01553414588", true)]
    [InlineData("+201553414588", true)]
    [InlineData("+2015534145888888888", false)]
    [InlineData("+20155341458?", false)]
    [InlineData("+20155m341458", false)]
    [InlineData("+20155%$341458", false)]
    [InlineData("    ", false)]
    [InlineData("", false)]
    [InlineData(null, false)]
    [InlineData("12354", false)]
    [InlineData("hi", false)]
    public void IsPhoneNumber_CheckIfCorrectPhoneNumber_ReturnsTrueOrFalse(string str, bool expected)
    {
        // Arrange
        // Act
        var actual = StringValidations.IsPhoneNumber(str);

        // Assert
        Assert.True(actual == expected);
    }
}
