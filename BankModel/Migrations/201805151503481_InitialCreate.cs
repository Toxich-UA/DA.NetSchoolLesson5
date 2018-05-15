namespace BankModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ClientID = c.Int(nullable: false),
                        Country = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Address = c.String(maxLength: 120),
                    })
                .PrimaryKey(t => t.ClientID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Birthday = c.DateTime(nullable: false, storeType: "date"),
                        Phone = c.String(nullable: false, maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.ClientID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardID = c.String(nullable: false, maxLength: 16, fixedLength: true, unicode: false),
                        PinCode = c.String(nullable: false, maxLength: 4, fixedLength: true, unicode: false),
                        Ballance = c.Decimal(nullable: false, storeType: "money"),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .Index(t => t.ClientID);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        OperationID = c.Long(nullable: false, identity: true),
                        InID = c.String(nullable: false, maxLength: 16, fixedLength: true, unicode: false),
                        OutID = c.String(nullable: false, maxLength: 16, fixedLength: true, unicode: false),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        OperationTime = c.DateTime(nullable: false, defaultValueSql: "GETUTCDATE()", precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.OperationID)
                .ForeignKey("dbo.Cards", t => t.InID)
                .ForeignKey("dbo.Cards", t => t.OutID)
                .Index(t => t.InID)
                .Index(t => t.OutID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operations", "OutID", "dbo.Cards");
            DropForeignKey("dbo.Operations", "InID", "dbo.Cards");
            DropForeignKey("dbo.Cards", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Address", "ClientID", "dbo.Clients");
            DropIndex("dbo.Operations", new[] { "OutID" });
            DropIndex("dbo.Operations", new[] { "InID" });
            DropIndex("dbo.Cards", new[] { "ClientID" });
            DropIndex("dbo.Address", new[] { "ClientID" });
            DropTable("dbo.Operations");
            DropTable("dbo.Cards");
            DropTable("dbo.Clients");
            DropTable("dbo.Address");
        }
    }
}
