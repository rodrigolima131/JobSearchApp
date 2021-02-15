using JobSearch.Domain.Models;
using NewJobSearch.App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewJobSearch.App.Services
{
    public class UserService : Service
    {
        public async Task<ResponseService<User>> GetUser(string email, string password)
        {
            HttpResponseMessage response = await _client.GetAsync($"{BaseApiUrl}/api/Users?email={email}&password={password}");
            User user = null;

            ResponseService<User> responseService = new ResponseService<User>();
            responseService.IsSuccess = response.IsSuccessStatusCode;
            responseService.StatusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {


                //deserializar
                responseService.Data = await response.Content.ReadAsAsync<User>();
            }
            else
            {
                string problemResponse = await response.Content.ReadAsStringAsync();
               var errors = JsonConvert.DeserializeObject<ResponseService<User>>(problemResponse);
                responseService.Errors = errors.Errors;
            }
            return responseService;
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
