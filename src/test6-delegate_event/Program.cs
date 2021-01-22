using System;

namespace test6_delegate_event
{
    class Program
    {
        static void Main(string[] args)
        {
            var delegateTest1 = new DelegateTest("mess1");
            //var delegateTest2 = new DelegateTest(1);

            ////delegateTest1.mess = delegateTest1.ShowMessage;
            ////delegateTest1.mess += delegateTest1.ShowAnotherMessage;

            ////delegateTest1.mess(123);

            //---------лямбда выражения-----------------
            var delegateTest2 = new DelegateTest("mess1");
            //var delegateTest2 = new DelegateTest(1);

            delegateTest2.mess = (x, y) =>
            {
                Console.WriteLine("qwe");
                return true;
            };

            delegateTest2.mess += delegateTest1.ShowAnotherMessage;

            delegateTest2.mess(123, "aSD");

            //лямбда выражения
            Action<int, string> action = (num, str) => Console.WriteLine($"{num} {str}");

            action(111, "123");

            Predicate<int> predicate = (num) => true;

            var vpr = predicate(2021);

            Func<int, string> func = (num) => num.ToString();

            var vf = func(2021);

            Console.ReadKey();
        }
    }
}
