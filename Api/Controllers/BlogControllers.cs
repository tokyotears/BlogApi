using Api.Models;
using Api.Repos;
using Api.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/[controller]/posts")]
public class BlogController : ControllerBase
{ 
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetPost(PostRepository postRepo, Guid id)
    {
        var res = await postRepo.GetPost(id);
        return Ok(res);
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts(PostRepository postRepo)
    {
        var res = await postRepo.GetPosts();
        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> AddPost(PostRepository postRepo, PostAddReq req)
    {
        BlogPost post = new(Guid.NewGuid(), req.Title, req.Content, req.Category, req.Tags);
        await postRepo.AddPost(post);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdatePost(PostRepository postRepo, PostAddReq req, Guid id)
    {
        BlogPost post = new(Guid.NewGuid(), req.Title, req.Content, req.Category, req.Tags);
        await postRepo.UpdatePost(id, post);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeletePost(PostRepository postRepo, Guid id)
    {
        var res = await postRepo.DeletePost(id);
        return res ? NoContent() : BadRequest("No post to delete");
    }
}