using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Entities;

namespace Desktop.Repository
{
    public class Repository : TodoHttpClient
    {
        private readonly HttpClient _httpClient;
        public Repository()
        {
            _httpClient = GetHttpClient();
        }
        
        public async Task<List<TaskModel>> GetTodosAsync()
        {
            var token =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiOWVhMDgyYzctOGZhNy00YWVhLTg2Y2MtODllNWM3OTdjNTdmIiwibmJmIjoxNjg1MDg3NTQ1LCJleHAiOjE2ODUzMDM1NDUsImlzcyI6Ik15QXV0aFNlcnZlciIsImF1ZCI6Ik15QXV0aENsaWVudCJ9.HeQVLxPdI_colXmJ0QIBhQXmfhXWUJrVf5BAkusDQsY";
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await
                _httpClient.GetFromJsonAsync<List<TaskModel>>("api/todos");
        }

        public async Task Login(LoginUser loginUser)
        {
            //var response = await _httpClient.PostAsJsonAsync<TokenModel>("api/auth/login",
                //new LoginUser {Email = "alex123@gmail.com", Password = "123456789"});
            
            var response = await _httpClient.PostAsJsonAsync("api/auth/login" ,loginUser);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                TokenStorage.Value = response.Content.ReadAsAsync<TokenModel>().Result.access_token;
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