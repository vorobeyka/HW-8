using System.Linq;

namespace DesignPatterns.ChainOfResponsibility
{
    public class RemoveNumbersMutator : IStringMutator
    {
        private IStringMutator _next = null;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return this;
        }

        public string Mutate(string str)
        {
            var mutable = new string(str.Where(c => !IsDigit(c)).ToArray());
            if (_next != null)
            {
                return _next.Mutate(mutable);
            }
            else
            {
                return mutable;
            }
        }

        private static bool IsDigit(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}