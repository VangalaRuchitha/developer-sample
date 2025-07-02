using System;
using System.Collections.Generic;


namespace DeveloperSample.Container
{
    public class Container
    {
        public void Bind(Type interfaceType, Type implementationType) => throw new NotImplementedException();
        public T Get<T>() => throw new NotImplementedException();
        private readonly Dictionary<Type, Type> _bindings = new();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
                throw new ArgumentException($"{implementationType.Name} does not implement {interfaceType.Name}");

            _bindings[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            var type = typeof(T);

            if (!_bindings.TryGetValue(type, out var implementationType))
                throw new InvalidOperationException($"Type {type.Name} is not bound");

            return (T)Activator.CreateInstance(implementationType);
        }
    }
}
