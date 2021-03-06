﻿using Microsoft.EntityFrameworkCore;
using StephenKingFanSite.Models;
using System.Linq;

namespace StephenKingFanSite.Repos
{
    public class ForumsRepository : IForums
    {
        private ForumContext context;
        public ForumsRepository(ForumContext c)
        {
            context = c;
        }

        public IQueryable<ForumPost> Posts
        {
            get
            {
                return context.ForumPosts.Include(e => e.Name)
                        .Include(e => e.Replies)
                        .ThenInclude(e => e.Commenter);
                       
            }
        }


        public void AddPost(ForumPost forumPost)
        {
            context.ForumPosts.Add(forumPost);
            context.SaveChanges();
        }


        public ForumPost GetForumPostsByPostTitle(string postTitle)
        {
            var posts = context.ForumPosts.Find(postTitle);
            return posts;
        }

        public void UpdatePost(ForumPost post)
        {
            context.ForumPosts.Update(post);
            context.SaveChanges();
        }
    }
}
