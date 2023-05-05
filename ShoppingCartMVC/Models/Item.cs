using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartMVC.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CatId   { get; set; }
        public decimal Price    { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

    }
}