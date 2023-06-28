using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual  DbSet<Todo> todos { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);


        }
    }
}
