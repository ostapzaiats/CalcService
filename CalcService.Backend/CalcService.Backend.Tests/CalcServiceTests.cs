using CalcService.Backend.Api.Data;
using CalcService.Backend.Api.Services;

namespace CalcService.Backend.Tests;

public class CalcServiceTests
{
    [Fact]
    public void AddTwoNumbers_ShouldAddTwoNumbersWithCorrectResult()
    {
        // Arrange
        var mathService = new MathService();
        var numbers = new NumbersDto
        {
            Num1 = 5,
            Num2 = 8
        };

        // Act
        var result = mathService.AddTwoNumbers(numbers);
        
        // Assert
        Assert.Equal(13, result);
    }
}