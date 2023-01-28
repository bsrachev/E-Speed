using System.Collections.Generic;

namespace E_Speed.Services.Users
{
    public interface IUserService
    {
        UserServiceModel GetUserInfo(int userId);

        IEnumerable<UserServiceModel> GetAllUsers();

        void GiveOfficeEmployeeRole(int userId);

        void GiveDeliveryEmployeeRole(int userId);

        void RemoveOfficeEmployeeRole(int userId);

        void RemoveDeliveryEmployeeRole(int userId);
    }
}
