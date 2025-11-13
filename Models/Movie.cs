using System;
using System.ComponentModel.DataAnnotations;

namespace VidlyProject.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Please enter movie name")] 
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Display (Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Required (ErrorMessage = "Please enter release Date")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime? DateAdded { get; set; }

        [Required (ErrorMessage = "Please enter number in stock ")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }
    }
}
