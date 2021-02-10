using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class ToUpperMutator : IStringMutator
    {
        private IStringMutator _next;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return next;
        }

        public string Mutate(string str)
        {
            string mutated = str == null ? "" : str.ToUpper();
            return _next == null ? mutated : _next.Mutate(mutated);
        }
    }
}