using API.Models.Auth;
using API.Models.Employee;
using API.Models.Inventory;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        /////////////////////: Auth ://///////////////////
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }

        /////////////////////: Employee ://///////////////////
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EmployeeDetails> employeeDetails {  get; set; }
        public virtual DbSet<Position> positions { get; set; }
                
        
        /////////////////////: Inventory ://///////////////////
        public virtual DbSet<Accessories> Accessories { get; set; }
        public virtual DbSet<LaptopAndDesktop> LaptopAndDesktops { get; set; }
        public virtual DbSet<PurchaseDetails> PurchaseDetails { get; set; }
        public virtual DbSet<ReplacedHardware> ReplacedHardwares { get; set; }
        public virtual DbSet<SupplierVendor> SupplierVendors { get; set; }

        /////////////////////: Common ://///////////////////
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<ProbleSolution> ProblemSolutions { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EmployeeDetails>()
                .HasOne(e => e.employeeDetails)
                .WithMany()
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
