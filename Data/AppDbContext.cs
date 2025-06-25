using Microsoft.EntityFrameworkCore;
namespace projCrud.Data;

using projCrud.Models;

public class AppDbContext : DbContext
{
    public DbSet<Center> Center { get; set; }
    public DbSet<Donor> Donors { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
