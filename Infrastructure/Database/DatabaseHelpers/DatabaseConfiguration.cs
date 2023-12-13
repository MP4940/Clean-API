using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString).AddInterceptors(new CommandLoggingInterceptor()); ;
            // Additional configuration logic here
        }
    }
}