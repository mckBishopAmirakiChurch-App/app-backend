// Services/BibleService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchAppBibleAPI.Models;
using ChurchAppBibleAPI.Repositories;
using ChurchAppBibleAPI.Services.Interfaces;

namespace ChurchAppBibleAPI.Services
{
    public class BibleService : IBibleService
    {
        private readonly IBibleRepository _bibleRepository;

        public BibleService(IBibleRepository bibleRepository)
        {
            _bibleRepository = bibleRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync() => await _bibleRepository.GetAllBooksAsync();

        public async Task<Book> GetBookByNameAsync(string name) => await _bibleRepository.GetBookByNameAsync(name);

        public async Task<IEnumerable<Chapter>> GetChaptersByBookAsync(string bookName) => await _bibleRepository.GetChaptersByBookAsync(bookName);

        public async Task<Verse> GetVerseAsync(string bookName, int chapterNumber, int verseNumber) =>
            await _bibleRepository.GetVerseAsync(bookName, chapterNumber, verseNumber);
    }
}
