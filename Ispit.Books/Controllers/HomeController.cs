using Ispit.Books.Models;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ispit.Books.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IBooksService _booksService;
        public HomeController(IBooksService _booksService)
        {
            this._booksService = _booksService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Books()
        {
            var books = _booksService.GetBooks();
            return View(books);
        }

        public IActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(Book model)
        {
            _booksService.CreateBook(model);
            return RedirectToAction("Books");
        }

        public IActionResult Edit(int id)
        {
            var book = _booksService.GetBook(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            _booksService.EditBook(model);
            return RedirectToAction("Books");
        }

        public IActionResult Delete(int id)
        {
            _booksService.DeleteBook(id);
            return RedirectToAction("Books");
        }

        [AllowAnonymous]

        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
