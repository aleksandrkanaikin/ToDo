using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Entities;
using Entities.Annotations;

namespace Desktop.Repository
{
    public class APIRepository : TodoHttpClient
    {
        private readonly HttpClient _httpClient;
        public APIRepository()
        {
            _httpClient = GetHttpClient();
        }
        
        public async Task<List<TaskModel>> GetTodosAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenStorage.Value);
            var tasks = await _httpClient.GetFromJsonAsync<List<TaskModel>>("api/todos");
            if (tasks != null)
            {
                return tasks;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> Login(LoginUser loginUser)
        {
            //var response = await _httpClient.PostAsJsonAsync<TokenModel>("api/auth/login",
            //new LoginUser {Email = "alex123@gmail.com", Password = "123456789"});

            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginUser);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                TokenStorage.Value = response.Content.ReadAsAsync<TokenModel>().Result.access_token;
                return null;
            }
            else
            {
                return "";
            }
        }

        public async Task<HttpStatusCode> GetSuccessCode(LoginUser loginUser)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login" ,loginUser);
            response.EnsureSuccessStatusCode();
            return response.StatusCode;
        }
    }
}