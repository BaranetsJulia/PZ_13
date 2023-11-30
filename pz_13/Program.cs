using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_13
{
    internal class Income : DbContext
    {
        public DbSet<Income> Income => Set<Income>();
        public DbSet<Outcome> Outcome => Set<Outcome>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer((new SqlConnectionStringBuilder() { DataSource = "192.168.147.50\\MSSQL2", InitialCatalog = "inc_out", UserID = "pk", Password = "1", TrustServerCertificate = true }).ConnectionString);

        }
    }
}
