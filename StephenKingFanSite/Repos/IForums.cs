using StephenKingFanSite.Models;
using System.Linq;

namespace StephenKingFanSite.Repos
{
    public interface IForums
    {
        IQueryable<ForumPost> Posts { get; }
        public void AddPost(ForumPost forumPost);

        public ForumPost GetForumPostsByPostTitle(string postTitle);
        void UpdatePost(ForumPost post);
    }
}
