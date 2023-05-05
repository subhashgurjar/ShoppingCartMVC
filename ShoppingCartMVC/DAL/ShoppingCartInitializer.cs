using ShoppingCartMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace ShoppingCartMVC.DAL
{
    public class ShoppingCartInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ShoppingCartContext>
    {
        protected override void Seed(ShoppingCartContext context)
        {
            var items = new List<Item>
            {
            new Item{ItemName="Samsung", CatId=1, Description="qwertyuoi", ImagePath="https://m.media-amazon.com/images/I/71J8tz0UeJL._SX679_.jpg", Price=14999},
            new Item{ItemName="Nokia", CatId=1, Description="qwertyuoi", ImagePath="https://m.media-amazon.com/images/I/61tmePx9zzL._SL1500_.jpg", Price=15999},
            new Item{ItemName="LG", CatId=2, Description="qwertyuoi", ImagePath="https://www.lg.com/in/images/tvs/md07554739/gallery/43UQ7550PSF-D-02.jpg", Price=16999},
            new Item{ItemName="Videocon", CatId=2, Description="qwertyuoi", ImagePath="https://www.price-hunt.com/content/images/tv/videocon-50-8-cm-vjy-20-hh-hd-ready-led-tv_l.jpeg", Price=17999},
            new Item{ItemName="Apple MAC", CatId=3, Description="qwertyuoi", ImagePath="https://4.imimg.com/data4/SJ/BA/MY-3018414/apple-laptop-500x500.jpg", Price=18999},
            new Item{ItemName="Lenovo", CatId=3, Description="qwertyuoi", ImagePath="https://www.lenovo.com/medias/lenovo-laptops-ideapad-3i-gen-7-14-intel-hero.png?context=bWFzdGVyfHJvb3R8NDYyOTU3fGltYWdlL3BuZ3xoNWYvaGE3LzE0NjgzNTMyNzU0OTc0LnBuZ3w1OGQ0OTIwN2YwNjQ0MjMxZjAzYmNiNDBiOWY2ZWVlZGZiNGJlMTYwZTk5NzI5ZTM4M2M0YzI2N2I1OTI0NTQ5", Price=19999}
            };

            items.ForEach(s => context.Items.Add(s));
            context.SaveChanges();
            var categories = new List<Category>
            {
            new Category{Id=1, CatName="Mobile"},
            new Category{Id=2,CatName="TV"},
            new Category{Id=3,CatName="Laptop"},

            };
            categories.ForEach(s => context.Categories.Add(s));
            context.SaveChanges();
          
        }
    }
}