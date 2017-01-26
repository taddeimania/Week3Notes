namespace Day4EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Item_Id = c.Int(),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventories", t => t.Item_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Discount = c.Double(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.Inventories");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.Inventories");
            DropTable("dbo.Customers");
        }
    }
}
