namespace E_Speed.Data.Models
{
    public class EmployeeOffice
    {
        public int Id { get; set; }

        public Office Office { get; set; }

        public string OfficeId { get; set; }

        public User Employee { get; set; }

        public int EmployeeId { get; set; }
    }
}