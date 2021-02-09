using System;
using System.Diagnostics;
using System.Text;
using DesignPatterns.Builder;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();
            {
                sb.Append("111111111111111111111111111");
            }
            Console.WriteLine(sb.Capacity);
        }
    }
}
