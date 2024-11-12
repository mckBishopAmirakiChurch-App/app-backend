using Sysytem.ComponentModel.DataAnnotations.Schema;
using Systems.Collections.Generic;
using Systems.ComponentModel.DataAnnotations;

namespace ChurchAppBibleAPI.Models 
{
    public class Chapter
    {
        [key]
        public int Id { get; set; }
        [Required]
        public int ChapterNumber { get; set; }

        [Required]
        [ForeignKey("Book")]
        publlc int BookId { get; set; }

        public Book Book { get; set; }

        public ICollection<Verse> Verses { get; set; }

    }
}