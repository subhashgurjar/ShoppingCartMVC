﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCartMVC.Models
{
    public class CartItem
    {
        [Key]
        public string CartItemId { get; set; }
        public int ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public virtual Item Item { get; set; }


    }
}