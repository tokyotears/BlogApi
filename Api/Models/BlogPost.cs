namespace Api.Models;

public enum Category
{
    Technology,
    Sports,
    Politics
}

public enum PostTag
{
    Tech,
    Programming,
    Lifestyle
}

public class BlogPost(Guid id, string title, string content, Category category, List<PostTag> tags)
{
    public Guid Id { get; init; } = id;
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
    public Category Category { get; set; } = category;
    public List<PostTag> Tags { get; set; } = tags;
}