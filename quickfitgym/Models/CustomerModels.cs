using System;
using System.Collections.Generic;

namespace quickfitgym.Models
{
    public class Customer
    {
        public string ProfilePicture { get; set; }
        public List<Pictures> Picture { get; set; }
    }

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
}
