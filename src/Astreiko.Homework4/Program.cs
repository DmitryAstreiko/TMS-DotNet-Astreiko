using System;
using System.Collections.Generic;

namespace Astreiko.Homework4
{
    class Program
    {
        /// <summary>
        /// Список событий
        /// </summary>
        public static List<Events> CurrentListEvents;

        static void Main(string[] args)
        {
            DefaultEvents();

            var currentAction = GetAction();

            var check = true;

            while (check)
            {

                switch (currentAction)
                {
                    case TypeAction.Add:
                        {
                            CreateEvent();
                            currentAction = GetAction();
                            break;
                        }
                    case TypeAction.Edit:
                        {
                            var checkEdit = true;

                            while (checkEdit)
                            {
                                Console.WriteLine("Input id for search : ");

                                var searchId = Console.ReadLine().Trim();

                                if (CheckEvent(searchId))
                                {

                                }
                                else 
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Event does not find. Please try again.");
                                    Console.WriteLine();
                                    Console.ResetColor();

                                    Console.WriteLine("You want continious? (y - default or n)");

                                    if (Console.ReadLine().Trim() == "n") { checkEdit = false; }
                                };
                            }
                            break;
                        }
                    case TypeAction.Delete:
                        {
                            break;
                        }
                    case TypeAction.Show:
                        {
                            ShowEvents();
                            currentAction = GetAction();
                            break;
                        }
                    case TypeAction.Close:
                        {
                            check = false;
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Выход из приложения.");
                            break;
                        }
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Прверка существования введенного идентификатора события
        /// </summary>
        /// <returns></returns>
        private static bool CheckEvent(string searchId)
        {
            var vRes = false;            

            foreach (var row in CurrentListEvents)
            {
                if (row.Id == searchId) { vRes = true; }
            }

            return vRes;
        }

        /// <summary>
        /// Создание события
        /// </summary>
        private static void CreateEvent()
        {
            Console.Write("Enter description :");
            var inputDesc = Console.ReadLine().Trim();

            var check = true;

            var inputStartDate = DateTime.Now;

            while (check)
            {
                try
                {
                    Console.Write("Enter start date : ");
                    inputStartDate = DateTime.Parse(Console.ReadLine());
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input date uncorrect!");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

            check = true;

            var inputFinishDate = DateTime.Now;

            while (check)
            {
                try
                {
                    Console.Write("Enter finish date : ");
                    inputFinishDate = DateTime.Parse(Console.ReadLine());
                    check = false;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input date uncorrect!");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }

            Console.Write("Enter status : ");
            var inputStatus = Console.ReadLine().Trim();

            AddEventToList(inputDesc, inputStartDate, inputFinishDate, inputStatus);
        }

        /// <summary>
        /// Добавление события в лист событий
        /// </summary>
        /// <param name="description">Описание события</param>
        /// <param name="startDate">Дата начала события</param>
        /// <param name="finishDate">Дата окончания события</param>
        /// <param name="status">Статус события</param>
        private static void AddEventToList(string description, DateTime startDate, DateTime finishDate, string status)
        {
            var newEvent = new Events();
            newEvent.Id = new Random().Next(1, 100000).ToString();
            newEvent.Description = description;
            newEvent.StartDate = startDate;
            newEvent.EndDate = finishDate;
            newEvent.Status = status;

            CurrentListEvents.Add(newEvent);
        }

        /// <summary>
        /// Отображение событий
        /// </summary>
        private static void ShowEvents()
        {
            Console.WriteLine("------CALENDAR------");

            foreach (var row in CurrentListEvents)
            {
                Console.WriteLine($"ID - {row.Id}");
                Console.WriteLine($"Description - {row.Description}");
                Console.WriteLine($"Dates {row.StartDate.ToShortDateString()} -> {row.EndDate.ToShortDateString()}");
                Console.WriteLine($"Status - {row.Status}");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("-------------------");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Заполнение первоночальных событий
        /// </summary>
        static private void DefaultEvents()
        {
            CurrentListEvents = new List<Events>()
            {
                new Events()
                {
                    Id = "222H3",
                    Description = "event1",
                    StartDate = new DateTime(2020, 01, 01),
                    EndDate = new DateTime(2021, 01, 01),
                    Status = "InProgress"
                },

                new Events()
                {
                    Id = "730d5",
                    Description = "event2",
                    StartDate = new DateTime(2020, 05, 02),
                    EndDate = new DateTime(2020, 12, 31),
                    Status = "ToDo"
                },

                new Events()
                {
                    Id = "730d5",
                    Description = "event2",
                    StartDate = new DateTime(2020, 05, 02),
                    EndDate = new DateTime(2020, 12, 31),
                    Status = "ToDo"
                }
            };
        }

        /// <summary>
        /// Тип выбора из консоли
        /// </summary>
        /// <returns></returns>
        static private TypeAction GetAction()
        {
            TypeAction vRes = 0;

            var check = true;

            while (check)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("----------------------------");
                Console.ResetColor();

                Console.WriteLine("Choose operation : ");
                Console.WriteLine($"--- ADD event - press \"A\" or \"a\" ");
                Console.WriteLine($"--- EDIT event - press \"E\" or \"e\" ");
                Console.WriteLine($"--- DELETE event - press \"D\" or \"d\" ");
                Console.WriteLine($"--- SHOW events - press \"S\" or \"s\" ");
                Console.WriteLine($"--- CLOSE console - press \"C\" or \"c\" ");
                Console.Write("Operation : ");

                var inputText = Console.ReadLine();

                if (inputText == "A" || inputText == "a")
                {
                    vRes = TypeAction.Add;
                    check = false;
                }
                else if (inputText == "E" || inputText == "e")
                {
                    vRes = TypeAction.Edit;
                    check = false;
                }
                else if (inputText == "D" || inputText == "d")
                {
                    vRes = TypeAction.Delete;
                    check = false;
                }
                else if (inputText == "S" || inputText == "s")
                {
                    vRes = TypeAction.Show;
                    check = false;
                }
                else if (inputText == "C" || inputText == "c")
                {
                    vRes = TypeAction.Close;
                    check = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Bad input operation. Please try again!");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            return vRes;
        }
    }
}
