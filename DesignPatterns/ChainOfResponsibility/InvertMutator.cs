using System;
using System.Linq;

namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : IStringMutator
    {
        private IStringMutator _next;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return next;
        }

        public string Mutate(string str)
        {
            var mutated = str == null ? "" : new string(str.Reverse().ToArray());
            return _next == null ? mutated : _next.Mutate(mutated);
        }
    }
}