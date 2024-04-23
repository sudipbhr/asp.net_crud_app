using Authentication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq; // Add this using directive at the top of your controller file


namespace Authentication.Controllers
{
    public class PostController:Controller
    {
       private readonly AuthenticationContext db;

        public PostController(AuthenticationContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var posts = db.Posts
               .Include(p => p.User)
           .Include(p => p.Likes)
           .Include(p => p.Dislike)
           .Include(p => p.Comments)
           .ToList();


            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
