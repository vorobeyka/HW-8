using System;
using DesignPatterns.Builder;
using DesignPatterns.ChainOfResponsibility;
using DesignPatterns.IoC;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            some<ServiceCollection>();
        }

        static void some<T>()
        {
            Console.WriteLine(typeof(T));
            Type t = typeof(T);
            Console.WriteLine($"{t.Name}");
            Console.WriteLine($"{t.Assembly}");
            Console.WriteLine($"{t.FullName}");
            Console.WriteLine($"{t.Module}");

            //Console.WriteLine($"{t.GetFields()}");
            foreach (var i in t.GetFields())
            {
                Console.WriteLine($"{i}");
            }
            Console.WriteLine($"{t.Name}");
            Console.WriteLine($"{t.Name}");
            Console.WriteLine($"{t.Name}");

        }
    }
}
