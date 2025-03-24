using NextGenPC.BusinessLogic.Core;
using NextGenPC.BusinessLogic.Interfaces;

namespace NextGenPC.BusinessLogic;

public class BusinessLogicManager
{
    private static SessionBL? _sessionBL;

    public static ISession GetSessionBL()
    {
        _sessionBL ??= new SessionBL();
        return _sessionBL;
    }

    private readonly ISession _session;
    private readonly AdminApi _adminApi;
    private readonly UserApi _userApi;

    public BusinessLogicManager(ISession session)
    {
        _session = session;
        _adminApi = new AdminApi();
        _userApi = (UserApi)session; 
    }

    public AdminApi Admin => _session.IsAuthenticated ? _adminApi : throw new UnauthorizedAccessException("Admin access requires authentication");
    public UserApi User => _userApi;
} 