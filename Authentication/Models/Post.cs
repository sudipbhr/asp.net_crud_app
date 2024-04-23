using Microsoft.AspNetCore.Identity;

namespace Authentication.Models
{
        public class Like
        {
            public int Id { get; set; }
            public int PostId { get; set; }
            public Post Posts { get; set; }
            public int UserId { get; set; }
            public  IdentityUser User { get; set; }

        }
        public class Dislike
        {
            public int Id { get; set; }
            public int PostId { get; set; }
            public Post Posts { get; set; }
            public int UserId { get; set; }
            public IdentityUser User { get; set; }

        }

        public class Post
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public string BannerImage { get; set; } // New property for banner image

            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public DateTime UpdatedDate { get; set; }
            public int UserId { get; set; }
            //navigationproperty
            public IdentityUser User { get; set; }
            public ICollection<Like> Likes { get; set; }
            public ICollection<Dislike> Dislike { get; set; }
            public virtual ICollection<Comment> Comments { get; set; }
        }

        public class Comment
        {
            public int Id { get; set; }
            public string Content { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedDate { get; set; }
            public int PostId { get; set; }
            public virtual Post Post { get; set; }
            public int UserId { get; set; }
            public IdentityUser User { get; set; }
        }
    }

