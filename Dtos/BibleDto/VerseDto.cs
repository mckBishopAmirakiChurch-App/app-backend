using Sysytem.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChurchAppBibleAPI.Models
{
    public class verse
    {
        [key]
        public int Id { get; set; }
        [Required]
        public int VerseNumber { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        [ForeignKey("Chapter")]
        public int ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}