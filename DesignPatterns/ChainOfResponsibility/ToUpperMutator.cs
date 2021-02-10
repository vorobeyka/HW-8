namespace DesignPatterns.ChainOfResponsibility
{
    public class ToUpperMutator : IStringMutator
    {
        private IStringMutator _next = null;

        public IStringMutator SetNext(IStringMutator next)
        {
            _next = next;
            return this;
        }

        public string Mutate(string str)
        {
            string mutable = str.ToUpper();
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