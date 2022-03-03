using Microsoft.AspNetCore.Mvc;
using ATBooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBooks.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository repo { get; set; }
        private ShoppingCart shoppingCart { get; set; }

        public PurchaseController(IPurchaseRepository temp, ShoppingCart sc)
        {
            repo = temp;
            shoppingCart = sc;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (shoppingCart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = shoppingCart.Items.ToArray();
                repo.SavePurchase(purchase);
                shoppingCart.ClearShoppingCart();

                return RedirectToPage("/PurchaseConfirmation");
            }

            else
            {
                return View();
            }
        }
    }
}
