﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using quickfitgym.Models;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using UnixTimeStamp;
using System.Collections.Generic;

namespace quickfitgym.Services
{
    public static class ApiService
    {
        public static async Task<bool> Register(Register Model)
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(Model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{AppSettings.ApiUrl}accounts/register", content);
            if (response.IsSuccessStatusCode) return true;
            else return false;
        }

        public static async Task<bool> Login(string UserName, string Password)
        {
            var client = new HttpClient();
            var request = $"grant_type=password&username={UserName}&password={Password}";
            var content = new StringContent(request, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync(new Uri(AppSettings.TokenUrl), content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                string hold = result.Replace(".issued", "Issued_date");
                result = hold.Replace(".expires", "Expiry_date");
                var IsAdmin = result.Contains("Admin");
                var json = JsonConvert.DeserializeObject<Token>(result);
                var tempTime = DateTime.Parse(json.Expiry_date).ToUniversalTime();

                var tokenExp = ((DateTimeOffset)tempTime).ToUnixTimeMilliseconds();

                Preferences.Set("token", json.access_token);
                Preferences.Set("mobile", json.Mobile);
                Preferences.Set("firstName", json.firstName);
                Preferences.Set("lastName", json.lastName);
                Preferences.Set("IsAdmin", IsAdmin);
                Preferences.Set("tokeExpirationTime", tokenExp);
                Preferences.Set("CurrentTime", UnixTime.GetCurrentTime());
                return true;
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<LoginFailedModel>(result);
                await Application.Current.MainPage.DisplayAlert("Error", json.error_description, "Ok");

            }
            return false;
        }

        public static async Task<AboutUs> GetAboutUs()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await client.GetStringAsync($"{AppSettings.ApiUrl}admin/aboutus");

            var json = JsonConvert.DeserializeObject<AboutUs>(response);
            return json;
        }

        public static async Task<List<Program>> GetPrograms()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
            var response = await client.GetStringAsync($"{AppSettings.ApiUrl}program");

            var json = JsonConvert.DeserializeObject<List<Program>>(response);
            return json;
        }

    }

    public static class TokeValidator
    {
        public static async Task CheckTokenValidity()
        {
            var expirationTime = Preferences.Get("tokenExpirationTime", 0);
            Preferences.Set("currentTime", UnixTime.GetCurrentTime());
            var currentTime = Preferences.Get("currentTime", 0);
            if (expirationTime < currentTime)
            {
                var email = Preferences.Get("email", string.Empty);
                var password = Preferences.Get("password", string.Empty);
                var response = await ApiService.Login(email, password);
            }
        }
    }
}
