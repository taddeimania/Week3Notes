namespace Day4EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedvirtualaccesortoorderitem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            RenameColumn(table: "dbo.OrderItems", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.OrderItems", name: "Item_Id", newName: "Inventory_Id");
            RenameIndex(table: "dbo.OrderItems", name: "IX_Item_Id", newName: "IX_Inventory_Id");
            AddColumn("dbo.OrderItems", "ItemId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int());
            DropColumn("dbo.OrderItems", "ItemId");
            RenameIndex(table: "dbo.OrderItems", name: "IX_Inventory_Id", newName: "IX_Item_Id");
            RenameColumn(table: "dbo.OrderItems", name: "Inventory_Id", newName: "Item_Id");
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
