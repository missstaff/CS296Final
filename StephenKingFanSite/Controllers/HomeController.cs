using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StephenKingFanSite.Models;
using StephenKingFanSite.Repos;
using System;
using System.Diagnostics;
using System.Linq;

namespace StephenKingFanSite.Controllers
{
    public class HomeController : Controller
    {
        IForums repo;
        UserManager<AppUser> userManager;

        public HomeController(IForums r, UserManager<AppUser> u)
        {
            repo = r;
            userManager = u;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        public IActionResult Forum()
        {
            var posts = repo.Posts.ToList<ForumPost>();
            return View(posts);
        }

        public IActionResult ForumPost()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForumPost(ForumPost model)
        {

            if (ModelState.IsValid)
            {
                model.Name = userManager.GetUserAsync(User).Result;
                model.Name.Name = model.Name.UserName;
                model.Date = DateTime.Now;

                // Store the model in the database
                repo.AddPost(model);
            }
            else
            {
                return View(model);
            }
            return Redirect("Forum"); // displays all messages
        }


        public IActionResult Trivia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Trivia(TriviaMV quiz)
        {
            quiz.CheckAnswers();
            return View(quiz);

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
 
