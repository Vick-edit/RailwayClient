using Microsoft.EntityFrameworkCore;
using RailwayClient.DataAccess.Entities;

namespace RailwayClient.DataAccess.SettingsEF
{
    public class RailwayContext : DbContext, IUnitOfWork
    {
        public DbSet<Railway> Railways { get; set; }
        public DbSet<Station> Stations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=.\RailwayDB.db");
        }


        /// <inheritdoc />
        public void Commit()
        {
            SaveChanges(true);
        }
    }
}