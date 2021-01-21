using System;
using System.Collections.Generic;

namespace Astreiko.Homework4
{
    class Program
    {
        /// <summary>
        /// List events
        /// </summary>
        public static List<Events> CurrentListEvents;

        static void Main(string[] args)
        {
            DefaultEvents();

            var check = true;

            while (check)
            {
                var currentAction = GetAction();

                switch (currentAction)
                {
                    case TypeAction.Add:
                        {
                            CreateEvent();
                            break;
                        }
                    case TypeAction.Edit:
                        {
                            EditEvent();
                            break;
                        }
                    case TypeAction.Delete:
                        {
                            DeleteEvent();
                            break;
                        }
                    case TypeAction.Show:
                        {
                            ShowEvents();
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
        /// Delete event
        /// </summary>
        private static void DeleteEvent()
        {
            var checkDel = true;

            while (checkDel)
            {
                Console.Write("Input id for delete : ");

                var searchId = Console.ReadLine()?.Trim();

                var searchEvent = CheckEvent(searchId);

                if (searchEvent != -1)
                {
                    Console.WriteLine("Event found.");
                    Console.WriteLine();

                    CurrentListEvents.RemoveAll(x => x.Id == searchId);

                    Console.WriteLine("Event deleted.");
                    Console.WriteLine();
                    checkDel = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Event does not find. Please try again.");
                    Console.WriteLine();
                    Console.ResetColor();

                    Console.Write("You want continious? (y - default or n)");

                    if (Console.ReadLine()?.Trim() == "n") { checkDel = false; }
                }
            }
        }

        /// <summary>
        /// Edit event
        /// </summary>
        private static void EditEvent()
        {
            var checkEdit = true;

            while (checkEdit)
            {
                Console.Write("Input id for edit : ");

                var searchId = Console.ReadLine()?.Trim();

                var searchEvent = CheckEvent(searchId);

                if (searchEvent != -1)
                {
                    Console.WriteLine("Event found.");
                    Console.WriteLine();

                    Console.Write("Enter description : ");
                    CurrentListEvents[searchEvent].Description = Console.ReadLine()?.Trim();

                    CurrentListEvents[searchEvent].StartDate = GetDate("Enter start date: ");

                    CurrentListEvents[searchEvent].EndDate = GetDate("Enter finish date: ");

                    Console.Write("Enter status : ");
                    CurrentListEvents[searchEvent].Status = Console.ReadLine()?.Trim();

                    Console.WriteLine("Event edited.");

                    checkEdit = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Event does not find. Please try again.");
                    Console.WriteLine();
                    Console.ResetColor();

                    Console.Write("You want continious? (y - default or n)");

                    if (Console.ReadLine()?.Trim() == "n") { checkEdit = false; }
                }
            }
        }

        /// <summary>
        /// Checking for the existence of an entered event identifier (Проверка существования введенного идентификатора события)
        /// </summary>
        /// <returns></returns>
        private static int CheckEvent(string searchId)
        {
            var vRes = -1;

            for (int i = 0; i < CurrentListEvents.Count; i++)
            {
                if (CurrentListEvents[i].Id == searchId) { vRes = i; }
            }

            return vRes;
        }

        /// <summary>
        /// Create event
        /// </summary>
        private static void CreateEvent()
        {
            Console.Write("Enter description : ");
            var inputDesc = Console.ReadLine()?.Trim();

            var inputStartDate = GetDate("Enter start date: ");

            var inputFinishDate = GetDate("Enter finish date: ");

            Console.Write("Enter status : ");
            var inputStatus = Console.ReadLine()?.Trim();

            AddEventToList(inputDesc, inputStartDate, inputFinishDate, inputStatus);
        }

        /// <summary>
        /// Get entered date
        /// </summary>
        /// <param name="textToConsole">Text to console</param>
        /// <returns></returns>
        private static DateTime GetDate(string textToConsole)
        {
            var inputDate = DateTime.Now;

            while (true)
            {
                try
                {
                    Console.Write(textToConsole);
                    return inputDate = DateTime.Parse(Console.ReadLine().Trim());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input date uncorrect!");
                    Console.WriteLine();
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Add events into list events
        /// </summary>
        /// <param name="description">Description events</param>
        /// <param name="startDate">Start date event</param>
        /// <param name="finishDate">Finish date event</param>
        /// <param name="status">Status events</param>
        private static void AddEventToList(string description, DateTime startDate, DateTime finishDate, string status)
        {
            var newEvent = new Events();

            var generator = new RandomGenerator();

            newEvent.Id = generator.RandomPassword();
            newEvent.Description = description;
            newEvent.StartDate = startDate;
            newEvent.EndDate = finishDate;
            newEvent.Status = status;

            CurrentListEvents.Add(newEvent);
        }

        /// <summary>
        /// Show events
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
        /// Add default events
        /// </summary>
        private static void DefaultEvents()
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
                    Id = "533720",
                    Description = "event3",
                    StartDate = new DateTime(2020, 09, 12),
                    EndDate = new DateTime(2021, 02, 25),
                    Status = "ToDo"
                }
            };
        }

        /// <summary>
        /// Menu actions in console
        /// </summary>
        /// <returns></returns>
        private static TypeAction GetAction()
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

                switch (inputText)
                {
                    case "A":
                    case "a":
                        vRes = TypeAction.Add;
                        check = false;
                        break;
                    case "E":
                    case "e":
                        vRes = TypeAction.Edit;
                        check = false;
                        break;
                    case "D":
                    case "d":
                        vRes = TypeAction.Delete;
                        check = false;
                        break;
                    case "S":
                    case "s":
                        vRes = TypeAction.Show;
                        check = false;
                        break;
                    case "C":
                    case "c":
                        vRes = TypeAction.Close;
                        check = false;
                        break;
                    default:
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bad input operation. Please try again!");
                        Console.ResetColor();
                        Console.WriteLine();
                        break;
                }
            }
            return vRes;
        }
    }
}
