using StephenKingFanSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenKingFanSite.Repos
{
    public interface INovelRepo
    {
        public Task<IQueryable<Novel>> GetAllNovelsAsync();
        public Task<Novel> GetNovelAsync(int? id);
        public Task<int> AddNovelAsync(Novel novel);
        public void UpdateNovelAsync(Novel novel, int id);
        public Task<Novel> DeleteNovelAsync(int? id);
        public bool NovelExists(int id);
        public Task SaveChangesAsync();

    }
}
