namespace E_Speed.Services.Users
{
    using E_Speed.Data;
    using E_Speed.Infrastructure;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Identity;

    using static E_Speed.Data.DataConstants.Roles;
    using E_Speed.Data.Models;
    using static E_Speed.Data.DataConstants;

    public class UserService : IUserService
    {
        private readonly E_SpeedDbContext data;

        public UserService(E_SpeedDbContext data)
            => this.data = data;

        public void GiveOfficeEmployeeRole(int userId)
        {
            var checkIfUserRoleAlreadyExists = this.data.UserRoles.Where(u => u.UserId == userId && u.RoleId == GetOfficeEmployeeRoleId()).FirstOrDefault();

            if (checkIfUserRoleAlreadyExists == null)
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
        }

        public void GiveDeliveryEmployeeRole(int userId)
        {
            var checkIfUserRoleAlreadyExists = this.data.UserRoles.Where(u => u.UserId == userId && u.RoleId == GetDeliveryEmployeeRoleId()).FirstOrDefault();

            if (checkIfUserRoleAlreadyExists == null)
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
        }

        public void RemoveOfficeEmployeeRole(int userId)
        {
            var checkIfUserRoleExists = this.data.UserRoles.Where(u => u.UserId == userId && u.RoleId == GetOfficeEmployeeRoleId()).FirstOrDefault();

            if (checkIfUserRoleExists != null)
            {
                var officeEmployeeRole = this.data.Roles.Where(r => r.Name == OfficeEmployeeRoleName).FirstOrDefault();

                var userRole = this.data.UserRoles
                    .Where(ur => ur.UserId == userId && ur.RoleId == officeEmployeeRole.Id).FirstOrDefault();

                this.data.UserRoles.Remove(userRole);

                this.data.SaveChanges();
            }
        }

        public void RemoveDeliveryEmployeeRole(int userId)
        {
            var checkIfUserRoleExists = this.data.UserRoles.Where(u => u.UserId == userId && u.RoleId == GetDeliveryEmployeeRoleId()).FirstOrDefault();

            if (checkIfUserRoleExists != null)
            {
                var deliveryEmployeeRole = this.data.Roles.Where(r => r.Name == DeliveryEmployeeRoleName).FirstOrDefault();

                var userRole = this.data.UserRoles
                    .Where(ur => ur.UserId == userId && ur.RoleId == deliveryEmployeeRole.Id).FirstOrDefault();

                this.data.UserRoles.Remove(userRole);

                this.data.SaveChanges();
            }
        }

        public UserServiceModel GetUserInfo(int userId)
        {

            var deliveryEmployeeRole = this.data.Roles.Where(r => r.Name == DeliveryEmployeeRoleName).FirstOrDefault();


            var user = this.data
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

            user.IsOfficeEmployee = this.data.UserRoles.Where(u => u.UserId == userId && u.RoleId == GetOfficeEmployeeRoleId()).FirstOrDefault() == null ? false : true;

            user.IsDeliveryEmployee = this.data.UserRoles.Where(u => u.UserId == userId && u.RoleId == GetDeliveryEmployeeRoleId()).FirstOrDefault() == null ? false : true;

            return user;
        }

        public IEnumerable<UserServiceModel> GetAllUsers()
        {
            var users = this.data
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

            foreach (var user in users)
            {
                user.IsOfficeEmployee = this.data.UserRoles.Where(u => u.UserId == user.Id && u.RoleId == GetOfficeEmployeeRoleId()).FirstOrDefault() == null ? false : true;

                user.IsDeliveryEmployee = this.data.UserRoles.Where(u => u.UserId == user.Id && u.RoleId == GetDeliveryEmployeeRoleId()).FirstOrDefault() == null ? false : true;
            }

            return users;
        }

        private int GetOfficeEmployeeRoleId()
            => this.data.Roles.Where(r => r.Name == OfficeEmployeeRoleName).FirstOrDefault().Id;

        private int GetDeliveryEmployeeRoleId()
            => this.data.Roles.Where(r => r.Name == DeliveryEmployeeRoleName).FirstOrDefault().Id;

    }
}
