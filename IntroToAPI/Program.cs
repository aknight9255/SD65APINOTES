using IntroToAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IntroToAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://swapi.dev/api/people/1/").Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Person personResponse = response.Content.ReadAsAsync<Person>().Result;
                Console.WriteLine(personResponse.name);

                foreach(string vehicleURL in personResponse.vehicles)
                {
                    HttpResponseMessage vehicleResponse = httpClient.GetAsync(vehicleURL).Result;
                    Console.WriteLine(vehicleResponse.Content.ReadAsStringAsync().Result);
                    Vehicle vehicle = vehicleResponse.Content.ReadAsAsync<Vehicle>().Result;
                    Console.WriteLine(vehicle.Name);

                }
            }

        }
    }
}
