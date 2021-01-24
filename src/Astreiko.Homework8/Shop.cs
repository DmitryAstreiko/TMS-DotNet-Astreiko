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
        private Queue<Person> ProcessingQueue { get; set; }

        /// <summary>
        /// Список потоков касс
        /// </summary>
        //private List<Thread> Processors { get; set; }
        private List<Cashier> Processors { get; set; }

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
        /// Количество одновременно работающих касс при открытии магазина
        /// </summary>
        private int CountCashier { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private readonly object locker = new object();

        public Shop()
        {
            PeopleGenerator = new PeopleGenerator();
            ProcessingQueue = new Queue<Person>();
            RandomVisitors = new Random();
            RandomCreateVisitors = new Random();
            MaxCountVisitors = 25;
            CheckPeriodQueue = 5000;
            NeedCloseCashier = false;
            MaxCountCashier = 10;
            CountCashier = 3;

            var processors = new List<Cashier>();
            for (int i = 0; i < CountCashier; i++)
            {
                var nCashier = new Cashier();
                nCashier.ThreadCashier = new Thread(ProcessPeople);
                nCashier.NameCashier = $"Cashier {i + 1}";
                processors.Add(nCashier);
            }
            Processors = processors;
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
                Processors[i - 1].ThreadCashier.Start(i);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"{Processors[i-1].NameCashier} is opened.");
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
                Console.WriteLine($"{CountVisitorsWaiting} visitors are waiting a free cashier (Check starts every {CheckPeriodQueue} ms).");
                Console.ResetColor();
                Console.WriteLine();

                if (CountVisitorsWaiting > 30 && MaxCountCashier >= Processors.Count(x => x.ThreadCashier.IsAlive))
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("There are many visitors, need to open new cashier!");
                    Console.ResetColor();

                    OpenCashier();

                    Thread.Sleep(CheckPeriodQueue * 3); //ожидаем результатов работы дополнительной кассы
                }
                else if (CountVisitorsWaiting < 5 && Processors.Count(x => x.ThreadCashier.IsAlive) > 3)
                {
                    NeedCloseCashier = true;
                }
            }
        }

        /// <summary>
        /// Открытие кассы
        /// </summary>
        internal void OpenCashier()
        {
            var StopedCashiers = Processors.Where(x => x.ThreadCashier.IsAlive == false).Select(q => q.NameCashier).Distinct().ToList();
            var RanCashiers = Processors.Where(x => x.ThreadCashier.IsAlive).Select(q => q.NameCashier).ToList();
            var freeCashiersList = StopedCashiers.Except(RanCashiers).ToList();

            var nCashier = new Cashier();
            nCashier.ThreadCashier = new Thread(ProcessPeople);
            nCashier.NameCashier = freeCashiersList.Count == 0 ? $"Cashier {Processors.Count + 1}" : freeCashiersList.First();

            Processors.Add(nCashier);
            Processors[Processors.Count-1].ThreadCashier.Start(Processors.Count);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Processors[Processors.Count-1].NameCashier} is opened.");
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
            Console.WriteLine($"{randomV} visitors are visiting the shop (Maximum number of visitors are {MaxCountVisitors}).");
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
                while (ProcessingQueue.Count > 0)
                {
                    lock (locker)
                    {
                        if (ProcessingQueue.TryDequeue(out var person))
                        {
                            Console.WriteLine(
                                $"{Processors[(int) obj - 1].NameCashier} is processing {person.Name}...");
                            Thread.Sleep(person.TimeToProcess);
                            Console.WriteLine($"{Processors[(int) obj - 1].NameCashier} is processed {person.Name}.");
                        }
                    }
                }
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"There are a few visitor, need to close any cashier!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Processors[(int)obj - 1].NameCashier} is closed.");
            Console.ResetColor();
            NeedCloseCashier = false;
        }
    }
}