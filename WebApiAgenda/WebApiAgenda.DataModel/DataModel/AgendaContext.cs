namespace WebApiAgenda.DataModel.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AgendaContext : DbContext
    {
        public AgendaContext()
            : base("AgendaDB")
        {
            //Database.CreateIfNotExists();
        }

        public virtual DbSet<ContactoEntity> Contactos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactoEntity>()
                .Property(e => e.NombreContacto)
                .IsUnicode(false);

            modelBuilder.Entity<ContactoEntity>()
                .Property(e => e.ApellidoContacto)
                .IsUnicode(false);

            modelBuilder.Entity<ContactoEntity>()
                .Property(e => e.MailContacto)
                .IsUnicode(false);
        }
    }
}
