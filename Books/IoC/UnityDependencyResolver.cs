using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.IoC
{
    using System.Web.Mvc;

    using Microsoft.Practices.Unity;

    public class UnityDependencyResolver : IDependencyResolver
    {
        private readonly IUnityContainer conteiner;

        private readonly IDependencyResolver resolver;

        public UnityDependencyResolver(IUnityContainer conteiner, IDependencyResolver resolver)
        {
            this.conteiner = conteiner;
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this.conteiner.Resolve(serviceType);
            }
            catch
            {
                return this.resolver.GetService(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this.conteiner.ResolveAll(serviceType);
            }
            catch
            {
                return this.resolver.GetServices(serviceType);
            }
        }
    }
}