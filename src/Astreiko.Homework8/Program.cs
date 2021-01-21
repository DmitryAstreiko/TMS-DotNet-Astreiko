using System;

namespace Astreiko.Homework8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var peopleGenerator = new PeopleGenerator();

            var shop = new Shop(peopleGenerator, 3); //3 - количество касс

            shop.Open();

            while(true)
            {
                var command = Console.ReadLine();
                switch (command)
                {
                    case "close":
                        shop.Close();
                        return;
                    default:
                        if (int.TryParse(command, out var numberPeople))
                        {
                            for (int i = 0; i < numberPeople; i++)
                            {
                                shop.EnterShop();
                            }
                        }
                }
            }
        }
    }
}
