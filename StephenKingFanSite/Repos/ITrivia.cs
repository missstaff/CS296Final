using StephenKingFanSite.Models;
using System.Linq;

namespace StephenKingFanSite.Repos
{
    public interface ITrivia
    {
        IQueryable<Scores> Scores { get; }
        public void AddScore(Scores score);
    }
}
