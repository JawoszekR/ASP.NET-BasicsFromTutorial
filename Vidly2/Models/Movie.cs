using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly2.Models
{
    public class Movie//POCO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReliseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
        public Genre Genre { get; set; }
        public int GenreID { get; set; }
    }
}