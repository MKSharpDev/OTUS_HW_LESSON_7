using System;
using System.Threading.Tasks;
using WebApi.Controllers;
using System.Text.Json;
using WebApi.Models;
using System.Text.Json.Serialization;
using System.Text;

namespace WebClient
{
    static class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("Что будем делать? Для помощи набери help ");

            bool exit = false;

            while (!exit)
            {
                string command =  Console.ReadLine().ToString();
                switch (command)
                {
                    case ("getall"):
                        {
                            using var client = new HttpClient();
                            {
                                using var result = client.GetAsync("https://localhost:7178/api/Customer").Result;

                                string resultseBody = result.Content.ReadAsStringAsync().Result;

                                List<Customer> customerList = JsonSerializer.Deserialize<List<Customer>>(resultseBody);

                                foreach (var item in customerList)
                                {
                                    Console.WriteLine($"{item.id} {item.firstname} {item.lastname}");
                                }
                            }
                        }
                        break;
                    case ("get"):
                        {
                            Console.WriteLine("Напишите Id пользователя");
                            string id = Console.ReadLine().ToString();
                            using var client = new HttpClient();
                            {
                                using var result = client.GetAsync($"https://localhost:7178/api/Customer/{id}").Result;
                                if (result.StatusCode.ToString() == "OK")
                                {
                                    string resultseBody = result.Content.ReadAsStringAsync().Result;

                                    Customer customer = JsonSerializer.Deserialize<Customer>(resultseBody);
                                    Console.WriteLine($"{customer.id} {customer.firstname} {customer.lastname}");
                                }
                                else
                                {
                                    Console.WriteLine(result.StatusCode);
                                }                               
                            }
                        }
                        break;
                    case ("in"):
                        {
                            try
                            {
                                Console.WriteLine("Напишите Id пользователя");

                                long id = long.Parse(Console.ReadLine());
                                Console.WriteLine("Напишите firstName пользователя");
                                string firstName = Console.ReadLine();
                                Console.WriteLine("Напишите lastName пользователя");
                                string lastName = Console.ReadLine();


                                CustomerCreateRequest innCustomer = new CustomerCreateRequest(id, firstName, lastName);
                                var jsonResult = JsonSerializer.Serialize(innCustomer);

                                var content = new StringContent(jsonResult, Encoding.UTF8, "application/json");
                                HttpClient client = new HttpClient();
                                var response =  client.PostAsync("https://localhost:7178/api/Customer", content);
                                Console.WriteLine(response.Result.ToString());

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                break;
                            }                           
                        }
                        break;
                    case ("exit"):
                        exit = true;
                        break;
                    case ("help"):                    
                        Console.WriteLine("Выход - exit ; Найти по ID  -  get; Список всех -  getall; добавить  - in");
                        break;               
                    default:
                        Console.WriteLine("Низвестная команда, для подсказки набери  help ");
                        break;
                }

            }
        }

        private static CustomerCreateRequest RandomCustomer()
        {
            throw new NotImplementedException();
        }


    }

}