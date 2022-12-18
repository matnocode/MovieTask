namespace MovieTask.Models
{
    public class ManageMovieModel : IBaseModel
    {
        public MovieModel GetMovie() 
        {
            return new MovieModel()
            {
                Id = this.Id,
                Poster = this.Poster,
                Description = this.Description,
                Title = this.Title,
                Background = this.Background,
                Actors = this.Actors,
                Genre = this.Genre,
                Released = this.Released,
                Rating = this.Rating,
                Duration = this.Duration
            };
        }

        //implement getting image file, rename it as title-poster | title-bg  and save it somewhere, file path will be /Data/images/image-name

        public int Id { get; set; }
        public string Poster { get; set; } //url
        //public IFormFile FormPoster { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string Background { get; set; } //url
        public string Actors { get; set; }//comma separated values
        public string Genre { get { if(_genre.EndsWith(',')) _genre.Remove(_genre.Length - 1); return _genre; } set { _genre += value; } }//comma separated values
        string _genre="";
        public DateTime Released { get; set; }
        public int Rating { get; set; }
        public int Duration { get; set; }//in minutes

        public SearchMovieModel SearchMovie { get { return new SearchMovieModel(); } }
    }
}
