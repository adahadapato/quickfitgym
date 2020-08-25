using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    /*public class Members
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public List<Payment> Payments { get; set; }
    }*/

    public class Members
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
        public string RegistrationDate { get; set; }
    }

    public class AdminMenu
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Details { get; set; }
    }
}
