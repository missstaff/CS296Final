using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StephenKingFanSite.Models;
using StephenKingFanSite.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Controllers
{
    public class TriviaController : Controller
    {
        ITrivia repo;
        UserManager<AppUser> userManager;
        public TriviaController(ITrivia r, UserManager<AppUser> u)
        {
            repo = r;
            userManager = u;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TriviaQuizVM quiz, Scores model)
        {
            quiz.CheckAnswers();

            var score = quiz.GetScore();
            var ranking = quiz.GetRanking(score);
            if (ModelState.IsValid)
            {
                model.Username = userManager.GetUserAsync(User).Result;
                //model.Username = model.Username;
                if(model.Username == null)
                {
                    AppUser Guest = new AppUser
                    {
                        UserName = "Guest",
                        Name = "Guest"
                    };

                    model.Username = Guest;
                }
                model.Score = score;
                model.Ranking = ranking;
                model.Date = DateTime.Now;

                // Store the model in the database
                repo.AddScore(model);
            }

            return View(quiz);

        }
        
        public IActionResult Scores()
        {
            var scores = repo.Scores.ToList<Scores>();
            return View(scores);
        }
    }
}
