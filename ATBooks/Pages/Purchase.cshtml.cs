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
        public ShoppingCart shoppingCart { get; set; }
        public string ReturnUrl { get; set; }

        public PurchaseModel (IBookstoreRepository temp, ShoppingCart sc)
        {
            repo = temp;
            shoppingCart = sc;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            shoppingCart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove (int bookId, string returnUrl)
        {
            shoppingCart.RemoveItem(shoppingCart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
