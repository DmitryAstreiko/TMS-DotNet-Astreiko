using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Astreiko.Homework8
{
    internal class Shop
    {
        /// <summary>
        /// Generate properties customs
        /// </summary>
        private PeopleGenerator peopleGenerator;
        private Queue<Cashier> cashierQueue;
        private Queue<Person> customerQueue;

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
        private bool isOpen;

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

        private List<Task> currentTasks;

        /// <summary>
        /// Propetry for using functionality lock
        /// </summary>
        //private readonly object _locker = new object();

        public Shop()
        {
            //PeopleGenerator = new PeopleGenerator();
            //ProcessingQueue = new Queue<Person>();
            //RandomCustomers = new Random();
            //RandomCreateCustomers = new Random();
            //MaxCountCustomers = 25;
            //CheckPeriodQueue = 5000;
            //NeedCloseCashier = false;
            //MaxCountCashier = 10;
            //CountCashierDefault = 3;

            //var listCashiers = new List<Cashier>();

            //for (var i = 0; i < CountCashierDefault; i++)
            //{
            //    var nCashier = new Cashier {ThreadCashier = new Thread(ProcessPeople), NameCashier = $"Cashier {i + 1}"};

            //    listCashiers.Add(nCashier);
            //}
            //ListCashiers = listCashiers;

            //PeopleGenerator = new PeopleGenerator();
            ProcessingQueue = new Queue<Person>();
            RandomCustomers = new Random();
            RandomCreateCustomers = new Random();
            MaxCountCustomers = 25;
            CheckPeriodQueue = 5000;
            NeedCloseCashier = false;
            MaxCountCashier = 10;
            CountCashierDefault = 3;

            peopleGenerator = new PeopleGenerator();
            cashierQueue = new Queue<Cashier>();
            customerQueue = new Queue<Person>();
            ListCashiers = new List<Cashier>();
            currentTasks = new List<Task>();

            for (var i = 0; i < CountCashierDefault; i++)
            {
                ListCashiers.Add(new Cashier());
            }
            
        }

        /// <summary>
        /// Open shop
        /// </summary>
        internal void OpenShop()
        {
            Console.WriteLine("Shop is opening...");
            isOpen = true;

            //for (var i = 1; i <= ListCashiers.Count; i++)
            //{
            //    ListCashiers[i - 1].ThreadCashier.Start(i);
            //    Console.WriteLine();
            //    Console.ForegroundColor = ConsoleColor.Magenta;
            //    Console.WriteLine($"{ListCashiers[i - 1].NameCashier} is opened.");
            //    Console.ResetColor();
            //    Console.WriteLine();
            //}

            for (var i = 0; i < ListCashiers.Count; i++)
            {
                OpenCashier(ListCashiers[i]);
                //ListCashiers[i - 1].ThreadCashier.Start(i);
                //EnqueueCashier(ListCashiers[i]);
                //Console.WriteLine();
                //Console.ForegroundColor = ConsoleColor.Magenta;
                //Console.WriteLine($"Cachier {ListCashiers[i].NameCashier} is opened.");
                //Console.ResetColor();
                //Console.WriteLine();
            }
        }

        /// <summary>
        /// Close shop
        /// </summary>
        internal void CloseShop()
        {
            isOpen = false;
            Task.WaitAll(currentTasks.ToArray());

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
            while (isOpen)
            {
                Thread.Sleep(RandomCreateCustomers.Next(10000, 15000));

                var countCustomers = RandomCustomers.Next(0, MaxCountCustomers);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{countCustomers} customers are visiting the shop (Maximum number of customers - {MaxCountCustomers}).");
                Console.ResetColor();
                Console.WriteLine();

                for (var i = 0; i < countCustomers; i++)
                {
                    var ttt = peopleGenerator.GetPerson();
                    EnqueueCustomer(ttt);
                    var task = Task.Run(() => ProcessPerson(ttt));
                    currentTasks.Add(task);
                }
            }
        }

        internal void CheckWaitingCustomers()
        {
            var countCustomersWaiting = customerQueue.Count;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(
                $"{countCustomersWaiting} customers are waiting the free cashier (Check every {CheckPeriodQueue} ms).");
            Console.ResetColor();
            Console.WriteLine();

            if (countCustomersWaiting > 30) // && MaxCountCashier >= customerQueue.Count(x => x.ThreadCashier.IsAlive))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("There are many customers, need to open new cashier!");
                Console.ResetColor();

                OpenCashier(new Cashier());

                //    Thread.Sleep(CheckPeriodQueue * 3); //Waiting results work additional cashier
                //}
                //else if (countCustomersWaiting < 5 && ListCashiers.Count(x => x.ThreadCashier.IsAlive) > 3)
                //{
                //    NeedCloseCashier = true;
                //}

                //if (countCustomersWaiting > 99)
                //{
                //    Console.WriteLine();
                //    Console.ForegroundColor = ConsoleColor.Magenta;
                //    Console.WriteLine("ALARM. NEED MORE CASHIERS!");
                //    Console.ResetColor();
                //}
            }
        }

        internal void OpenCashier(Cashier cashier)
        {
            EnqueueCashier(cashier);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Cachier {cashier.NameCashier} is opened.");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Check count customers waiting the free cashier
        /// </summary>
        internal void CheckQueueCustomers()
        {
            while (isOpen)
            {
                Thread.Sleep(CheckPeriodQueue);

                var task = Task.Run(() => CheckWaitingCustomers());
                currentTasks.Add(task);

                //var countCustomersWaiting = ProcessingQueue.Count;

                //Console.WriteLine();
                //Console.ForegroundColor = ConsoleColor.Cyan;
                //Console.WriteLine($"{countCustomersWaiting} customers are waiting the free cashier (Check every {CheckPeriodQueue} ms).");
                //Console.ResetColor();
                //Console.WriteLine();

                //if (countCustomersWaiting > 30 && MaxCountCashier >= ListCashiers.Count(x => x.ThreadCashier.IsAlive))
                //{
                //    Console.WriteLine();
                //    Console.ForegroundColor = ConsoleColor.Magenta;
                //    Console.WriteLine("There are many customers, need to open new cashier!");
                //    Console.ResetColor();

                //    OpenCashier();

                //    Thread.Sleep(CheckPeriodQueue * 3); //Waiting results work additional cashier
                //}
                //else if (countCustomersWaiting < 5 && ListCashiers.Count(x => x.ThreadCashier.IsAlive) > 3)
                //{
                //    NeedCloseCashier = true;
                //}

                //if (countCustomersWaiting > 99)
                //{
                //    Console.WriteLine();
                //    Console.ForegroundColor = ConsoleColor.Magenta;
                //    Console.WriteLine("ALARM. NEED MORE CASHIERS!");
                //    Console.ResetColor();
                //}
            }
        }

        /// <summary>
        /// OpenShop of additional cashier
        /// </summary>
        //internal void OpenCashier()
        //{
        //    var stopedCashiers = ListCashiers.Where(x => x.ThreadCashier.IsAlive == false).Select(q => q.NameCashier).Distinct().ToList();
        //    var runCashiers = ListCashiers.Where(x => x.ThreadCashier.IsAlive).Select(q => q.NameCashier).ToList();
        //    var freeCashiersList = stopedCashiers.Except(runCashiers).ToList();

        //    var nCashier = new Cashier
        //    {
        //        ThreadCashier = new Thread(ProcessPeople),
        //        NameCashier = freeCashiersList.Count == 0 ? $"Cashier {ListCashiers.Count + 1}" : freeCashiersList.First()
        //    };

        //    ListCashiers.Add(nCashier);
        //    ListCashiers[ListCashiers.Count - 1].ThreadCashier.Start(ListCashiers.Count);

        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Magenta;
        //    Console.WriteLine($"{ListCashiers[ListCashiers.Count - 1].NameCashier} is opened.");
        //    Console.ResetColor();
        //    Console.WriteLine();
        //}

        /// <summary>
        /// Generator new customers in the shop 
        /// </summary>
        //internal void GeneratorVisitors()
        //{
        //    var randomV = RandomCustomers.Next(0, MaxCountCustomers);
        //    Console.WriteLine();
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine($"{randomV} customers are visiting the shop (Maximum number of customers - {MaxCountCustomers}).");
        //    Console.ResetColor();
        //    Console.WriteLine();

        //    for (var i = 0; i < randomV; i++)
        //    {
        //        AddVisitorsToWaitingQueue();
        //    }
        //}

        /// <summary>
        /// Add visitors to waiting queue
        /// </summary>
        //internal void AddVisitorsToWaitingQueue()
        //{
        //    ProcessingQueue.Enqueue(PeopleGenerator.GetPerson());
        //}

        //internal void EnterShop()
        //{
        //    if (isOpen)
        //    {
        //        // public delegate void WaitCallback(object state);
        //        var task = Task.Run(() => ProcessPerson(peopleGenerator.GetPerson()));
        //        currentTasks.Add(task);
        //        //task.ContinueWith(t => currentTasks.Remove(task));
        //    }
        //}

        private void ProcessPerson(Person person)
        {
            if (isOpen)
            {
                //Console.WriteLine();
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"Очередь из кассиров {cashierQueue.Count}");
                //Console.ResetColor();
                //Console.WriteLine();

                Cashier cashier;

                while (!TryDequeueCashier(out cashier))
                {
                    Thread.Sleep(100);
                }

                var timeToProcess = cashier.TimeToProcess + person.TimeToProcess;
                Console.WriteLine($"Cashier {cashier.NameCashier} is processing {person.Name} on thread {Thread.CurrentThread.ManagedThreadId}...");
                Thread.Sleep(timeToProcess);

                DequeueCustomer();
                EnqueueCashier(cashier);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Cachier {Thread.CurrentThread.ManagedThreadId} is exitting.");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void EnqueueCashier(Cashier cashier)
        {
            lock (cashierQueue)
            {
                cashierQueue.Enqueue(cashier);
            }
        }

        private void EnqueueCustomer(Person person)
        {
            lock (customerQueue)
            {
                customerQueue.Enqueue(person);
            }
        }

        private bool TryDequeueCashier(out Cashier cashier)
        {
            cashier = null;

            lock (cashierQueue)
            {
                if (cashierQueue.Count > 0)
                {
                    cashier = cashierQueue.Dequeue();
                    return true;
                }
            }
            return false;
        }

        private void DequeueCustomer()
        {
            lock (customerQueue)
            {
                if (customerQueue.Count > 0)
                {
                    customerQueue.Dequeue();
                }
            }
        }
    }
}