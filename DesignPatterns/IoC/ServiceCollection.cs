using System;
using System.Collections.Generic;

namespace DesignPatterns.IoC
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly IDictionary<Type, object> _singletons = new Dictionary<Type, object>();
        private readonly IDictionary<Type, object> _transients = new Dictionary<Type, object>();

        public IServiceCollection AddTransient<T>()
        {
            RegisterTransient<T>(default);
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<T> factory)
        {
            RegisterTransient<T>(factory);
            return this;
        }

        public IServiceCollection AddTransient<T>(Func<IServiceProvider, T> factory)
        {
            RegisterTransient<T>(factory);
            return this;
        }

        public IServiceCollection AddSingleton<T>()
        {
            RegisterSingleton<T>(default);
            return this;
        }

        public IServiceCollection AddSingleton<T>(T service)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            RegisterSingleton(service);
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<T> factory)
        {
            var singleton = factory.Invoke() ?? throw new ArgumentNullException(nameof(factory));
            RegisterSingleton(singleton);
            return this;
        }

        public IServiceCollection AddSingleton<T>(Func<IServiceProvider, T> factory)
        {
            var singleton = factory.Invoke(BuildServiceProvider()) ?? throw new ArgumentNullException(nameof(factory));
            RegisterSingleton(singleton);
            return this;
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_singletons, _transients);
        }

        private void RegisterSingleton<T>(T singleton)
        {
            if (!_singletons.ContainsKey(typeof(T)))
            {
                _singletons.Add(typeof(T), singleton);
            }
            else
            {
                _singletons[typeof(T)] = singleton;
            }
        }

        private void RegisterTransient<T>(object obj)
        {
            if (!_transients.ContainsKey(typeof(T)))
            {
                _transients.Add(typeof(T), obj);
            }
            else
            {
                _transients[typeof(T)] = obj;
            }
        }

    }
}