namespace DAL
{
    using Microsoft.EntityFrameworkCore;
    using BusinessLogic;

    public class ApplicationContext : DbContext
    {
        public DbSet<Pad> Pads { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;UserId=root;Password=123456;database=tinky1;");
        }
    }
}
