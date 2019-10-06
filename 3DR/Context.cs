using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DR
{
    class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
        }

        public virtual DbSet<rf3m2asat> Rf3s { get; set; }
        public virtual DbSet<abtda2yArkam> Abtda2YArkams { get; set; }
        public virtual DbSet<abtda2yAcces> Abtda2YAcces { get; set; }
        public virtual DbSet<ArkamM2bd> ArkamM2Bds { get; set; }
        public virtual DbSet<abtda2y> Abtda2s { get; set; }
        public virtual DbSet<Nha2y> Nha2s { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<dolfColor> DolfColors { get; set; }
        public virtual DbSet<Accesories> Accesories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dolfColor>()
                .HasOptional<Product>(s => s.Product)
                .WithMany()
                .WillCascadeOnDelete(false);
        }

    }
}
