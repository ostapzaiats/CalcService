using CalcService.Backend.Api.Data;

namespace CalcService.Backend.Api.Services;

public class MathService : IMathService
{
    public int AddTwoNumbers(NumbersDto numbers)
    {
        return numbers.Num1 + numbers.Num2;
    }
}