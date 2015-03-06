namespace RaportManager.Domian
{
    using System.Data.Entity;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Item> Item { get; set; }

        public virtual DbSet<MachineError> MachineError { get; set; }

        public virtual DbSet<Settings> Settings { get; set; }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasMany(e => e.Settings)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);
        }
    }
}