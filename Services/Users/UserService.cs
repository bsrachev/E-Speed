namespace E_Speed.Services.Users
{         
    using E_Speed.Data;
    using E_Speed.Infrastructure;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;

    using static E_Speed.Data.DataConstants.Roles;
    using E_Speed.Data.Models;

    public class UserService : IUserService
    {
        private readonly E_SpeedDbContext data;

        public UserService(E_SpeedDbContext data)
            => this.data = data;

        public void GiveOfficeEmployeeRole(int userId)
        {
            var officeEmployeeRole = this.data.Roles.Where(r => r.Name == OfficeEmployeeRoleName).FirstOrDefault();

            var userRole = new IdentityUserRole<int>
            {
                UserId = userId,
                RoleId = officeEmployeeRole.Id
            };

            this.data.UserRoles.Add(userRole);

            this.data.SaveChanges();
        }

        public void GiveDeliveryEmployeeRole(int userId)
        {
            var deliveryEmployeeRole = this.data.Roles.Where(r => r.Name == DeliveryEmployeeRoleName).FirstOrDefault();

            var userRole = new IdentityUserRole<int>
            {
                UserId = userId,
                RoleId = deliveryEmployeeRole.Id
            };

            this.data.UserRoles.Add(userRole);

            this.data.SaveChanges();
        }

        public void RemoveOfficeEmployeeRole(int userId)
        {
            var officeEmployeeRole = this.data.Roles.Where(r => r.Name == OfficeEmployeeRoleName).FirstOrDefault();

            var userRole = this.data.UserRoles
                .Where(ur => ur.UserId == userId && ur.RoleId == officeEmployeeRole.Id).FirstOrDefault();

            this.data.UserRoles.Remove(userRole);

            this.data.SaveChanges();
        }

        public void RemoveDeliveryEmployeeRole(int userId)
        {
            var deliveryEmployeeRole = this.data.Roles.Where(r => r.Name == DeliveryEmployeeRoleName).FirstOrDefault();

            var userRole = this.data.UserRoles
                .Where(ur => ur.UserId == userId && ur.RoleId == deliveryEmployeeRole.Id).FirstOrDefault();

            this.data.UserRoles.Remove(userRole);

            this.data.SaveChanges();
        }

        public UserServiceModel GetUserInfo(int userId)
            => this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(o => new UserServiceModel
                {
                    Id = userId,
                    FullName = o.FullName,
                    Email = o.Email,
                    PhoneNumber = o.PhoneNumber,
                    IsEmployee = o.IsEmployee
                })
                .FirstOrDefault();

        public IEnumerable<UserServiceModel> GetAllUsers()
            => this.data
                .Users
                .Select(o => new UserServiceModel
                {
                    Id = o.Id,
                    FullName = o.FullName,
                    Email = o.Email,
                    PhoneNumber = o.PhoneNumber,
                    IsEmployee = o.IsEmployee
                })
                .ToList();
    }
}
