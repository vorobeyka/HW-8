using System.Linq;

namespace DesignPatterns.ChainOfResponsibility
{
    public class InvertMutator : IStringMutator
    {
        private IStringMutator _next = null;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return this;
        }

        public string Mutate(string str)
        {
            var mutable = new string(str.Reverse().ToArray());
            if (_next != null)
            {
                return _next.Mutate(mutable);
            }
            else
            {
                return mutable;
            }
        }
    }
}