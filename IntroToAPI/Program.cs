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

                foreach (string vehicleURL in personResponse.vehicles)
                {
                    HttpResponseMessage vehicleResponse = httpClient.GetAsync(vehicleURL).Result;
                    Console.WriteLine(vehicleResponse.Content.ReadAsStringAsync().Result);
                    Vehicle vehicle = vehicleResponse.Content.ReadAsAsync<Vehicle>().Result;
                    Console.WriteLine(vehicle.Name);
                }
            }

            SWAPIService swapiService = new SWAPIService();
            for(int i=1; i <= 10;i++)
            {
                Person personOne = swapiService.GetPersonAsync($"https://swapi.dev/api/people/{i}").Result;

                if (personOne != null)
                {
                    Console.Clear();
                    Console.WriteLine($"The character that has been entered is: {personOne.name}");
                    foreach (string vehicleUrl in personOne.vehicles)
                    {
                        var vehicle = swapiService.GetVehicleAsync(vehicleUrl).Result;
                        Console.WriteLine($"They drive a {vehicle.Name}");
                    }
                    Console.ReadKey();
                }
            }

            var genericResponse = swapiService.GetAsyncGeneric<Vehicle>("https://swapi.dev/api/vehicles/4").Result;
            Console.WriteLine(genericResponse.CargoCapacity);
            Console.WriteLine(genericResponse.Name);

            SearchResult<Person> skywalkers = swapiService.GetPersonSearchAsync("skywalker").Result;
            foreach(Person person in skywalkers.Results)
            {
                Console.WriteLine(person.name);
            }

        }
    }
}
