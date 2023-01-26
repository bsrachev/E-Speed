namespace E_Speed.Services.Users
{
    public class UserServiceModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsEmployee { get; set; }
    }
}
