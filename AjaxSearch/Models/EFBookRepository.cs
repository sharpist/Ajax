using System.Linq;
using System.Threading.Tasks;

namespace AjaxSearch.Models
{
    public class EFBookRepository : IBookRepository
    {
        private AppDbContext context;
        public EFBookRepository(AppDbContext context) =>
            this.context = context;

        public IQueryable<Book> Books => context.Books;

        public async Task SaveAsync(Book book)
        {
            if (book.Id == 0) context.Books.Add(book);
            else {
                Book dbEntry = context.Books.FirstOrDefault(
                    b => b.Id == book.Id);

                if (dbEntry != null) {
                    dbEntry.Name = book.Name;
                    dbEntry.Author = book.Author;
                    dbEntry.Price = book.Price;
                }
            }
            await context.SaveChangesAsync();
        }

        public async Task<Book> DeleteAsync(int bookId)
        {
            Book dbEntry = context.Books.FirstOrDefault(
                b => b.Id == bookId);

            if (dbEntry != null) {
                context.Books.Remove(dbEntry);
                await context.SaveChangesAsync();
            }
            return dbEntry;
        }
    }
}
