using Microsoft.EntityFrameworkCore;
using StephenKingFanSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Repos
{
    public class TriviaRepo : ITrivia
    {
        private ForumContext context;
        public TriviaRepo(ForumContext c)
        {
            context = c;
        }
        public IQueryable<Scores> Scores
        {
            get
            {
                return context.Scores.Include(e => e.Username);

            }
        }

        public void AddScore(Scores score)
        {
            context.Scores.Add(score);
            context.SaveChanges();
        }
    }
}
