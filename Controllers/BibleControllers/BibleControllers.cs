using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


public class BibleVerseService
{
    private readonly HttpClient _client;
    private const string RapidApiKey = "21871ac1c2msha17cca7bcfab529p1f0ad7jsn414c175d33ce";
    private const string RapidApiHost = "niv-bible.p.rapidapi.com";



    public BibleVerseService(HttpClient httpClient)
    {
        _client = httpClient;
        _client.DefaultRequestHeaders.Add("X-RapidAPI-Key", RapidApiKey);
        _client.DefaultRequestHeaders.Add("X-RapidAPI-Host", RapidApiHost);
    }


    public async Task<string> GetBibleVerseAsync(string book, int chapter, int? verse = null)
    {
        //contruct url based on the parameters=
        string url = verse.HasValue ?
         $"https://niv-bible.p.rapidapi.com/row?Book={Uri.EscapeDataString(book)}&Chapter={chapter}&Verse={verse.Value}"
        : $"https://niv-bible.p.rapidapi.com/row?Book={Uri.EscapeDataString(book)}&Chapter={chapter}";
        try
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();

        }
        catch (HttpRequestException ex)
        {
            throw new Exception($"Error retrieeving nbible verse:  {ex.Message} ", ex);
        }

    }

    // Overloaded method to get entire chapter
    public async Task <string>GetBibleChapterAsync(string book, int chapter)
    {
        return await GetBibleVerseAsync(book, chapter);
    }
}

//handle the controller and the routing of it
public class BibleController : ControllerBase
{
    private readonly BibleVerseService _bibleVerseService;
    public BibleController(BibleVerseService bibleVerseService)
    {
        _bibleService = bibleService;
    }

    [HttpGet("verse")]
    public async Task <IActionResult> GetVerse(
        [FromQuery] string book,    
        [FromQuery] int chapter,
        [FromQuery] int? verse = null
    )
    {
        var result =  await _bibleVerseService.GetBibleVerseAsync(book, chapter, verse);
        return Ok(result);
    }

    [HttpGet("chapter")]
    public async Task<IActionResult> GetChapter(
        [FromQuery] string book,
        [FromQuery] int chapter
    )
    {
        var result = await _bibleVerseService.GetBibleChapterAsync(book, chapter);
        return Ok(result);
    }

}