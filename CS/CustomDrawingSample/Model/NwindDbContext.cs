namespace CustomDrawingSample.Model {
    using System.Data.Entity;

    public partial class NwindDbContext : DbContext {
        public NwindDbContext()
            : base("name=NwindDbContext") {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
