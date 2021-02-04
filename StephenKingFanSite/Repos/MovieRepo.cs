using StephenKingFanSite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Repos
{
    public class MovieRepo : IMovieRepo
    {
        ForumContext context;

        public MovieRepo(ForumContext c)
        {
            context = c;
        }
        public async Task<int> AddMoviesAsync(Movie movie)
        {
            context.Movies.Add(movie);
            return await context.SaveChangesAsync();
        }

        public async Task<Movie> DeleteMoviesAsync(int? id)
        {
            Movie movie = context.Movies.FirstOrDefault(m => m.ID == id);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                await context.SaveChangesAsync();
            }

            return await Task.FromResult(movie);
        }

        public async Task<IQueryable<Movie>> GetAllMoviesAsync()
        {
            return await Task.FromResult<IQueryable<Movie>>(context.Movies);
        }

        public async Task<Movie> GetMoviesAsync(int? id)
        {
            return await Task.FromResult<Movie>(context.Movies.Find(id));
        }

        public bool MoviesExists(int id)
        {
            var movie = GetMoviesAsync(id);
            if (movie != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        public void UpdateMoviesAsync(Movie movie, int id)
        {
            var m = context.Movies.Find(id);
            m.Title = movie.Title;
            m.Director = movie.Director;
            m.PremiereDate = movie.PremiereDate;
            m.Genre = movie.Genre;
            m.Rating = movie.Rating;
        }
    }
}
