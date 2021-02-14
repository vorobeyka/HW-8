using System;
using System.Collections.Generic;

namespace DesignPatterns.IoC
{
    class ServiceProvider : IServiceProvider
    {
        private readonly IDictionary<Type, object> _transients;
        private readonly IDictionary<Type, object> _singletons;

        public ServiceProvider(IDictionary<Type, object> singletons, IDictionary<Type, object> transients)
        {
            _transients = transients;
            _singletons = singletons;
        }

        public T GetService<T>()
        {
            var isTransient = _transients.ContainsKey(typeof(T));
            if (isTransient) return GetTransient<T>();

            var isSingleton = _singletons.ContainsKey(typeof(T));
            if (isSingleton) return GetSingleton<T>();

            return default;
        }

        private T GetSingleton<T>()
        {
            if(_singletons[typeof(T)] == null)
            {
                _singletons[typeof(T)] = Activator.CreateInstance<T>();
            }
            return (T)_singletons[typeof(T)];
        }

        private T GetTransient<T>()
        {
            return (_transients[typeof(T)]) switch
            {
                Func<T> func => func.Invoke(),
                Func<IServiceProvider, T> func => func.Invoke(this),
                _ => Activator.CreateInstance<T>(),
            };
        }
    }
}