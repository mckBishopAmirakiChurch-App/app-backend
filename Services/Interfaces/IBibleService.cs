using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchAppBibleAPI.Models;



namespace ChurchAppBibleAPI.Services.Interfaces
{
    public interface IBibleService
    {
        Task <IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByNameAsync(string name);
        Task<IEnumerable<Chapter>> GetChaptersByBookAsync(string bookName);

        Task<Verse> GetVerseAsync(string bookName, int chapterNumber, int verseNumber);

    }
    }