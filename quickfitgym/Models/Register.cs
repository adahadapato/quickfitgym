using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    public class Register
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
    }

    public class RegisterSuccess
    {
        public string Url { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Mobile { get; set; }
        public DateTime JoinDate { get; set; }
        public List<string> Roles { get; set; }
        public List<object> Claims { get; set; }
    }
}
