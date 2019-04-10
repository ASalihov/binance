using Microsoft.EntityFrameworkCore;

namespace Binance.Models
{
    public class BinanceContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=666666;Database=binance");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
        public DbSet<TradeData> TradeDatas { get; set; }
    }
}