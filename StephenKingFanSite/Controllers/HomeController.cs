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
        public IActionResult Forum(string topic, string name)
        {
            List<ForumPost> posts = null;
            if (topic != null)
            {
                posts = (from f in repo.Posts
                         where f.Topic == topic
                         select f).ToList();
            }
            else if (name != null)
            {
                posts = (from f in repo.Posts
                         where f.Name.UserName == name
                         select f).ToList();
            }

            return View(posts);
        }

        [Authorize]
        public IActionResult Reply(int id)
        {
            var replyVM = new ReplyVM { PostID = id };
            return View(replyVM);
        }

        [HttpPost]
        public RedirectToActionResult Reply(ReplyVM replyVM)
        {
            var reply = new Reply { ReplyText = replyVM.ReplyText };
            reply.Commenter = userManager.GetUserAsync(User).Result;

            reply.Date = DateTime.Now;
            //retrieve the post the comment belongs to//
            var post = (from r in repo.Posts
                        where r.PostID == replyVM.PostID
                        select r).First<ForumPost>();

            post.replies.Add(reply);
            repo.UpdatePost(post);


            return RedirectToAction("Forum");
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
 
