using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartMVC.Models
{
    internal interface ISearchRepository
    {
         IEnumerable<Item> Search(string searchtext);
    }
}
