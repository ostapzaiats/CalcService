using CalcService.Backend.Api.Data;
using CalcService.Backend.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMathService, MathService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/add", async (HttpRequest request, IMathService mathService) =>
{
    var numbers = await request.ReadFromJsonAsync<NumbersDto>();

    if (numbers is null)
    {
        Results.BadRequest();
    }
    
    return mathService.AddTwoNumbers(numbers);
});

app.Run();