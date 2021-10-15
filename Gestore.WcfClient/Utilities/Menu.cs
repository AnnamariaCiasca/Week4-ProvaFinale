using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestore.WcfClient.Utilities
{
    class Menu
    {
        public static void Start()
        {
            bool quit = false;
            char choice;
            do
            {
                Console.WriteLine("\nSeleziona un'opzione del seguente menu:" +
                        "\n[ 1 ] - Inserisci un nuovo cliente" +
                        "\n[ 2 ] - Elimina un cliente" +
                        "\n[ 3 ] - Modifica dati di un cliente" +
                        "\n[ 4 ] - Visualizza tutti i clienti" +
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
            CustomerReference.CustomerServiceClient client = new CustomerReference.CustomerServiceClient();

            var customers = client.FetchAllCustomers();

            if(customers.Count != 0)
            {
                Console.WriteLine("Ecco l'elenco dei clienti: ");
                foreach(var c in customers)
                {
                    Console.WriteLine($"{c.Id} - {c.CustomerCode} - {c.FirstName} {c.LastName}");
                }
             }
            else
            {
                Console.WriteLine("Elenco vuoto");
            }
        
        }

        private static void UpdateCustomer()
        {
            Console.Clear();
            CustomerReference.CustomerServiceClient client = new CustomerReference.CustomerServiceClient();
            FetchCustomer();
            int idCustomerToUpdate;
          
            Console.WriteLine("\nInserire id del cliente da modificare: ");
            while (!int.TryParse(Console.ReadLine(), out idCustomerToUpdate) || idCustomerToUpdate < 0)
            {
                Console.WriteLine("Inserire valore corretto!");
            }

            var customer = client.GetCustomerById(idCustomerToUpdate);

            if(customer == null)
            {
                Console.WriteLine("Cliente non trovato.\n");
            }

            {
                string updatedName;
                string updatedLastName;
                string updatedCode;
                do
                {
                    Console.Write("Inserire nuovo CodiceCliente: ");
                    updatedCode = Console.ReadLine();
                } while (string.IsNullOrEmpty(updatedCode));

                do
                {
                    Console.Write("\nInserire nuovo Nome: ");
                    updatedName = Console.ReadLine();
                } while (string.IsNullOrEmpty(updatedName));

                do
                {
                    Console.Write("\nInserire nuovo Cognome: ");
                    updatedLastName = Console.ReadLine();
                } while (string.IsNullOrEmpty(updatedLastName));

                var updatedCustomer = new CustomerReference.Customer
                {  
                    Id = idCustomerToUpdate,
                    CustomerCode = updatedCode,
                    FirstName = updatedName,
                    LastName = updatedLastName

                };

                var isUpdated = client.UpdateCustomer(updatedCustomer);

                if (isUpdated)
                {
                    Console.WriteLine("Cliente modificato correttamente\n");
                }
                else
                {
                    Console.WriteLine("Il cliente non può essere modificato.\n");
                }
            }
        }

        private static void DeleteCustomer()
        {
            Console.Clear();
            CustomerReference.CustomerServiceClient client = new CustomerReference.CustomerServiceClient();
            FetchCustomer();
            int idCustomerToDelete;
            Console.WriteLine("\nInserire id del cliente da eliminare: ");
            while (!int.TryParse(Console.ReadLine(), out idCustomerToDelete) || idCustomerToDelete < 0)
            {
                Console.WriteLine("Inserire valore corretto!");
            }

            var customer = client.GetCustomerById(idCustomerToDelete);
            if (customer == null)
            {
                Console.WriteLine("Cliente non trovato");
            }
            else
            {
                var isDeleted = client.DeleteCustomerById(idCustomerToDelete);

                if (isDeleted)
                {
                    Console.WriteLine("Cliente eliminato correttamente.\n");
                }
                else
                {
                    Console.WriteLine("Non è stato possibile eliminare il cliente selezionato.\n");
                }
            }
        }

        private static void AddCustomer()
        {
            Console.Clear();
     
            CustomerReference.CustomerServiceClient client = new CustomerReference.CustomerServiceClient();
            string name;
            string lastName;
            string code;
            do
            {
                Console.Write("Inserire CodiceCliente: ");
                code = Console.ReadLine();
            } while (string.IsNullOrEmpty(code));

            do
            {
                Console.Write("\nInserire Nome: ");
                name = Console.ReadLine();
            } while (string.IsNullOrEmpty(name));

            do
            {
                Console.Write("\nInserire Cognome: ");
                lastName = Console.ReadLine();
            } while (string.IsNullOrEmpty(lastName));

          

            var newCustomer = new CustomerReference.Customer
            {
                CustomerCode = code,
                FirstName = name,
                LastName = lastName

            };

            var isAdded = client.CreateCustomer(newCustomer);

            if (isAdded)
            {
                Console.WriteLine("Cliente creato correttamente.\n");
            }
            else
            {
                Console.WriteLine("Il cliente non può essere creato.\n");
            }
        }
    }
}
