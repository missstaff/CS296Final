using StephenKingFanSite.Controllers;
using StephenKingFanSite.Models;
using StephenKingFanSite.Repos;
using System;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class MoviesUnitTest
    {
        DateTime dt = new DateTime(2021, 01, 01);

        [Fact]
        public void GetAllMovies()
        {
            var repo = new FakeMovieRepo();
            var controller = new MoviesController(repo);
            repo.Movies.Add(new Movie()
            {
                Title = "test",
                Director = "test",
                PremiereDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Movies.Add(new Movie()
            {
                Title = "test2",
                Director = "test2",
                PremiereDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Movies.Add(new Movie()
            {
                Title = "test3",
                Director = "test3",
                PremiereDate = dt,
                Genre = "T",
                Rating = 4
            });

            var movies = repo.Movies.ToList();

            Assert.Equal(3, movies.Count);
            Assert.Equal("test", movies[0].Title);
            Assert.Equal("test2", movies[1].Title);
            Assert.Equal("test3", movies[2].Title);

        }

        [Fact]
        public void GetAMovie()
        {
            var repo = new FakeMovieRepo();
            var controller = new MoviesController(repo);
            repo.Movies.Add(new Movie()
            {
                ID = 1,
                Title = "test",
                Director = "test",
                PremiereDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Movies.Add(new Movie()
            {
                ID = 2,
                Title = "test2",
                Director = "test2",
                PremiereDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Movies.Add(new Movie()
            {
                ID = 3,
                Title = "test3",
                Director = "test3",
                PremiereDate = dt,
                Genre = "T",
                Rating = 4
            });

            var movies = repo.Movies.ToList();
            int id = 3;
            var movie = movies.Find(m => m.ID == id);
            Assert.Equal(3, movies.Count);
            Assert.Equal("test3", movie.Title);
            Assert.Equal("T", movie.Genre);
            Assert.Equal(4, movie.Rating);
        }

        [Fact]
        public void AddMovie()
        {
            var repo = new FakeMovieRepo();
            var controller = new MoviesController(repo);
            var movies = repo.Movies.ToList();
            var movie = new Movie()
            {
                Title = "test",
                Director = "test",
                PremiereDate = dt,
                Genre = "H",
                Rating = 5

            };
            movies.Add(movie);
            Assert.Equal("test", movies[0].Title);
        }

        [Fact]
        public void DeleteMovie()
        {
            var repo = new FakeMovieRepo();
            var controller = new MoviesController(repo);
            repo.Movies.Add(new Movie()
            {
                ID = 1,
                Title = "test",
                Director = "test",
                PremiereDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Movies.Add(new Movie()
            {
                ID = 2,
                Title = "test2",
                Director = "test2",
                PremiereDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Movies.Add(new Movie()
            {
                ID = 3,
                Title = "test3",
                Director = "test3",
                PremiereDate = dt,
                Genre = "T",
                Rating = 4
            });

            var movies = repo.Movies.ToList();
            int id = 3;
            var movie = movies.Find(m => m.ID == id);

            movies.Remove(movie);
            Assert.NotEqual(3, movies.Count);
            Assert.Equal(2, movies.Count);
            Assert.Equal("test", movies[0].Title);
            Assert.Equal("test2", movies[1].Title);
        }

        [Fact]
        public void UpdateMovie()
        {
            var repo = new FakeMovieRepo();
            var controller = new MoviesController(repo);
            repo.Movies.Add(new Movie()
            {
                ID = 1,
                Title = "test",
                Director = "test",
                PremiereDate = dt,
                Genre = "H",
                Rating = 5
            });
            repo.Movies.Add(new Movie()
            {
                ID = 2,
                Title = "test2",
                Director = "test2",
                PremiereDate = dt,
                Genre = "S",
                Rating = 3
            });
            repo.Movies.Add(new Movie()
            {
                ID = 3,
                Title = "test3",
                Director = "test3",
                PremiereDate = dt,
                Genre = "T",
                Rating = 4
            });

            var movies = repo.Movies.ToList();
            int id = 3;
            var movie = movies.Find(m => m.ID == id);

            movie.Title = "Updated";
            movie.Director = "Updated";
            movie.Rating = 5;

            Assert.Equal(3, movies.Count);
            Assert.Equal("Updated", movie.Title);
            Assert.Equal("Updated", movie.Director);
            Assert.Equal(5, movie.Rating);
        }
    }
}
