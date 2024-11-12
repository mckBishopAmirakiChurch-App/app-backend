using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChurchAppBibleAPI.Data;
using ChurchAppBibleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChurchAppBibleAPI.Repositories
{
    public class BibleRepository : IBibleRepository
    {
        private readonly BibleContext _context;

        public BibleRepository(BibleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Chapters).ToListAsync();  // Added return statement and fixed property name
        }

        public async Task<Book> GetBookByNameAsync(string name)
        {
            return await _context.Books.Include(b => b.Chapters).FirstOrDefaultAsync(b => b.Name == name);  // Fixed property name
        }

        public async Task<IEnumerable<Chapter>> GetChaptersByBookAsync(string bookName)
        {
            var book = await GetBookByNameAsync(bookName);
            return book?.Chapters;
        }

        public async Task<Verse> GetVerseAsync(string bookName, int chapterNumber, int verseNumber)
        {
            var book = await _context.Books
                .Include(b => b.Chapters)
                .ThenInclude(c => c.Verses)
                .FirstOrDefaultAsync(b => b.Name == bookName);

            var chapter = book?.Chapters.FirstOrDefault(c => c.ChapterNumber == chapterNumber);
            return chapter?.Verses.FirstOrDefault(v => v.VerseNumber == verseNumber);
        }
    }
}