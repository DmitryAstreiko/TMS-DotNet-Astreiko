using System;
using System.Threading;
using System.Threading.Tasks;

namespace Astreiko.Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var shop = new Shop();

                shop.OpenShop();

                //shop.StartVisitorsGenerator();

                //shop.CheckQueueCustomers();

                //Thread threadGenVisitors = new Thread(shop.StartVisitorsGenerator);
                //threadGenVisitors.Start();

                //new Thread(shop.CheckQueueCustomers).Start();

                while (true)
                {
                    //Task.Run(shop.CheckQueueCustomers); ;

                    var thread = new Thread(shop.CheckQueueCustomers);
                    thread.Start();
                    thread.IsBackground = false;

                    new Thread(shop.StartVisitorsGenerator).Start();

                    Console.WriteLine();

                    var command = Console.ReadLine();

                    switch (command)
                    {
                        case "c":
                            shop.CloseShop();
                            return;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception! {ex.Message}, {ex.StackTrace}.");
            }

            Console.ReadKey();
        }
    }
}
