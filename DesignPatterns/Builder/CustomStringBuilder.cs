using System;

namespace DesignPatterns.Builder
{
    public class CustomStringBuilder : ICustomStringBuilder
    {
        private char[] _data;

        public char this[int index]
        {
            get
            {
                return _data[index];
            }
        }

        public int Capacity { get; private set; }
        public int Length { get; private set; }
        public int MaxCapacity { get; }
        public CustomStringBuilder()
        {
            Capacity = 16;
            Length = 0;
            MaxCapacity = int.MaxValue;
            _data = new char[0];
        }

        public CustomStringBuilder(string text)
        {
            var length = text.Length;
            Capacity = length > 16 ? length : 16;
            Length = length;
            MaxCapacity = int.MaxValue;
            _data = new char[Capacity];
            for (int i = 0; i < Length; i++)
            {
                _data[i] = text[i];
            }
        }

        private void ResizeCapacity(int len)
        {
            if (len > Capacity)
            {
                Capacity *= 2;
                if (len > Capacity)
                {
                    Capacity = len;
                }
            }
            Array.Resize(ref _data, Capacity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Argument"></param>
        private void AddString(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                _data[i + Length] = str[i];
            }
        }

        public ICustomStringBuilder Append(string str)
        {
            ResizeCapacity(str.Length + Length);
            AddString(str);
            Length += str.Length;
            return this;
        }

        public ICustomStringBuilder Append(char ch)
        {
            ResizeCapacity(Length + 1);
            Length += 1;
            _data[Length - 1] = ch;
            return this;
        }

        public ICustomStringBuilder AppendLine()
        {
            ResizeCapacity(Length + 1);
            Length += 1;
            _data[Length - 1] = '\n';
            return this;
        }

        public ICustomStringBuilder AppendLine(string str)
        {
            ResizeCapacity(Length + str.Length + 1);
            AddString(str);
            Length += str.Length + 1;
            _data[Length - 1] = '\n';
            return this;
        }

        public ICustomStringBuilder AppendLine(char ch)
        {
            ResizeCapacity(Length + 2);
            Length += 2;
            _data[Length - 2] = ch;
            _data[Length - 1] = '\n';
            return this;
        }

        public string Build()
        {
            return new string(_data, 0, Length);
        }

        public override string ToString()
        {
            return new string(_data, 0, Length);
        }
    }
}