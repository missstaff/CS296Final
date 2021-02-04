using StephenKingFanSite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Repos
{
    public interface IMovieRepo
    {
        public Task<IQueryable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetMoviesAsync(int? id);
        public Task<int> AddMoviesAsync(Movie movie);
        public void UpdateMoviesAsync(Movie movie, int id);
        public Task<Movie> DeleteMoviesAsync(int? id);
        public bool MoviesExists(int id);
        public Task SaveChangesAsync();
    }
}
