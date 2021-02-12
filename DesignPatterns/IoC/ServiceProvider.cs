using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.IoC
{
    class ServiceProvider : IServiceProvider
    {
        private IEnumerable<Type> Transients { get; }
        private IEnumerable<Type> Singletons { get; }

        private readonly IDictionary<Type, object> _existedSingletons = new Dictionary<Type, object>();

        public ServiceProvider(IEnumerable<Type> transients, IEnumerable<Type> singletons)
        {
            Transients = transients;
            Singletons = singletons;
        }

        public T GetService<T>()
        {
            var isTransient = Transients.Any(transient => transient == typeof(T));
            if (isTransient) return Activator.CreateInstance<T>();

            var isSingletons = Singletons.Any(singleton => singleton == typeof(T));
            if (!isSingletons) throw new Exception();

            try
            {
                return (T)_existedSingletons[typeof(T)];
            }
            catch (Exception)
            {
                var singleton = Activator.CreateInstance<T>();
                _existedSingletons.Add(typeof(T), singleton);
                return singleton;
            }
        }
    }
}