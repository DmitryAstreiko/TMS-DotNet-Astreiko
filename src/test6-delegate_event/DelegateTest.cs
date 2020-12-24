using System;
using System.Collections.Generic;
using System.Text;

namespace test6_delegate_event
{
    public class DelegateTest
    {
        //----пример обычного делегата
        //public delegate void Message();
        //public Message mess;

        //private object _anything;

        //public DelegateTest(string anything)
        //{
        //    _anything = anything;

        //    Console.WriteLine($"{anything}");
        //}

        //public DelegateTest(int anything)
        //{
        //    _anything = anything;

        //    Console.WriteLine($"{anything}");
        //}

        //public void ShowMessage()
        //{
        //    Console.WriteLine(nameof(_anything));
        //}

        //public void ShowAnotherMessage()
        //{
        //    Console.WriteLine("Another");
        //}

        //----пример делегата ----
        public Action mess;

        private object _anything;

        public DelegateTest(string anything)
        {
            _anything = anything;

            Console.WriteLine($"{anything}");
        }

        public DelegateTest(int anything)
        {
            _anything = anything;

            Console.WriteLine($"{anything}");
        }

        public void ShowMessage()
        {
            Console.WriteLine(nameof(_anything));
        }

        public void ShowAnotherMessage()
        {
            Console.WriteLine("Another");
        }
    }
}
