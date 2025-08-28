using Microsoft.EntityFrameworkCore;

namespace Day1.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Department> Department { get; set; }
        public ITIContext( DbContextOptions options) :base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(new Department() {Id=1,Name="SD",ManagerName="Eng/Ayman"});
            modelBuilder.Entity<Department>().HasData(new Department() {Id=2,Name="Open Source",ManagerName="Eng/Josphen" });
            modelBuilder.Entity<Department>().HasData(new Department() {Id=3,Name="Digital Marketing",ManagerName = "Eng/Mohammed" });
        }


    }
}
