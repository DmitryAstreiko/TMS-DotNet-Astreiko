using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Astreiko.Homework8
{
    internal class Shop
    {
        private PeopleGenerator peopleGenerator;
        private List<Thread> processors;
        private Queue<Person> processingQueue;
        private bool isOpen;

        public Shop(PeopleGenerator peopleGenerator, int cashierNumber)
        {
            this.peopleGenerator = peopleGenerator;
            this.processingQueue = new ConcurrentQueue<Person>();

            var processors = new List<Thread>();

            for (int i = 0; i < cashierNumber; i++)
            {
                processors.Add(new Thread(ProcesPeople));
            }
            this.processors = processors;
        }

        internal void Open()
        {
            Console.WriteLine("Shop is openning...");

            this.isOpen = true;

            for (int i = 0; i < processors.Count; i++)
            {
                processors[i - 1].Start(i);
                Thread.Start();
                Console.WriteLine($"Cachier {i} is open.");
            }
                        
        }

        internal void Close()
        {
            isOpen = false;
        }

        internal void EnterShop()
        {

        }

        private void ProcesPeople(object obj)
        {
            while (isOpen)
            {

                while (this.processingQueue.IsEmpty)
                {
                    if (processingQueue.TryDequeue(out var person))
                    {
                        Console.WriteLine($"Cashier {obj} is processing {person.Name}...");
                        Thread.Sleep(person.TimeToProcess);

                        Console.WriteLine($"Cashier {obj} is processed {person.Name}...");
                    }
                }
            }
            Console.WriteLine($"Cshier {obj} is closed/");

        }
    }
}