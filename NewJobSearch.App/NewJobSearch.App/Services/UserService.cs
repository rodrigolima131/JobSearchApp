using JobSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewJobSearch.App.Services
{
    public class UserService : Service
    {
        public async Task<User> GetUser(string email, string password)
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseApiUrl}/api/Users?email={email}&password={password}");
            User user = null;
            if (response.IsSuccessStatusCode)
            {
                //deserializar
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

        public async Task<User> AddUser(User user)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"{BaseApiUrl}/api/Users/", user);

            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            else {
                user = null;
            }
            return user;

        }
    }
}
