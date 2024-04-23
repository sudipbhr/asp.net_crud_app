using Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using static Authentication.Models.Like;

namespace Authentication.Data;

public class AuthenticationContext : IdentityDbContext<IdentityUser>
{
    public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //builder.Entity<Post>()
        //    .HasOne(p => p.User)
        //    .WithMany(u=> u.Posts)
        //    .HasForeignKey(c => c.UserId);
    }
}
