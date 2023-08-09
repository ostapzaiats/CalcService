using CalcService.Backend.Api.Data;

namespace CalcService.Backend.Api.Services;

public interface IMathService
{
    int AddTwoNumbers(NumbersDto numbers);
}