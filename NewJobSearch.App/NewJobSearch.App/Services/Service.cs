using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NewJobSearch.App.Services
{
   public abstract class Service
    {
        protected HttpClient _client;
        protected string BaseApiUrl = "https://xamarinjobsearch2021api.azurewebsites.net/";


        public Service()
        {
            _client = new HttpClient();
        }
    }
}
