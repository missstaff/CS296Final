using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StephenKingFanSite.Models;
using StephenKingFanSite.Repos;
using System;
using System.Collections.Generic;
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


        [Authorize]
        public IActionResult Forum()
        {
            var posts = repo.Posts.ToList<ForumPost>();
            return View(posts);
        }

        [HttpPost]
        public IActionResult Forum(string topic, string date)
        {
            List<ForumPost> posts = null;
            if (topic != null)
            {
                posts = (from f in repo.Posts
                         where f.Topic == topic
                         select f).ToList();
            }
            else if (date != null)
            {
                DateTime d;
                DateTime.TryParse(date, out d);
                posts = (from f in repo.Posts
                         where f.Date.Month == d.Month &&
                         f.Date.Day == d.Day &&
                         f.Date.Year == d.Year
                         select f).ToList();
            }

            return View(posts);
        }

        public IActionResult Trivia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Trivia(TriviaQuizVM quiz)
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
 
