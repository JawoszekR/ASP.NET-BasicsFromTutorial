using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        [Required]
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? ReliseDate { get; set; }
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }
        [Required]
        public int? GenreID { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            GenreID = movie.GenreID;
            Id = movie.Id;
            Name = movie.Name;
            NumberInStock = movie.NumberInStock;
            ReliseDate = movie.ReliseDate;
        }
    }
}