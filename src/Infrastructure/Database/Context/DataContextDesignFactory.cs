using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace Infrastructure.Database.Context
{
    public class DataContextDesignFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            string localPath = Directory.GetCurrentDirectory();
            string connectionString = $@"Server=.\SQLExpress;AttachDbFilename={localPath}\LocalDatabase.mdf;Database=CustomerPrj;Trusted_Connection=Yes;";

            var optionBuilder = new DbContextOptionsBuilder<DataContext>()
                                    .UseSqlServer(connectionString);

            return new DataContext(optionBuilder.Options);
        }
    }
}
