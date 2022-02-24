using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATBooks.Infrastructure;
using ATBooks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATBooks.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public PurchaseModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public ShoppingCart shoppingCart { get; set; }

        public void OnGet()
        {
            shoppingCart = HttpContext.Session.GetJson<ShoppingCart>("shoppingCart") ?? new ShoppingCart();
        }
        public IActionResult OnPost(int bookId)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            shoppingCart = HttpContext.Session.GetJson<ShoppingCart>("shoppingCart") ?? new ShoppingCart();
            shoppingCart.AddItem(b, 1);

            HttpContext.Session.SetJson("shoppingCart", shoppingCart);

            return RedirectToPage();
        }
    }
}
