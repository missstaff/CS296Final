using StephenKingFanSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
