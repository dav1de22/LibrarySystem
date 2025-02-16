using LibrarySystem.Data;
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;


namespace LibrarySystem.Services


{
    public class BookService
    {
        private readonly LibraryContext _context;

        public BookService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksAsync(int page, int pageSize)
        {
            return await _context.Books
                .Skip((page -1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Book> addBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;

            
        }
    }
}
