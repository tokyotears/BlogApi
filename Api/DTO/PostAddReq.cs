using Api.Models;

namespace Api.DTO;

public record PostAddReq(string Title, string Content, Category Category, List<PostTag> Tags);