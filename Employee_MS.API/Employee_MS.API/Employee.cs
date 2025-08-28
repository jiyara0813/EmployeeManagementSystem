using Employee_MS.API;
using Microsoft.EntityFrameworkCore;

namespace Employee_MS.API
{
    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Position { get; set; }
        public decimal Salary { get; set; }
    }
}
