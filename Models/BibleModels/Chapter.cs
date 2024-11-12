using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChurchAppBibleAPI.Models 
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ChapterNumber { get; set; }

        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        public Book Book { get; set; }

        public ICollection<Verse> Verses { get; set; }
    }
}