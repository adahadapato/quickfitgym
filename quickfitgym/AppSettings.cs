using System;
namespace quickfitgym
{
    public static class AppSettings
    {
        public static string ApiUrl
        {
            get
            {
                return "https://quickfit.zayun.biz/api/";
            }
        }

        public static string TokenUrl
        {
            get
            {
                return "https://quickfit.zayun.biz/Token";
            }
        }

        public static string ImageUrl
        {
            get
            {
                return "https://quickfit.zayun.biz/wwwroot/";
            }
        }
    }

}
