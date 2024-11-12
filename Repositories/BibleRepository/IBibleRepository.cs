using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchAppBibleAPI.Models;

namespace ChurchAppBibleAPI.Repositories
{
    public interface IBibleRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByNameAsync(string name);

        Task<IEnumerable<Chapter>> GetChaptersByBookAsync(string bookName);
        Task<Verse> GetVerserAsync(string bookName, int chapterNumber, int verseNumber);
}
