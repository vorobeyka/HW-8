using System;

namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private char[] _memory;
        public int Capacity { get; private set; }
        public int Length { get; private set; }
        public int MaxCapacity { get; }
        public CustomStringBuilder()
        {
            Capacity = 16;
            Length = 0;
            MaxCapacity = int.MaxValue;
        }

        public CustomStringBuilder(string text)
        {
            Capacity = text.Length > 16 ? text.Length : 16;
            Length = text.Length;
            _memory = new char[Capacity];
        }

        public ICustomStringBuilder Append(string str)
        {

            Array.Resize(ref _memory, Capacity);
        }

        public ICustomStringBuilder Append(char ch)
        {
            throw new System.NotImplementedException();
        }

        public ICustomStringBuilder AppendLine()
        {
            throw new System.NotImplementedException();
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            throw new System.NotImplementedException();
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            throw new System.NotImplementedException();
        }

        public string Build()
        {
            throw new System.NotImplementedException();
        }
    }
}