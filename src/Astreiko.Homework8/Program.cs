using System;
using System.Threading;

namespace Astreiko.Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop(); 

            shop.Open();

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
                        shop.Close();
                        return;
                }
            }
        }
    }
}
