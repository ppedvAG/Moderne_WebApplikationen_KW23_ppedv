#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieService.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public GenreType Genre { get; set; }
    }

    public enum GenreType { Action, Drama, Comedy, Horror, ScienceFiction, History, Biography, Family, Romance, Animations, Classic, Docu}

}
