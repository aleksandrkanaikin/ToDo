using System;
using System.Net.Http;

namespace Desktop
{
    public abstract class TodoHttpClient
    {
        private readonly Uri _baseUri; // Поле для хранения Uri
        protected TodoHttpClient()
        {
            _baseUri = new Uri("http://45.144.64.179/");
        }
        protected HttpClient GetHttpClient() // Создание клиента
        {
            var client = new HttpClient();
            client.BaseAddress = _baseUri;
            return client;
        }
    }
}