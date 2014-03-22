namespace AngularWebservices
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;

    using AngularWebservices.Controllers;
    using AngularWebservices.Models;

    /// <summary>
    /// The simple dependency resolver.
    /// </summary>
    public class SimpleDependencyResolver : IDependencyResolver, IDependencyScope
    {
        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(ContactsController))
            {
                var api = new ContactsController { Repository = new ContactRepository() };
                return api;
            }

            return null;
        }

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyScope"/>.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return this; 
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
        }
    }
}