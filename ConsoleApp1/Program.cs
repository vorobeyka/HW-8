using System;
using System.Diagnostics;
using System.Text;
using DesignPatterns.Builder;
using DesignPatterns.ChainOfResponsibility;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IStringMutator stringMutator1 = new ToUpperMutator();
            IStringMutator stringMutator2 = new InvertMutator();
            IStringMutator stringMutator3 = new RemoveNumbersMutator();
            IStringMutator stringMutator4 = new TrimMutator();

            IStringMutator sut = stringMutator1.SetNext(stringMutator2.SetNext(stringMutator3.SetNext(stringMutator4)));

            string actual = sut.Mutate("    SOME 1 input 2 String 3");
            Console.WriteLine(actual);
        }
    }
}
