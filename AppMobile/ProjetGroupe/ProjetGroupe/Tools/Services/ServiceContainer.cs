using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGroupe.Tools.Services
{
    /// <summary>
    /// Service Container
    /// </summary>
    public static class ServiceContainer
    {
        static readonly Dictionary<Type, Lazy<object>> services
           = new Dictionary<Type, Lazy<object>>();

        /// <summary>
        /// Register
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="function">fonction</param>
        public static void Register<T>(Func<T> function)
            => services[typeof(T)] = new Lazy<object>(() => function());

        /// <summary>
        /// Resolve
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>T</returns>
        public static T Resolve<T>()
            => (T)Resolve(typeof(T));

        /// <summary>
        /// Resolve surchargé
        /// </summary>
        /// <param name="type">Objet Type</param>
        /// <returns>object</returns>
        public static object Resolve(Type type)
        {
            {
                if (services.TryGetValue(type, out var service))
                    return service.Value;

                throw new KeyNotFoundException($"Service not found for type '{type}'");
            }
        }
    }
}
