using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=666666;Database=binance");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}