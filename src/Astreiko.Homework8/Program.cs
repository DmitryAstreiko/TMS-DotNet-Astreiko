using System;
using System.Threading;

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

                Thread threadGenVisitors = new Thread(shop.StartVisitorsGenerator);
                threadGenVisitors.Start();

                new Thread(shop.CheckWaitingVisitors).Start();

                while (true)
                {
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
        }
    }
}
