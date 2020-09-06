using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using quickfitgym.Models;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using UnixTimeStamp;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace quickfitgym.Services
{
    public static class ApiService
    {
        public static async Task<bool> Register(Register Model)
        {
            try
            {
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(Model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"{AppSettings.ApiUrl}accounts/create", content);
                var jsonresult = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<RegisterSuccess>(jsonresult);
                    var str = "Registration successful, please confirm your email to continue";
                    await Application.Current.MainPage.DisplayAlert("Success",  str, "OK");
                    return true;
                }
                else
                {
                    var result = JsonConvert.DeserializeObject<SuccessReturn>(jsonresult);
                    await Application.Current.MainPage.DisplayAlert("Error", result.Message, "CANCEL");
                }
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return false;
        }


        public static async Task<bool> Login(string UserName, string Password)
        {
            try
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
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
           
            return false;
        }


        public static async Task<bool> UpdateAboutUs(AboutUs aboutUs)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(aboutUs);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}admin/aboutus/update"), content);
                if (!response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SuccessReturn>(jsonresult);
                    await Application.Current.MainPage.DisplayAlert("Error", result.Message, "CANCEL");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return false;
        }



        public static async Task<List<Role>> GetRoles()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var response = await client.GetStringAsync($"{AppSettings.ApiUrl}roles");

                var json = JsonConvert.DeserializeObject<List<Role>>(response);
                return json;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return null;
        }


        public static async Task<AboutUs> GetAboutUs()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var response = await client.GetStringAsync($"{AppSettings.ApiUrl}admin/aboutus");

                var json = JsonConvert.DeserializeObject<AboutUs>(response);
                return json;
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return null;
        }

        
        public static async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var response = await client.GetStringAsync($"{AppSettings.ApiUrl}customers/getall");

                var json = JsonConvert.DeserializeObject<List<Customer>>(response);
                return json;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return null;
        }

        public static async Task<bool> UpdateProfilePict(ProfilePict profile)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(profile);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}customers/updateprofilepict"), content);
                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Photo saved successfully", "OK");
                    return true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Unable to save Photo", "CANCEL");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return false;
        }

        public static async Task<bool> UpdateCoverPict(CoverPict cover)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(cover);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}customers/updatecoverpict"), content);
                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Photo saved successfully", "OK");
                    return true;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Unable to save Photo", "CANCEL");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return false;
        }

        public static async Task<List<Members>> GetMembers()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var response = await client.GetStringAsync($"{AppSettings.ApiUrl}accounts/users");

                var json = JsonConvert.DeserializeObject<List<Members>>(response);
                return json;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return null;
        }

        public static async Task<List<Program>> GetPrograms()
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new
                    System.Net.Http.Headers.AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var response = await client.GetStringAsync($"{AppSettings.ApiUrl}program");

                var json = JsonConvert.DeserializeObject<List<Program>>(response);
                return json;
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return null;
        }

        public static async Task<AddProgramResult> AddProgram(Program program)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(program);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}program/CreateProgram"), content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AddProgramResult>(jsonresult);
                    return result;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Unable to add program", "CANCEL");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return null;
        }

        public static async Task<AddProgramResult> EditProgram(Program program)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(program);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}program/UpdateProgram"), content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<AddProgramResult>(jsonresult);
                    return result;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Unable to save program", "CANCEL");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return null;
        }

        public static async Task<bool> DeleteProgram(Program program)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(program);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}program/RemoveProgram"), content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SuccessReturn>(jsonresult);
                    await Application.Current.MainPage.DisplayAlert("Success", result.Message, "OK");
                    return true;
                }
                else
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SuccessReturn>(jsonresult);
                    await Application.Current.MainPage.DisplayAlert("Error", result.Message, "CANCEL");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return false;
        }

        public static async Task<bool> JoinProgram(JoinProgram program)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(program);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}program/JoinProgram"), content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SuccessReturn>(jsonresult);
                    await Application.Current.MainPage.DisplayAlert("Success", result.Message, "OK");
                    return true;
                }
                else
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SuccessReturn>(jsonresult);
                    await Application.Current.MainPage.DisplayAlert("Error", result.Message, "CANCEL");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return false;
        }
        
        public static async Task<bool> CreateSchedule(ProgramSchedule schedule)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", Preferences.Get("token", string.Empty));
                var json = JsonConvert.SerializeObject(schedule);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(new Uri($"{AppSettings.ApiUrl}schedule/create"), content);
                if (!response.IsSuccessStatusCode)
                {
                    var jsonresult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SuccessReturn>(jsonresult);
                    await Application.Current.MainPage.DisplayAlert("Error", result.Message, "CANCEL");
                    return false;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Success", "Schedule created successfully ", "OK");
                }
                return true;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "CANCEL");
            }
            return false;
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
