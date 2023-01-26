using System.Collections.Generic;

namespace E_Speed.Services.Users
{
    public interface IUserService
    {
        UserServiceModel GetUserInfo(int userId);

        IEnumerable<UserServiceModel> GetAllUsers();
    }
}
