namespace ClothesShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CartDetail",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CartId = c.String(maxLength: 128),
                        VariantSizeId = c.String(maxLength: 128),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cart", t => t.CartId)
                .ForeignKey("dbo.VariantSize", t => t.VariantSizeId)
                .Index(t => t.CartId)
                .Index(t => t.VariantSizeId);
            
            CreateTable(
                "dbo.VariantSize",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductVariantId = c.String(maxLength: 128),
                        SizeId = c.String(maxLength: 128),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductVariant", t => t.ProductVariantId)
                .ForeignKey("dbo.Size", t => t.SizeId)
                .Index(t => t.ProductVariantId)
                .Index(t => t.SizeId);
            
            CreateTable(
                "dbo.ProductVariant",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductId = c.String(maxLength: 128),
                        ColorId = c.String(maxLength: 128),
                        IsDefault = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Color", t => t.ColorId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.ColorId);
            
            CreateTable(
                "dbo.Color",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Alias = c.String(maxLength: 50),
                        Code = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageList",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ProductVariantId = c.String(maxLength: 128),
                        IsDefault = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductVariant", t => t.ProductVariantId)
                .Index(t => t.ProductVariantId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 250),
                        Alias = c.String(),
                        Description = c.String(),
                        ProductCode = c.String(nullable: false, maxLength: 250),
                        Detail = c.String(),
                        Price = c.Int(nullable: false),
                        PriceSale = c.Int(nullable: false),
                        IsHome = c.Boolean(nullable: false),
                        IsSale = c.Boolean(nullable: false),
                        IsFeature = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        ProductCategoryId = c.String(maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.ProductCategoryId)
                .Index(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdParent = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(maxLength: 150),
                        Description = c.String(maxLength: 2000),
                        Level = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategory", t => t.IdParent)
                .Index(t => t.IdParent);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 10),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Address = c.String(),
                        Phone = c.String(),
                        IsPaid = c.Boolean(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                        PaymentMethodId = c.String(maxLength: 128),
                        OrderedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentMethod", t => t.PaymentMethodId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.PaymentMethodId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderId = c.String(maxLength: 128),
                        VariantSizeId = c.String(maxLength: 128),
                        Price = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.VariantSize", t => t.VariantSizeId)
                .Index(t => t.OrderId)
                .Index(t => t.VariantSizeId);
            
            CreateTable(
                "dbo.PaymentMethod",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rate",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        ProductVariantId = c.String(maxLength: 128),
                        RateValue = c.Single(nullable: false),
                        Comment = c.String(maxLength: 1000),
                        RatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductVariant", t => t.ProductVariantId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductVariantId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(),
                        Description = c.String(),
                        Detail = c.String(),
                        ViewCount = c.Int(nullable: false),
                        Image = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedUserId = c.String(maxLength: 128),
                        ModifiedUserId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ModifiedUserId)
                .Index(t => t.CreatedUserId)
                .Index(t => t.ModifiedUserId);
            
            CreateTable(
                "dbo.Parameter",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 100),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.News", "ModifiedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.News", "CreatedUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rate", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rate", "ProductVariantId", "dbo.ProductVariant");
            DropForeignKey("dbo.Order", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Order", "PaymentMethodId", "dbo.PaymentMethod");
            DropForeignKey("dbo.OrderDetail", "VariantSizeId", "dbo.VariantSize");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Cart", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CartDetail", "VariantSizeId", "dbo.VariantSize");
            DropForeignKey("dbo.VariantSize", "SizeId", "dbo.Size");
            DropForeignKey("dbo.VariantSize", "ProductVariantId", "dbo.ProductVariant");
            DropForeignKey("dbo.ProductVariant", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "ProductCategoryId", "dbo.ProductCategory");
            DropForeignKey("dbo.ProductCategory", "IdParent", "dbo.ProductCategory");
            DropForeignKey("dbo.ImageList", "ProductVariantId", "dbo.ProductVariant");
            DropForeignKey("dbo.ProductVariant", "ColorId", "dbo.Color");
            DropForeignKey("dbo.CartDetail", "CartId", "dbo.Cart");
            DropForeignKey("dbo.Address", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.News", new[] { "ModifiedUserId" });
            DropIndex("dbo.News", new[] { "CreatedUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Rate", new[] { "ProductVariantId" });
            DropIndex("dbo.Rate", new[] { "UserId" });
            DropIndex("dbo.OrderDetail", new[] { "VariantSizeId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "PaymentMethodId" });
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.ProductCategory", new[] { "IdParent" });
            DropIndex("dbo.Product", new[] { "ProductCategoryId" });
            DropIndex("dbo.ImageList", new[] { "ProductVariantId" });
            DropIndex("dbo.ProductVariant", new[] { "ColorId" });
            DropIndex("dbo.ProductVariant", new[] { "ProductId" });
            DropIndex("dbo.VariantSize", new[] { "SizeId" });
            DropIndex("dbo.VariantSize", new[] { "ProductVariantId" });
            DropIndex("dbo.CartDetail", new[] { "VariantSizeId" });
            DropIndex("dbo.CartDetail", new[] { "CartId" });
            DropIndex("dbo.Cart", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Address", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Parameter");
            DropTable("dbo.News");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Rate");
            DropTable("dbo.PaymentMethod");
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Size");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.ImageList");
            DropTable("dbo.Color");
            DropTable("dbo.ProductVariant");
            DropTable("dbo.VariantSize");
            DropTable("dbo.CartDetail");
            DropTable("dbo.Cart");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Address");
        }
    }
}
