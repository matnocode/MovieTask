using Microsoft.AspNetCore.Mvc;

namespace MovieTask.Models
{
    public interface IBaseModel
    {
        //for viewbar searching
        SearchMovieModel SearchMovie { get; }
    }
    public class SearchMovieModel : IBaseModel
    {
        public int Id { get; set; }
         public string Genre
         {
             get
             {
                 string genres = "";
                 if (Comedy)
                     genres += "comedy,";
                 if (Drama)
                     genres += "drama,";
                 if (Action)
                     genres += "action,";

                 if(genres != "")
                 genres = genres.Remove(genres.Length - 1);
                 return genres;
             }
         }
        public string Year { get; set; }
        public string SearchTitle { get ; set; }

        public SearchMovieModel SearchMovie { get { return this; } }

        public bool Comedy { get; set; }
        public bool Drama { get; set; }
        public bool Action { get; set; }

    }
}
