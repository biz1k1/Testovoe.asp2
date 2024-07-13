using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<RecordEntity> Record { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RecordConfiguration());
        }
    }
}
