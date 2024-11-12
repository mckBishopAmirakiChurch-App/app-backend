using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChurchAppBibleAPI.Models;
using ChurchAppBibleAPI.Services.Interfaces;

namespace ChurchAppBibleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibleController : ControllerBase
    {
        private readonly IBibleService _bibleService;

        public BibleController(IBibleService bibleService)
        {
            _bibleService = bibleService;
        }

        [HttpGet("books")]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksAsync() =>
            Ok(await _bibleService.GetAllBooksAsync());

        [HttpGet("book/{name}")]
        public async Task<ActionResult<Book>> GetBookByName(string name) =>
            Ok(await _bibleService.GetBookByNameAsync(name));

        [HttpGet("book/{bookName}/chapters")]
        public async Task<ActionResult<IEnumerable<Chapter>>> GetChaptersByBook(string bookName) =>
            Ok(await _bibleService.GetChaptersByBookAsync(bookName));  // Changed 'name' to 'bookName'

        [HttpGet("book/{bookName}/chapter/{chapterNumber}/verse/{verseNumber}")]
        public async Task<ActionResult<Verse>> GetVerse(string bookName, int chapterNumber, int verseNumber) =>
            Ok(await _bibleService.GetVerseAsync(bookName, chapterNumber, verseNumber));
    }
}