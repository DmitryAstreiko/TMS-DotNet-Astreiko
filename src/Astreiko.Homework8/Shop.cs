using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

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
        /// List class Cashier
        /// </summary>
        private List<Cashier> ActualListCashiers { get; set; }

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
        /// Numbers of cashiers that working same time when the shop opened
        /// </summary>
        private int CountCashierDefault { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private List<Task> currentTasks;

        /// <summary>
        /// 
        /// </summary>
        private bool flagAddCashier;

        /// <summary>
        /// Максимальное количество окрытых касс
        /// </summary>
        private int maxCountCashier;

        /// <summary>
        /// список закрытых касс
        /// </summary>
        private List<Cashier> closedListCashier;

        private List<Cashier> workListCashier;

        public Shop()
        {
            RandomCustomers = new Random();
            RandomCreateCustomers = new Random();
            MaxCountCustomers = 25;
            CheckPeriodQueue = 5000;
            CountCashierDefault = 3;
            maxCountCashier = 10;

            peopleGenerator = new PeopleGenerator();
            cashierQueue = new Queue<Cashier>();
            customerQueue = new Queue<Person>();
            ActualListCashiers = new List<Cashier>();
            closedListCashier = new List<Cashier>();
            workListCashier = new List<Cashier>();

            currentTasks = new List<Task>();
            flagAddCashier = false;

            for (var i = 1; i <= maxCountCashier; i++)
            {
                ActualListCashiers.Add(new Cashier());
            }
        }

        /// <summary>
        /// Open shop
        /// </summary>
        internal void OpenShop()
        {
            Console.WriteLine("Shop is opening...");
            isOpen = true;

            for (var i = 0; i < ActualListCashiers.Count; i++)
            {
                if (i < 3)
                {
                    OpenCashier(ActualListCashiers[i]);
                    workListCashier.Add(ActualListCashiers[i]);
                }
                else closedListCashier.Add(ActualListCashiers[i]);
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
                    var genPerson = peopleGenerator.GetPerson();
                    EnqueueCustomer(genPerson);
                    var task = Task.Run(() => ProcessPerson(genPerson));
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
                $"{DateTime.Now}: {countCustomersWaiting} customers are waiting the free cashier (Check every {CheckPeriodQueue} ms).");
            Console.ResetColor();
            Console.WriteLine();

            if (countCustomersWaiting > 30)
            {
                lock (closedListCashier)
                {
                    if (closedListCashier.Any())
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"{DateTime.Now}: There are many customers, need to open new cashier!");
                        Console.ResetColor();

                        //OpenCashier(new Cashier());
                        var tempCashier = closedListCashier[0];
                        OpenCashier(tempCashier);
                        closedListCashier.RemoveAt(0);
                        ActualListCashiers.Add(tempCashier);
                    }
                }
            }
            else if (countCustomersWaiting < 5)
            {
                lock (closedListCashier)
                {
                    if (closedListCashier.Count > 3)
                    {
                        Console.WriteLine($"CASHIER - {closedListCashier.Count}................................");
                        Cashier cashier;

                        TryDequeueCashier(out cashier);

                        ShowInfoForExitCashier(cashier);
                    }
                }
            }

            if (countCustomersWaiting <= 99) return;

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("ALARM. NEED MORE CASHIERS!");
            Console.ResetColor();
        }

        internal void OpenCashier(Cashier cashier)
        {
            EnqueueCashier(cashier);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{DateTime.Now}: Cachier {cashier.NameCashier} is opened.");
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
                if (cashierQueue.Count > 3 && flagAddCashier) Thread.Sleep(CheckPeriodQueue * 3); //Waiting results work additional cashier
                Thread.Sleep(CheckPeriodQueue);

                var task = Task.Run(() => CheckWaitingCustomers());
                currentTasks.Add(task);
            }
        }

        private void ProcessPerson(Person person)
        {
            Cashier cashier = null;

            if (isOpen)
            {
                while (!TryDequeueCashier(out cashier))
                {
                    Thread.Sleep(100);
                }

                var timeToProcess = cashier.TimeToProcess + person.TimeToProcess;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{DateTime.Now}: Cashier {cashier.NameCashier} is processing {person.Name} on thread {Thread.CurrentThread.ManagedThreadId}...");
                Console.ResetColor();
                Thread.Sleep(timeToProcess);

                DequeueCustomer();
                EnqueueCashier(cashier);
            }

            ShowInfoForExitCashier(cashier);
        }

        private void ShowInfoForExitCashier(Cashier cashier)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{DateTime.Now}: Cachier {Thread.CurrentThread.ManagedThreadId} is exitting.");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void EnqueueCashier(Cashier cashier)
        {
            lock (cashierQueue)
            {
                cashierQueue.Enqueue(cashier); 
                Console.WriteLine($"CASHIER - {cashierQueue.Count}................................");
                flagAddCashier = true;
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