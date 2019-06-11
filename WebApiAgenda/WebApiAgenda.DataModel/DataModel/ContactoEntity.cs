namespace WebApiAgenda.DataModel.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contactos")]
    public partial class ContactoEntity
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContacto { get; set; }

        [Column(Order = 1)]
        [StringLength(50)]
        public string NombreContacto { get; set; }

        [StringLength(50)]
        public string ApellidoContacto { get; set; }

        [Column(Order = 2)]
        public int TelefonoContacto { get; set; }

        [Column(Order = 3)]
        [StringLength(50)]
        public string MailContacto { get; set; }
    }
}
