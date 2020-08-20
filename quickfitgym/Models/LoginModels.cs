using System;
namespace quickfitgym.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Mobile { get; set; }
        public string Issued_date { get; set; }
        public string Expiry_date { get; set; }
        public string Roles { get; set; }
    }

    public class LoginFailedModel
    {
        public string error { get; set; }
        public string error_description { get; set; }
    }
}
