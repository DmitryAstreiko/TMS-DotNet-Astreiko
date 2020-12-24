using System;

namespace test6_delegate_event
{
    class Program
    {
        static void Main(string[] args)
        {
            var delegateTest1 = new DelegateTest("mess1");
            //var delegateTest2 = new DelegateTest(1);

            delegateTest1.mess = delegateTest1.ShowMessage;

            delegateTest1.mess();

            Console.ReadKey();
        }
    }
}
