using CalcService.Backend.Api.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapPost("/add", async (HttpRequest request) =>
{
    var numbers = await request.ReadFromJsonAsync<NumbersDto>();

    if (numbers is null)
    {
        Results.BadRequest();
    }
    
    return numbers.Num1 + numbers.Num2;
});

app.Run();