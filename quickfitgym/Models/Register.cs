using System;
namespace quickfitgym.Models
{
    public class Register
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }
        public string LasstName { get; set; }
        public string Password { get; set; }
        public string RoleName { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
