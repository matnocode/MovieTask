using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using System.ComponentModel.DataAnnotations;

namespace MovieTask.Models
{
    public enum MovieGenre 
    {
        Comedy,Action,Drama
    }
    public class MovieModel : IBaseModel
    {
        
        public int Id { get; set; }
        public string? Poster { get; set; } //url
        public string Description { get; set; }
        public string Title { get; set; }
        public string? Background { get; set; } //url
        public string? Actors { get; set; }//comma separated values
        public string? Genre { get; set; }//comma separated values
        public DateTime Released { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }//in minutes
        public SearchMovieModel SearchMovie { get { return new SearchMovieModel();
    }
}
    }
}
