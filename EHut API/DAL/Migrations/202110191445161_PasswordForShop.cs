﻿namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PasswordForShop : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shops", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Shops", "Password");
        }
    }
}
