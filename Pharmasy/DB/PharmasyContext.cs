using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace Pharmasy.DB
{
    public class PharmasyContext : DbContext
    {
        public PharmasyContext() : base("DBConnection")
        {
            Database.SetInitializer( new DropCreateDatabaseIfModelChanges<PharmasyContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>()
                .HasMany<Medicament>(x => x.HasContraindications)
                .WithMany(x => x.ContraindicationTo)
                .Map(x =>
                    {
                        x.MapLeftKey("MedicationId");
                        x.MapRightKey("ContraindicationId");
                        x.ToTable("MedicationContradiction");
                    }
                );
        }
    }
}
