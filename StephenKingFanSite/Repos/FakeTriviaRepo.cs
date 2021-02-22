using StephenKingFanSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace StephenKingFanSite.Repos
{
    public class FakeTriviaRepo : ITrivia
    {
        List<Scores> scores = new List<Scores>();
        public IQueryable<Scores> Scores { get { return scores.AsQueryable<Scores>(); } }

        public void AddScore(Scores score)
        {
            score.scoresID = scores.Count;
            scores.Add(score);
        }
    }
}
