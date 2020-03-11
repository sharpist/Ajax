using AjaxSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxSearch.Controllers
{
    public class MainController : Controller
    {
        private readonly IBookRepository repository;
        public MainController(IBookRepository repository) =>
            this.repository = repository;


        [HttpGet]
        public async Task<IActionResult> Search() =>
            View(await repository.Books.Select(b => b.Author).Distinct().ToListAsync());
        [HttpPost]
        public async Task<IActionResult> Search(string name)
        {
            var allbooks = await repository.Books.Where(
                b => b.Author.Contains(name)).ToListAsync();

            if (allbooks.Count <= 0)
                return new NotFoundResult();
            return PartialView("_PartialSearch", allbooks);
        }


        [HttpGet]
        public async Task<IActionResult> CreateOrUpdate(int bookId = 0)
        {
            if (bookId == 0)
                return View(new Book());
            return View(await repository.Books.FirstOrDefaultAsync(b => b.Id == bookId));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrUpdate([Bind("Id,Name,Author,Price")] Book book)
        {
            if (ModelState.IsValid) {
                await repository.SaveAsync(book);
                TempData["message"] = $"книга \"{book.Name}\" была сохранена";
                return RedirectToAction(nameof(Search));
            }
            return View(book);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int bookId)
        {
            var deletedBook = await repository.DeleteAsync(bookId);
            if (deletedBook != null)
                TempData["message"] = $"книга \"{deletedBook.Name}\" была удалена";
            return RedirectToAction(nameof(Search));
        }
    }
}
