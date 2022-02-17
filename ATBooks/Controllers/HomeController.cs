using ATBooks.Models;
using ATBooks.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATBooks.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 5;

            //var x = new BooksViewModel
            //{
            //    Books = repo.Books
            //    .OrderBy(b => b.Title)
            //    .Skip((pageNum - 1) * pageSize)
            //    .Take(pageSize),

            //    PageInfo = new PageInfo
            //    {
            //        TotalNumBooks = repo.Books.Count(),
            //        BooksPerPage = pageSize,
            //        CurrentPage = pageNum
            //    }
            //};

            var book = repo.Books
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize);

            return View(book);
        }
    }
}
