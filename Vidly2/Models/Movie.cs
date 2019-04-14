using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie//POCO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime ReliseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Range(1,20)]
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        public int GenreID { get; set; }
    }
}