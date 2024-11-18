using Microsoft.EntityFrameworkCore;
using NLogBasics.Models;

namespace NLogBasics.Database;

public sealed class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-9ER5GSE\\SQLEXPRESS;Initial Catalog=NLogBasicsDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }

    public DbSet<Log> Logs { get; set; }
}
