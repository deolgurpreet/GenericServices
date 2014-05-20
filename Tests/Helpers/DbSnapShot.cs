﻿using System.Linq;
using Tests.DataClasses;

namespace Tests.Helpers
{
    public class DbSnapShot
    {

        public int NumPosts { get; private set; }

        public int NumPostTagLinks { get; private set; }
        
        public int NumBlogs { get; private set; }

        public int NumTags { get; private set; }

        public DbSnapShot(TemplateWebAppDb db)
        {
            NumBlogs = db.Blogs.Count();
            NumPostTagLinks = db.PostTagLinks.Count();
            NumPosts = db.Posts.Count();
            NumTags = db.Tags.Count();
        }

        public void CheckSnapShot(TemplateWebAppDb db, int postsChange = 0, int postTagLinkChange = 0, int blogsChange = 0, int tagsChange = 0)
        {
            var newSnap = new DbSnapShot(db);

            newSnap.NumPosts.ShouldEqual( NumPosts + postsChange, "posts wrong");
            newSnap.NumPostTagLinks.ShouldEqual(NumPostTagLinks + postTagLinkChange, "posttaglinks wrong");
            newSnap.NumBlogs.ShouldEqual(NumBlogs + blogsChange, "blogs wrong");
            newSnap.NumTags.ShouldEqual(NumTags + tagsChange, "tags wrong");
        }

    }
}