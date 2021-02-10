using System;
using System.Linq;

namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : IStringMutator
    {
        private IStringMutator _next;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return next;
        }

        public string Mutate(string str)
        {
            var mutated = str == null ? "" : new string(str.Where(c => !IsDigit(c)).ToArray());
            return _next == null ? mutated : _next.Mutate(mutated);
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}