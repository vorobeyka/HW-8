namespace DesignPatterns.ChainOfResponsibility
{
    public class TrimMutator : IStringMutator
    {
        private IStringMutator _next = null;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return this;
        }

        public string Mutate(string str)
        {
            var mutable = str.Trim();
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