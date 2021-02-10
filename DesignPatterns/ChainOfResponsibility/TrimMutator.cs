using System;

namespace DesignPatterns.ChainOfResponsibility
{
    public class TrimMutator : IStringMutator
    {
        private IStringMutator _next;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return next;
        }

        public string Mutate(string str)
        {
            var mutated = str == null ? "" : str.Trim();
            return _next == null ? mutated : _next.Mutate(mutated);
        }
    }
}