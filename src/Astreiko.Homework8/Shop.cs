using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Astreiko.Homework8
{
    internal class Shop
    {
        /// <summary>
        /// Generate properties customs
        /// </summary>
        private PeopleGenerator PeopleGenerator { get; set; }

        /// <summary>
        /// Queue of customers into cashiers
        /// </summary>
        private Queue<Person> ProcessingQueue { get; set; }

        /// <summary>
        /// List class Cashier
        /// </summary>
        private List<Cashier> ListCashiers { get; set; }

        /// <summary>
        /// Flag open/close shop
        /// </summary>
        private bool IsOpen { get; set; }

        /// <summary>
        /// Generate to create customers
        /// </summary>
        private Random RandomCustomers { get; set; }

        /// <summary>
        /// The maximum numbers of customers that came at time
        /// </summary>
        private int MaxCountCustomers { get; set; }

        /// <summary>
        /// Generate come of customers
        /// </summary>
        private Random RandomCreateCustomers { get; set; }

        /// <summary>
        /// Timespan for check customers waiting the free cashier
        /// </summary>
        private int CheckPeriodQueue { get; set; }

        /// <summary>
        /// Maximum number of cashiers at same time
        /// </summary>
        private int MaxCountCashier { get; set; }

        /// <summary>
        /// Flag open/close any cashier
        /// </summary>
        private bool NeedCloseCashier { get; set; }

        /// <summary>
        /// Numbers of cashiers that working same time when the shop opened
        /// </summary>
        private int CountCashierDefault { get; set; }

        /// <summary>
        /// Propetry for using functionality lock
        /// </summary>
        private readonly object _locker = new object();

        public Shop()
        {
            PeopleGenerator = new PeopleGenerator();
            ProcessingQueue = new Queue<Person>();
            RandomCustomers = new Random();
            RandomCreateCustomers = new Random();
            MaxCountCustomers = 25;
            CheckPeriodQueue = 5000;
            NeedCloseCashier = false;
            MaxCountCashier = 10;
            CountCashierDefault = 3;

            var listCashiers = new List<Cashier>();

            for (var i = 0; i < CountCashierDefault; i++)
            {
                var nCashier = new Cashier {ThreadCashier = new Thread(ProcessPeople), NameCashier = $"Cashier {i + 1}"};

                listCashiers.Add(nCashier);
            }
            ListCashiers = listCashiers;
        }

        /// <summary>
        /// Open shop
        /// </summary>
        internal void OpenShop()
        {
            Console.WriteLine("Shop is opening...");
            IsOpen = true;

            for (var i = 1; i <= ListCashiers.Count; i++)
            {
                ListCashiers[i - 1].ThreadCashier.Start(i);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{ListCashiers[i - 1].NameCashier} is opened.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Close shop
        /// </summary>
        internal void CloseShop()
        {
            IsOpen = false;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The shop is closing...");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Generator creates new customers  
        /// </summary>
        internal void StartVisitorsGenerator()
        {
            while (IsOpen)
            {
                GeneratorVisitors();

                Thread.Sleep(RandomCreateCustomers.Next(10000, 15000));
            }
        }

        /// <summary>
        /// Check count customers waiting the free cashier
        /// </summary>
        internal void CheckWaitingVisitors()
        {
            while (IsOpen)
            {
                Thread.Sleep(CheckPeriodQueue);

                var countCustomersWaiting = ProcessingQueue.Count;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{countCustomersWaiting} customers are waiting the free cashier (Check every {CheckPeriodQueue} ms).");
                Console.ResetColor();
                Console.WriteLine();

                if (countCustomersWaiting > 30 && MaxCountCashier >= ListCashiers.Count(x => x.ThreadCashier.IsAlive))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("There are many customers, need to open new cashier!");
                    Console.ResetColor();

                    OpenCashier();

                    Thread.Sleep(CheckPeriodQueue * 3); //Waiting results work additional cashier
                }
                else if (countCustomersWaiting < 5 && ListCashiers.Count(x => x.ThreadCashier.IsAlive) > 3)
                {
                    NeedCloseCashier = true;
                }

                if (countCustomersWaiting > 99)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("ALARM. NEED MORE CASHIERS!");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// OpenShop of additional cashier
        /// </summary>
        internal void OpenCashier()
        {
            var stopedCashiers = ListCashiers.Where(x => x.ThreadCashier.IsAlive == false).Select(q => q.NameCashier).Distinct().ToList();
            var runCashiers = ListCashiers.Where(x => x.ThreadCashier.IsAlive).Select(q => q.NameCashier).ToList();
            var freeCashiersList = stopedCashiers.Except(runCashiers).ToList();

            var nCashier = new Cashier
            {
                ThreadCashier = new Thread(ProcessPeople),
                NameCashier = freeCashiersList.Count == 0 ? $"Cashier {ListCashiers.Count + 1}" : freeCashiersList.First()
            };

            ListCashiers.Add(nCashier);
            ListCashiers[ListCashiers.Count - 1].ThreadCashier.Start(ListCashiers.Count);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{ListCashiers[ListCashiers.Count - 1].NameCashier} is opened.");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Generator new customers in the shop 
        /// </summary>
        internal void GeneratorVisitors()
        {
            var randomV = RandomCustomers.Next(0, MaxCountCustomers);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{randomV} customers are visiting the shop (Maximum number of customers - {MaxCountCustomers}).");
            Console.ResetColor();
            Console.WriteLine();

            for (var i = 0; i < randomV; i++)
            {
                AddVisitorsToWaitingQueue();
            }
        }

        /// <summary>
        /// Add visitors to waiting queue
        /// </summary>
        internal void AddVisitorsToWaitingQueue()
        {
            ProcessingQueue.Enqueue(PeopleGenerator.GetPerson());
        }

        /// <summary>
        /// Visitor service
        /// </summary>
        /// <param name="obj"></param>
        private void ProcessPeople(object obj)
        {
            while (IsOpen && !NeedCloseCashier)
            {
                while (ProcessingQueue.Count > 0)
                {
                    bool resDequeue;
                    Person person;

                    lock (_locker)
                    {
                        resDequeue = ProcessingQueue.TryDequeue(out person);
                    }

                    if (resDequeue)
                    {
                        Console.WriteLine(
                            $"{ListCashiers[(int) obj - 1].NameCashier} is processing {person.Name}...");
                        Thread.Sleep(person.TimeToProcess);
                        Console.WriteLine($"{ListCashiers[(int) obj - 1].NameCashier} is processed {person.Name}.");
                    }
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"There are a few customers, need to close any cashier!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{ListCashiers[(int)obj - 1].NameCashier} is closed.");
            Console.ResetColor();
            NeedCloseCashier = false;
        }
    }
}