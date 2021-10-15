using Gestore.ClientAPI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Gestore.ClientAPI
{
    public class MainMenu
    {
        static HttpClient client = new HttpClient();
        internal static void Start()
        {
            bool quit = false;
            char choice;
            do
            {
                Console.WriteLine("\nSeleziona un'opzione del seguente menu:" +
                        "\n[ 1 ] - Inserisci un nuovo ordine" +
                        "\n[ 2 ] - Elimina un ordine" +
                        "\n[ 3 ] - Modifica dati di un ordine" +
                        "\n[ 4 ] - Visualizza tutti gli ordini" +
                        "\n[ q ] - ESCI");

                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        AddCustomer();
                        break;
                    case '2':
                        DeleteCustomer();
                        break;
                    case '3':
                        UpdateCustomer();
                        break;
                    case '4':
                        FetchCustomer();
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Scelta sconosciuta.");
                        break;
                }

            } while (!quit);
        }

        private static void FetchCustomer()
        {
            Console.Clear();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44386/api/Order")
            };

            var response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
               

                var data = JsonConvert.DeserializeObject<List<OrderContract>>(jsonResponse);

                foreach (OrderContract order in data)
                    Console.WriteLine($"{order.Id} - Data: {order.OrderDate} - Codice Ordine: {order.OrderCode} - Codice Prodotto: {order.ProductCode} - Importo: {order.Amount} - IdCliente: {order.CustomerId}");
            }

        }

        private static void UpdateCustomer()
        {
            Console.Clear();
            FetchCustomer();


            Console.WriteLine("\nInserire id dell'ordine da modificare");
            int.TryParse(Console.ReadLine(), out int id);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:44386/api/Order/{id}")
            };

            DateTime orderDate;
            string orderCode;
            string productCode;
            decimal amount;
            int customerId;

            do
            {
                Console.Write("Importo: ");
            } while (!DateTime.TryParse(Console.ReadLine(), out orderDate));

            do
            {
                Console.Write("Codice Ordine: ");
                orderCode = Console.ReadLine();
            } while (string.IsNullOrEmpty(orderCode));

            do
            {
                Console.Write("Codice Prodotto: ");
                productCode = Console.ReadLine();
            } while (string.IsNullOrEmpty(productCode));


            do
            {
                Console.Write("Importo: ");
            } while (!decimal.TryParse(Console.ReadLine(), out amount));

            do
            {
                Console.Write("ID Cliente: ");
            } while (!int.TryParse(Console.ReadLine(), out customerId));

            OrderContract updatedOrder = new OrderContract
            {
                OrderCode = orderCode,
                ProductCode = productCode,
                OrderDate = orderDate,
                Amount = amount,
                CustomerId = customerId
            };


            string updateOrderJson = JsonConvert.SerializeObject(updatedOrder);
            request.Content = new StringContent(    
                updateOrderJson,
                Encoding.UTF8,
                "application/json"
            );

            var postResponse = client.SendAsync(request).Result;

            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = postResponse.Content.ReadAsStringAsync().Result;
                var order = JsonConvert.DeserializeObject<OrderContract>(data);

                Console.WriteLine($"Ordine modificato con successo");
            }


        }

        private static void DeleteCustomer()
        {
            Console.Clear();
            FetchCustomer();
            Console.WriteLine("\nInserire id dell'ordine da cancellare");
            int.TryParse(Console.ReadLine(), out int id);

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:44386/api/Order" + "/" + id)
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Ordine cancellato");
            }
            else
            {
                Console.WriteLine("L'ordine non può essere cancellato");
            }
        }

        private static void AddCustomer()
        {
            Console.Clear();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://localhost:44386/api/Order")
            };

            string orderCode;
            string productCode;
            decimal amount;
            int customerId;


            do
            {
                Console.Write("Codice Ordine: ");
                orderCode = Console.ReadLine();
            } while (string.IsNullOrEmpty(orderCode));

            do
            {
                Console.Write("Codice Prodotto: ");
                productCode = Console.ReadLine();
            } while (string.IsNullOrEmpty(productCode));


            do
            {
                Console.Write("Importo: ");
            } while (!decimal.TryParse(Console.ReadLine(), out amount));

            do
            {
                Console.Write("ID Cliente: ");
            } while (!int.TryParse(Console.ReadLine(), out customerId));

            OrderContract newOrder = new OrderContract
            {
                OrderCode = orderCode,
                ProductCode = productCode,
                OrderDate = DateTime.Now,
                Amount = amount,
                CustomerId = customerId
            };

            string newOrderJson = JsonConvert.SerializeObject(newOrder);
            request.Content = new StringContent(
                newOrderJson,
                Encoding.UTF8,
                "application/json" 
            );

            var postResponse = client.SendAsync(request).Result;
          
            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = postResponse.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<OrderContract>(data);

                Console.WriteLine($"Ordine aggiunto con ID = {result.Id}");
            }


        }
    }
    }

