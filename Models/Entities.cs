using System.ComponentModel.DataAnnotations;

namespace Nexus.Models;

public enum PostType { Text, Image, Video }

public class AppUser
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? ProfilePicture { get; set; }
    public string? Bio { get; set; }

    public ICollection<Post> Posts { get; set; } = [];
    public ICollection<Follow> Followers { get; set; } = [];
    public ICollection<Follow> Following { get; set; } = [];
}

public class Post
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public string? MediaUrl { get; set; }
    public string? Summary { get; set; }
    public PostType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;

    public ICollection<Like> Likes { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];
}

public class Follow
{
    public int Id { get; set; }
    public int FollowerId { get; set; }
    public AppUser Follower { get; set; } = null!;
    public int FollowingId { get; set; }
    public AppUser Following { get; set; } = null!;
}

public class Like
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int AppUserId { get; set; }
}

public class Comment
{
    public int Id { get; set; }
    public string Text { get; set; } = null!;
    public int PostId { get; set; }
    public int AppUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}