using ShoppingCartMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartMVC.Models
{
    public class SearchRepository : ISearchRepository
    {
        ShoppingCartContext db = new ShoppingCartContext();

        public IEnumerable<Item> Search(string searchtext)
        {
            var items = db.Items.ToList();
            if (!String.IsNullOrEmpty(searchtext))
            {
                items = items.Where(c => c.ItemName.Contains(searchtext)).ToList();
            }
            return items;
        }

    }
}