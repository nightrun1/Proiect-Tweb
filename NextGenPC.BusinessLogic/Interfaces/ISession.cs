namespace NextGenPC.BusinessLogic.Interfaces;

public interface ISession
{
    // Session management interface
    // For example: login, logout, session state, etc.
    bool IsAuthenticated { get; }
    string? UserId { get; }
    void Login(string userId);
    void Logout();
} 