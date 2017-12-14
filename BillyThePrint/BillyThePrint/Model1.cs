namespace BillyThePrint
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

        public virtual DbSet<producto> producto { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<producto>()
                .HasMany(e => e.usuario)
                .WithOptional(e => e.producto)
                .HasForeignKey(e => e.id_pro);

            modelBuilder.Entity<usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.apellido)
                .IsUnicode(false);
        }
    }
}
