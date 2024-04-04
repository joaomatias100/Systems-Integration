using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HTTPIntegration
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "e4c968291e48a01cbb027ceb61c966dde7b105a98a622d3a47dafe10fb5092ff");
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage message = null;

                Console.WriteLine("Pick an option: \n");
                Console.WriteLine("1 - Get all users: \n");
                Console.WriteLine("2 - Get one user: \n");
                Console.WriteLine("3 - Post an user: \n");
                Console.WriteLine("4 - Delete an user: \n");
                Console.WriteLine("5 - Update an user: \n");

                string operation = Console.ReadLine();

                switch (operation)
                {
                    case "1":
                        Console.Clear();

                        message = client.GetAsync("https://gorest.co.in/public/v2/users").Result;

                        if (message.IsSuccessStatusCode)
                        {
                            var results = message.Content.ReadAsStringAsync().Result;
                            Console.WriteLine("Raw result: " + results);
                        }
                        else
                        {
                            Console.WriteLine("Unexpected status code: " + message.StatusCode);
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine("Insert user ID: ");
                        string _id = Console.ReadLine();
                        string userUrl = "https://gorest.co.in/public/v2/users/" + _id;
                        message = client.GetAsync(userUrl).Result;

                        Console.WriteLine("Requesting URL: " + userUrl);
                        Console.WriteLine("Statuc code: " + message.ToString());

                        if(message.IsSuccessStatusCode)
                        {
                            var results = message.Content.ReadAsStringAsync().Result;
                            Console.WriteLine("Raw result: " + results);
                        }
                        else if(message.StatusCode == HttpStatusCode.NotFound)
                        {
                            Console.WriteLine("User not found");
                        }
                        else
                        {
                            Console.WriteLine("Unexpected status code: " + message.StatusCode);
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Email: ");
                        string _email = Console.ReadLine();
                        Console.WriteLine("Name: ");
                        string _name = Console.ReadLine();
                        Console.WriteLine("Gender: ");
                        string _gender = Console.ReadLine();
                        Console.WriteLine("Status: ");
                        string _status = Console.ReadLine();

                        var newUser = new
                        {
                            email = _email,
                            name = _name,
                            gender = _gender,
                            status = _status
                        };

                        await PostAsync("https://gorest.co.in/public/v2/users/", newUser, client);
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("Insert id: ");
                        string id = Console.ReadLine();
                        string deletedUserUrl = "https://gorest.co.in/public/v2/users/" + id;

                        await DeleteAsync(deletedUserUrl, client);
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("Insert id: ");
                        string idUpdate = Console.ReadLine();
                        string updatedUserUrl = "https://gorest.co.in/public/v2/users/" + idUpdate;

                        Console.WriteLine("Email: ");
                        string _email_ = Console.ReadLine();
                        Console.WriteLine("Name: ");
                        string _name_ = Console.ReadLine();
                        Console.WriteLine("Gender: ");
                        string _gender_ = Console.ReadLine();
                        Console.WriteLine("Status: ");
                        string _status_ = Console.ReadLine();

                        var updateUser = new
                        {
                            email = _email_,
                            name = _name_,
                            gender = _gender_,
                            status = _status_
                        };

                        await PutAsync(updatedUserUrl, updateUser, client);
                        break;
                }
            }
        }

        private static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("https://gorest.co.in/public/v2/users"),
        };

        static async Task GetAsync (HttpClient httpClient)
        {
            HttpResponseMessage response = await httpClient.GetAsync("all/3");
            response.EnsureSuccessStatusCode();
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"{jsonResponse}\n");
        }

        static async Task PostAsync(String url, object data, HttpClient httpClient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("User created");
                    Console.WriteLine("Result: " + result);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static async Task DeleteAsync(string url, HttpClient httpClient)
        {
            try
            {
                var response = await httpClient.DeleteAsync(url);

                if(response.IsSuccessStatusCode)
                {
                    Console.WriteLine("User deleted");
                }
                else
                {
                    Console.WriteLine("Error deleting user: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        static async Task PutAsync(string url, object data, HttpClient httpClient)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("User uploaded");
                    Console.WriteLine("Result: " + result);
                }
                else
                {
                    Console.WriteLine("Error updating user: " + response.StatusCode);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }

    internal static class HttpResponseMessageExtensions
    {
        internal static void WriteRequestToConsole(this HttpResponseMessage response)
        {
            if(response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            Console.WriteLine($"{request?.Method}");
            Console.WriteLine($"{request?.RequestUri}");
            Console.WriteLine($"HTTP/{request?.Version}");
        }
    }
}
