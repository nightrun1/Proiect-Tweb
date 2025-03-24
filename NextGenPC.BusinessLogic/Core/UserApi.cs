namespace NextGenPC.BusinessLogic.Core;

public interface UserApi
{
    // User-specific business logic interface
    void Register(string username, string password, string email);
    bool Login(string username, string password);
    void UpdateProfile(string userId, string newEmail);
    void ChangePassword(string userId, string oldPassword, string newPassword);
} 