using System.Linq;
using System.Threading.Tasks;

namespace AjaxSearch.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        Task SaveAsync(Book book);

        Task<Book> DeleteAsync(int bookId);
    }
}
