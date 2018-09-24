namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Product_category_id = c.Int(nullable: false, identity: true),
                        Category_name = c.String(),
                    })
                .PrimaryKey(t => t.Product_category_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Product_id = c.Int(nullable: false, identity: true),
                        Product_Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Offer = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mfg_date = c.DateTime(nullable: false),
                        Expiry_date = c.DateTime(nullable: false),
                        Best_before_months = c.Int(nullable: false),
                        Product_category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Product_id)
                .ForeignKey("dbo.ProductCategories", t => t.Product_category_id, cascadeDelete: true)
                .Index(t => t.Product_category_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Product_category_id", "dbo.ProductCategories");
            DropIndex("dbo.Products", new[] { "Product_category_id" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
