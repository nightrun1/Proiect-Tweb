namespace NextGenPC.Domain.Entities.User;

public class ULoginData
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime LastLogin { get; set; }
    public bool IsActive { get; set; }
} 