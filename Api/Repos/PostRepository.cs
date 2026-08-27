using Api.Models;
using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Repos;

public class PostRepository(AppDbContext db)
{
    public async Task<BlogPost?> GetPost(Guid id) => await db.Posts.FindAsync(id);
    public async Task<List<BlogPost>> GetPosts() => await db.Posts.AsNoTracking().ToListAsync();
    public async Task AddPost(BlogPost post)
    {
        db.Posts.Add(post);
        await db.SaveChangesAsync();
    }
    public async Task UpdatePost(Guid id, BlogPost post)
    {
        var oldPost = await GetPost(id);

        // copy all mutable fields from incoming post into the tracked entity, preserving Id
        oldPost.Title = post.Title;
        oldPost.Content = post.Content;
        oldPost.Category = post.Category;
        oldPost.Tags = post.Tags;

        await db.SaveChangesAsync();
    }
    public async Task<bool> DeletePost(Guid id)
    {
        var post = await GetPost(id);
        if (post is null) return false;
        db.Posts.Remove(post);
        await db.SaveChangesAsync();
        return true;
    }
}