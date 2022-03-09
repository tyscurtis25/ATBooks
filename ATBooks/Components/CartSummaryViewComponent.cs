using Microsoft.AspNetCore.Mvc;
using ATBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBooks.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ShoppingCart cart;
        public CartSummaryViewComponent(ShoppingCart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
