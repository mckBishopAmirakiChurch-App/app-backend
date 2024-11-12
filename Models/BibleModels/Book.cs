using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurchAppBibleAPI.Models 
{
    public class Book 
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }

        public int ChaptersCount { get; set; }

        public ICollection<Chapter> Chapters { get; set; }

    }
}