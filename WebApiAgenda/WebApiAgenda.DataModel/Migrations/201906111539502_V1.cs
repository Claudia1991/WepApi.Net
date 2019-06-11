namespace WebApiAgenda.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactos",
                c => new
                    {
                        IdContacto = c.Int(nullable: false, identity: true),
                        NombreContacto = c.String(maxLength: 50, unicode: false),
                        TelefonoContacto = c.Int(nullable: false),
                        MailContacto = c.String(maxLength: 50, unicode: false),
                        ApellidoContacto = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IdContacto);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contactos");
        }
    }
}
