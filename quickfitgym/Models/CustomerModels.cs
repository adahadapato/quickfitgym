using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
   
    public class Pictures
    {
        public string Picture { get; set; }
        public string CoverPictureUrl{ get; set; }
        public byte[] CoverPictureArray { get; set; }
    }

    /*public class MyArray
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime JoinDate { get; set; }
        public bool EmailConfirmed { get; set; }
        public string UserName { get; set; }
        public object AboutMe { get; set; }
        public object ContactAddress { get; set; }
        public object Country { get; set; }
        public object DateOfBirth { get; set; }
        public object Height { get; set; }
        public object Occupation { get; set; }
        public object Region { get; set; }
        public object State { get; set; }
        public object Weight { get; set; }
        public object ProfilePictUrl { get; set; }
        public object CoverPictUrl { get; set; }
    }*/

    
    public class Customer
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string UserName { get; set; }
        public string ContactAddress { get; set; }
        public float? Height { get; set; }
        public float? Weight { get; set; }
        public string AboutMe { get; set; }
        public string Occupation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Region { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ProfilePictUrl { get; set; }
        public string CoverPictUrl { get; set; }
        public string RegistrationDate { get; set; }

        public string FullProfilePictUrl => string.Format($"{AppSettings.ImageUrl}{ProfilePictUrl}");
        public string FullCoverPictUrl => string.Format($"{AppSettings.ImageUrl}{CoverPictUrl}");
    }

    public class CoverPict
    {
        public string UserId { get; set; }
        public string CoverPictUrl { get; set; }
        public byte[] CoverPictArray { get; set; }
    }

    public class ProfilePict
    {
        public string UserId { get; set; }
        public string ProfilePictUrl { get; set; }
        public byte[] ProfilePictArray { get; set; }
    }
}
