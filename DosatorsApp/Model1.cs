namespace DosatorsApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<dosators> dosators { get; set; }
        public virtual DbSet<norma> norma { get; set; }
        public virtual DbSet<result> result { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dosators>()
                .Property(e => e.canal)
                .IsFixedLength();

            modelBuilder.Entity<dosators>()
                .HasMany(e => e.norma)
                .WithRequired(e => e.dosators)
                .HasForeignKey(e => e.codeDos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<dosators>()
                .HasMany(e => e.result)
                .WithRequired(e => e.dosators)
                .HasForeignKey(e => e.codeDos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<result>()
                .Property(e => e.operators)
                .IsFixedLength();
        }
    }
}
