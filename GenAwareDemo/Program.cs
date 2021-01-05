namespace GenAwareDemo
{
    using System;
    using System.Diagnostics;

    class LongTermObject
    {
        public ShortTermObject leak;
    }

    class ShortTermObject
    {
        public ShortTermObject prev;
        public byte[] weight;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My process id is " + Process.GetCurrentProcess().Id);
            Console.ReadLine();
            LongTermObject LongTermObject = new LongTermObject();
            GC.Collect();
            GC.Collect();
            int counter = 0;
            for (int iteration = 0; iteration < 10000; iteration++)
            {
                ShortTermObject head = new ShortTermObject();
                for (int i = 0; i < 1000; i++)
                {
                    ShortTermObject next = new ShortTermObject();
                    next.weight = new byte[1000];
                    next.prev = head;
                    head = next;
                }
                counter++;
                // Emulate a leak of a ephermal object to LongTermObject.
                if (counter % 1000 == 0)
                {
                    Console.WriteLine("Leaked");
                    LongTermObject.leak = head;
                }
            }
        }
    }
}