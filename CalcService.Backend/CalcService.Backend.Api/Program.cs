using CalcService.Backend.Api.Data;
using CalcService.Backend.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IMathService, MathService>();

var connectionString = builder.Configuration.GetConnectionString("CalculationDbConnectionString");

builder.Services.AddDbContext<CalculationDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<CalculationDbContext>();
db?.Database.MigrateAsync();

app.MapGet("/", () => "Hello World!");
app.MapPost("/add", async (HttpRequest request, IMathService mathService, CalculationDbContext db) =>
{
    var numbers = await request.ReadFromJsonAsync<NumbersDto>();

    if (numbers is null)
    {
        Results.BadRequest();
    }

    var entity = new Numbers
    {
        Num1 = numbers.Num1,
        Num2 = numbers.Num2
    };

    await db.Numbers.AddAsync(entity);
    await db.SaveChangesAsync();

    return Results.Ok(mathService.AddTwoNumbers(numbers));
});

app.Run();