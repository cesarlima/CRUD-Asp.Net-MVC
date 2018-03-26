namespace ExemploArquitetura.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                        StateCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.State", t => t.StateCode)
                .Index(t => t.StateCode);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Initials = c.String(nullable: false, maxLength: 2, unicode: false),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60, unicode: false),
                        Lastname = c.String(nullable: false, maxLength: 60, unicode: false),
                        CPF = c.String(nullable: false, maxLength: 16, unicode: false),
                        address = c.Guid(nullable: false),
                        contact = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.address)
                .ForeignKey("dbo.Contact", t => t.contact)
                .Index(t => t.address)
                .Index(t => t.contact);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Street = c.String(nullable: false, maxLength: 60, unicode: false),
                        Number = c.String(nullable: false, maxLength: 10, unicode: false),
                        ZipCode = c.String(nullable: false, maxLength: 15, unicode: false),
                        city = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.city)
                .Index(t => t.city);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Phone = c.String(maxLength: 20, unicode: false),
                        CellPhone = c.String(maxLength: 20, unicode: false),
                        Email = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "contact", "dbo.Contact");
            DropForeignKey("dbo.Customer", "address", "dbo.Address");
            DropForeignKey("dbo.Address", "city", "dbo.City");
            DropForeignKey("dbo.City", "StateCode", "dbo.State");
            DropIndex("dbo.Address", new[] { "city" });
            DropIndex("dbo.Customer", new[] { "contact" });
            DropIndex("dbo.Customer", new[] { "address" });
            DropIndex("dbo.City", new[] { "StateCode" });
            DropTable("dbo.Contact");
            DropTable("dbo.Address");
            DropTable("dbo.Customer");
            DropTable("dbo.State");
            DropTable("dbo.City");
        }
    }
}
