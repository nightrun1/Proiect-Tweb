using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.Domain.Entities.User;

namespace NextGenPC.BusinessLogic;

public class SessionBL : UserApi, ISession
{
    private string? _userId;
    private Dictionary<string, ULoginData> _users = new();

    public bool IsAuthenticated => !string.IsNullOrEmpty(_userId);
    public string? UserId => _userId;

    public void Login(string userId)
    {
        _userId = userId;
    }

    public void Logout()
    {
        _userId = null;
    }

    public void Register(string username, string password, string email)
    {
        if (_users.ContainsKey(username))
            throw new InvalidOperationException("Username already exists");

        _users[username] = new ULoginData
        {
            Username = username,
            Password = password, 
            Email = email,
            IsActive = true,
            LastLogin = DateTime.UtcNow
        };
    }

    public bool Login(string username, string password)
    {
        if (!_users.ContainsKey(username))
            return false;

        var user = _users[username];
        if (user.Password != password) 
            return false;

        user.LastLogin = DateTime.UtcNow;
        Login(username); 
        return true;
    }

    public void UpdateProfile(string userId, string newEmail)
    {
        if (!_users.ContainsKey(userId))
            throw new KeyNotFoundException("User not found");

        _users[userId].Email = newEmail;
    }

    public void ChangePassword(string userId, string oldPassword, string newPassword)
    {
        if (!_users.ContainsKey(userId))
            throw new KeyNotFoundException("User not found");

        var user = _users[userId];
        if (user.Password != oldPassword) 
            throw new UnauthorizedAccessException("Invalid old password");

        user.Password = newPassword; 
    }
} 