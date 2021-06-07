using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L_DataAccess.DataContext
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            // Get our connection string - VIA AppConfiguration Class
            AppConfiguration Settings = new AppConfiguration();
            // Init A new options builder so we can tell it what information it must use when connecting the the db
            DbContextOptionsBuilder<DatabaseContext> OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            // Tell the options builder what type of database its connecting to and which connection string it must use
            OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
            // We return a new instance of the database context with the all required db connection info
            // So it can then be used to do a db migrations.
            return new DatabaseContext(OptionsBuilder.Options);
        }
    }
}
