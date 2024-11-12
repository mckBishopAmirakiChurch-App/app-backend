using Sysytem.Collections.Generic;
using System.linq;
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
            await _context.Books.Include(b => b.Chapter).ToListAsync();
        }



        public async Task<Book> GetBookByNameAsync(string name)
        {
            return await _context.Books.Include(b => b.Chapter).FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<IEnumerable<Chapter>> GetChaptersByBookAsync(string bookName)
        {
            var book = await GetBookByNameAsync(bookName);
            return book?.Chapters;
        }



        public async Task<Verse> GetVerseAsync(string bookName, int chapterNumber, int verseNumber)
        {
            var book = await _context.Books.Include(b => b.Chapters).ThenInclude(c => c.Verses).FirstOrDefaultAsync(b => b.Name == bookName);

            var chapter = book?.Chapters.FirstOrDefault(c => c.ChapterNumber == chapterNumber);
            return chapter?.Verses.FirstOrDefault(v => v.VerseNumber == verseNumber);
        }
    }
}