using Microsoft.EntityFrameworkCore;

namespace CalcService.Backend.Api.Data;

public class CalculationDbContext : DbContext
{
    public CalculationDbContext(DbContextOptions<CalculationDbContext> options) : base(options)
    {
    }

    public DbSet<Numbers> Numbers { get; set; }
}