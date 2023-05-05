using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShoppingCartMVC.Models;

namespace ShoppingCartMVC.DAL
{
    public class ShoppingCartContext : DbContext
    {

        public ShoppingCartContext() : base("name=ShoppingCartContext")
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public System.Data.Entity.DbSet<ShoppingCartMVC.Models.Checkout> Checkouts { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }

}