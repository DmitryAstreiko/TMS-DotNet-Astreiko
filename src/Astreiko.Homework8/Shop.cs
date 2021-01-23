using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;

namespace Astreiko.Homework8
{
    internal class Shop
    {
        /// <summary>
        /// Генератор свойств посетителей
        /// </summary>
        private PeopleGenerator PeopleGenerator { get; set; }

        /// <summary>
        /// Очередь из посетителей в кассы
        /// </summary>
        private ConcurrentQueue<Person> ProcessingQueue { get; set; }

        /// <summary>
        /// Список потоков касс
        /// </summary>
        private List<Thread> Processors { get; set; }

        /// <summary>
        /// Флаг открыт/закрыт магазин
        /// </summary>
        private bool IsOpen { get; set; }

        /// <summary>
        /// Генератор для создания посетителей
        /// </summary>
        private Random RandomVisitors { get; set; }

        /// <summary>
        /// Максимальное количество посетилей, которое может прийдти за 1 раз
        /// </summary>
        private int MaxCountVisitors { get; set; }

        /// <summary>
        /// рандом для генерации прихода посетителей
        /// </summary>
        private Random RandomCreateVisitors { get; set; }

        /// <summary>
        /// Время, через которое будет происходить проверка количества посетителей в очереди 
        /// </summary>
        private int CheckPeriodQueue { get; set; }

        /// <summary>
        /// Максимальное количество одновременно работающих касс
        /// </summary>
        private int MaxCountCashier { get; set; }

        /// <summary>
        /// Количество ожидающих посетителей
        /// </summary>
        private int CountVisitorsWaiting { get; set; }

        /// <summary>
        /// Необходимость закрыть кассу
        /// </summary>
        private bool NeedCloseCashier { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="cashierNumber"></param>
        public Shop(int cashierNumber)
        {
            PeopleGenerator = new PeopleGenerator();
            ProcessingQueue = new ConcurrentQueue<Person>();
            RandomVisitors = new Random();
            MaxCountVisitors = 25;
            RandomCreateVisitors = new Random();
            CheckPeriodQueue = 5000;
            NeedCloseCashier = false;
            MaxCountCashier = 10;

            var processors = new List<Thread>();
            for (int i = 0; i < cashierNumber; i++)
            {
                processors.Add(new Thread(ProcessPeople));
            }
            this.Processors = processors;
        }

        /// <summary>
        /// Открытие магазина
        /// </summary>
        internal void Open()
        {
            Console.WriteLine("Shop is opening...");
            IsOpen = true;

            for (int i = 1; i <= Processors.Count; i++)
            {
                Processors[i - 1].Start(i);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Cachier {i} is opened.");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Закрытие магазина
        /// </summary>
        internal void Close()
        {
            IsOpen = false;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The shop is closing...");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Генератор новых посетителей
        /// </summary>
        internal void StartVisitorsGenerator()
        {
            while (IsOpen)
            {
                GeneratorVisitors();

                Thread.Sleep(RandomCreateVisitors.Next(10000,15000));
            }
        }

        /// <summary>
        /// Проверка количества посетителей в очереди
        /// </summary>
        internal void CheckWaitingVisitors()
        {
            while (IsOpen)
            {
                Thread.Sleep(CheckPeriodQueue);

                CountVisitorsWaiting = ProcessingQueue.Count;

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"{CountVisitorsWaiting} visitors are waiting a free cashier (Check period is {CheckPeriodQueue} ms).");
                Console.ResetColor();
                Console.WriteLine();

                if (CountVisitorsWaiting > 30 && MaxCountCashier >= Processors.Count(x => x.IsAlive))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("There are many visitors, need to open new cashier!");
                    Console.ResetColor();
                    OpenCashier();

                    Thread.Sleep(CheckPeriodQueue * 3); //ожидаем результатов работы дополнительной кассы
                }
                else if (CountVisitorsWaiting < 5 && Processors.Count > 3)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("There are a few visitor, need to close any cashier!");
                    Console.ResetColor();
                    NeedCloseCashier = true;
                }
            }
        }

        /// <summary>
        /// Открытие кассы
        /// </summary>
        internal void OpenCashier()
        {
            Processors.Add(new Thread(ProcessPeople));
            Processors[Processors.Count-1].Start(Processors.Count);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Cashier {Processors.Count} is opened.");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Генератор пришедших новых посетителей 
        /// </summary>
        internal void GeneratorVisitors()
        {
            var randomV = RandomVisitors.Next(0, MaxCountVisitors);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{randomV} visitors are visiting the shop ({MaxCountVisitors} are maximum visitors).");
            Console.ResetColor();
            Console.WriteLine();

            for (int i = 0; i < randomV; i++)
            {
                EnterShop();
            }
        }

        /// <summary>
        /// магазин открыт
        /// </summary>
        internal void EnterShop()
        {
            ProcessingQueue.Enqueue(PeopleGenerator.GetPerson());
        }

        /// <summary>
        /// Обслуживание посетителей
        /// </summary>
        /// <param name="obj"></param>
        private void ProcessPeople(object obj)
        {
            while (IsOpen && !NeedCloseCashier)
            {
                while (!this.ProcessingQueue.IsEmpty)
                {
                    if (ProcessingQueue.TryDequeue(out var person))
                    {
                        Console.WriteLine($"Cashier {obj} is processing {person.Name}...");
                        Thread.Sleep(person.TimeToProcess);
                        Console.WriteLine($"Cashier {obj} is processed {person.Name}.");
                    }
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Cashier {obj} is closed.");
            NeedCloseCashier = false;
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}