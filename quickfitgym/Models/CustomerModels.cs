using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    /*public class Customer
    {
        public string ProfilePicture { get; set; }
        public List<Pictures> Picture { get; set; }
    }*/

    public class Pictures
    {
        public string Picture { get; set; }
        public string CoverPictureUrl{ get; set; }
        public byte[] CoverPictureArray { get; set; }
    }

    public class ProfileImage
    {
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public byte[] ImageArray { get; set; }
    }

    public class Customer
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
        public string PhotoUrl { get; set; }
    }
}
