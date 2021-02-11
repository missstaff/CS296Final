using StephenKingFanSite.Models;
using StephenKingFanSite.Repos;
using System.Collections.Generic;
using System.Linq;

namespace Shawna_Staff.Repos
{
    public class FakeForumsRepository : IForums
    {
        List<ForumPost> posts = new List<ForumPost>();

        public IQueryable<ForumPost> Posts { get { return posts.AsQueryable<ForumPost>(); } }

        public void AddPost(ForumPost forumPost)
        {
            forumPost.PostID = posts.Count;
            posts.Add(forumPost);
        }

        public ForumPost GetForumPostsByPostTitle(string postTitle)
        {
            var post = posts.Find(p => p.Topic == postTitle);
            return post;
        }

        public void UpdatePost(ForumPost post)
        {
            throw new System.NotImplementedException();
        }
    }
}
