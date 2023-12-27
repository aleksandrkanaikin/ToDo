using Desktop.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;

namespace Desktop.Services
{
    internal class ApiService
    {
        private const string url = "http://45.144.64.179/api/";
        public static string Token = "";
        public static List<TaskModel> Tasks = new List<TaskModel>();

        public static async Task<bool> RegistrationAsync(UserModel user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var client = new HttpClient();

            var response = await client.PostAsync(url + "auth/registration", data);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(result);
                Token = obj["access_token"].ToString();
                return true;
            }

            return false;

        }

        public static async Task<bool> LogInAsync(UserModel user)
        {

            JObject json = new JObject();
            json["Email"] = user.email;
            json["password"] = user.password;
            var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var client = new HttpClient();

            var response = await client.PostAsync(url + "auth/login", data);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                JObject obj = JObject.Parse(result);
                Token = obj["access_token"].ToString();
                return true;
            }

            return false;
        }

        public static async Task<bool> CreateTask(TaskModel task)
        {
            JObject json = new JObject();
            int hourse = Convert.ToInt32(task.Time.Split(':')[0]);
            task.Date = task.Date.Value.AddHours(hourse);
            int minutus = Convert.ToInt32(task.Time.Split(':')[1]);
            task.Date = task.Date.Value.AddMinutes(minutus);

            long time = task.Date.Value.Ticks;
            json["Category"] = task.Category;
            json["Title"] = task.Title;
            json["Description"] = task.Content;
            json["Date"] = time;

            var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var response = await client.PostAsync(url + "todos", data);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;

        }

        public static void GetTasks()
        {

            var httpRequests = new WebClient();
            httpRequests.Headers.Add("Accept", "application/json");
            httpRequests.Headers.Add("Authorization", "Bearer "+ Token);
            var data = httpRequests.DownloadData(url + "todos");

           
            string output = Encoding.UTF8.GetString(data);
            JArray tasks = JArray.Parse(output);
            
            
            List<TaskModel> tasks1 = new List<TaskModel>();
            Console.WriteLine(tasks);
            foreach (var task in tasks)
            {
                var date = new DateTime(Convert.ToInt64(task["date"].ToString()));
                var hourse = date.Hour;
                var minute = date.Minute;
                string time = hourse + ":" + minute;
                var category = task["category"].ToString();
                var id = new Guid((string)task["id"]);
                var title = task["title"].ToString();
                var t = new TaskModel ()
                {
                    Id = id,
                    Category = category,
                    Title = title,
                    Content = task["description"].ToString(),
                    Date = date,
                    IsChecked = Convert.ToBoolean(task["isCompleted"].ToString()),
                    Time = time
                };
                tasks1.Add(t);
            }
            Tasks = tasks1;
        }   

        public static async Task<bool> DeleteTaskAsync(TaskModel task)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var response = await client.DeleteAsync(url + "todos/" + task.Id) ;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                GetTasks();
                return true;
            }

            return false;
        }

        public static async Task<bool> PutTaskAsync(TaskModel task)
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            var response = await client.PutAsync(url + "todos/mark/" + task.Id, null);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                GetTasks();
                return true;
            }

            return false;
        }


    }
}