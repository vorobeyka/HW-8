using System;
using System.Collections.Generic;

namespace DesignPatterns.IoC
{
    public class ServiceCollection : IServiceCollection
    {
        private List<Type> _singletons = new List<Type>();
        private List<Type> _transients = new List<Type>();

        public IServiceCollection AddTransient<T>()
        {
            _transients.Add(typeof(T));
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            throw new NotImplementedException();
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            throw new NotImplementedException();
        }

        public IServiceCollection AddSingleton<T>()
        {
            _singletons.Add(typeof(T));
            return this;
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            throw new NotImplementedException();
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            throw new NotImplementedException();
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            throw new NotImplementedException();
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_transients, _singletons);
        }
    }
}