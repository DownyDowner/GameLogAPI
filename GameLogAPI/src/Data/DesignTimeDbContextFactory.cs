using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace GameLogAPI.src.Data {
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GameDbContext> {
        public GameDbContext CreateDbContext(string[] args) {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<GameDbContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new GameDbContext(optionsBuilder.Options);
        }
    }
}
