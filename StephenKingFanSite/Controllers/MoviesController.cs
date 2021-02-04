using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StephenKingFanSite.Models;
using StephenKingFanSite.Repos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Controllers
{
    public class MoviesController : Controller
    {
        IMovieRepo repo;

        public MoviesController(IMovieRepo r)
        {
            repo = r;
        }

        // GET: Movies
        public async Task<IActionResult> Index(
            string sortOrder,
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["DirectorSortParm"] = sortOrder == "Director" ? "director_desc" : "Director";
            ViewData["GenreSortParm"] = sortOrder == "Genre" ? "genre_desc" : "Genre";
            ViewData["RatingSortParm"] = sortOrder == "Rating" ? "rating_desc" : "Rating";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var movies = from m in await repo.GetAllMoviesAsync()
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString)
                                       || s.Director.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "Director":
                    movies = movies.OrderBy(m => m.Director);
                    break;
                case "director_desc":
                    movies = movies.OrderByDescending(m => m.Director);
                    break;
                case "Date":
                    movies = movies.OrderBy(m => m.PremiereDate);
                    break;
                case "date_desc":
                    movies = movies.OrderByDescending(m => m.PremiereDate);
                    break;
                case "Genre":
                    movies = movies.OrderBy(m => m.Genre);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(m => m.Genre);
                    break;
                case "Rating":
                    movies = movies.OrderBy(m => m.Rating);
                    break;
                case "rating_desc":
                    movies = movies.OrderByDescending(m => m.Rating);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Movie>.CreateAsync(movies.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = await repo.GetMoviesAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Director,PremiereDate,Genre,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                await repo.AddMoviesAsync(movie);
                await repo.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var movie = await repo.GetMoviesAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Director,PremiereDate,Genre,Rating")] Movie movie)
        {
            if (id != movie.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateMoviesAsync(movie, id);
                    await repo.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await repo.GetMoviesAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = repo.GetMoviesAsync(id);
            await repo.DeleteMoviesAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return repo.MoviesExists(id);
        }
    }
}
