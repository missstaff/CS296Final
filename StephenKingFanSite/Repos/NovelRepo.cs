using StephenKingFanSite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Repos
{
    public class NovelRepo : INovelRepo
    {
        ForumContext context;

        public NovelRepo(ForumContext c)
        {
            context = c;
        }
        public async Task<int> AddNovelAsync(Novel novel)
        {
            context.Novels.Add(novel);
            return await context.SaveChangesAsync();
        }

        public async Task<Novel> DeleteNovelAsync(int? id)
        {
            Novel novel = context.Novels.FirstOrDefault(n => n.ID == id);
            if (novel != null)
            {
                context.Novels.Remove(novel);
                await context.SaveChangesAsync();
            }

            return await Task.FromResult(novel);
        }

        public async Task<IQueryable<Novel>> GetAllNovelsAsync()
        {
            return await Task.FromResult<IQueryable<Novel>>(context.Novels);
        }

        public async Task<Novel> GetNovelAsync(int? id)
        {
            return await Task.FromResult<Novel>(context.Novels.Find(id));
        }

        public bool NovelExists(int id)
        {
            var novel = GetNovelAsync(id);
            if (novel != null)
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
            return context.SaveChangesAsync();
        }

        public void UpdateNovelAsync(Novel novel, int id)
        {
            var n = context.Novels.Find(id);
            n.Title = novel.Title;
            n.Publisher = novel.Publisher;
            n.PulicationDate = novel.PulicationDate;
            n.Genre = novel.Genre;
            n.Rating = novel.Rating;
        }
    }
}
