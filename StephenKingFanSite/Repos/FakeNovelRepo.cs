using StephenKingFanSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Repos
{
    public class FakeNovelRepo : INovelRepo
    {

        private List<Novel> novels = new List<Novel>();

        public List<Novel> Novels { get { return novels; } }

        public Task<int> AddNovelAsync(Novel novel)
        {
            int success = 0;
            if (novel != null)
            {

                novel.ID = novels.Count + 1;
                novels.Add(novel);
                success = 1;
            }

            return Task.FromResult<int>(success);
        }

        public Task<Novel> DeleteNovelAsync(int? id)
        {
            var novel = novels.Find(n => n.ID == id);
            novels.Remove(novel);
            return Task.FromResult<Novel>(novel);
        }

        public Task<IQueryable<Novel>> GetAllNovelsAsync()
        {
            return Task.FromResult(novels.AsQueryable());
        }

        public Task<Novel> GetNovelAsync(int? id)
        {
            return Task.FromResult(novels.ElementAt((int)id));
        }

        //if breaks add async into name of method and add await infront of get moviesget
        public bool NovelExists(int id)
        {
            var movie = GetNovelAsync(id);
            if (movie != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Task SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        public void UpdateNovelAsync(Novel novel, int id)
        {
            var n = novels.Find(n => n.ID == id);
            n.Title = novel.Title;
            n.Publisher = novel.Publisher;
            n.PulicationDate = novel.PulicationDate;
            n.Genre = novel.Genre;
            n.Rating = novel.Rating;
        }
    }
}
