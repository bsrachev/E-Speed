namespace E_Speed.Areas.Admin.Models.Employees
{
    using E_Speed.Services.Users;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeFormModel
    {
        //[Required]
        //[StringLength(3, MinimumLength = 3, ErrorMessage = "The currency code has to be exactly 3 characters.")]
        //public string Code { get; init; }

        public IEnumerable<UserServiceModel> users;
    }
}
