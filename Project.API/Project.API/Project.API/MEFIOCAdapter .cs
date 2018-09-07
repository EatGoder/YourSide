using ServiceStack.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Web;

namespace Project.API
{
    internal class MEFIOCAdapter : IContainerAdapter
    {
        private readonly CompositionContainer _container;

        internal MEFIOCAdapter(CompositionContainer container)
        {
            _container = container;
        }

        public T TryResolve<T>()
        {
            return _container.GetExportedValueOrDefault<T>();
        }

        public T Resolve<T>()
        {
            return _container.GetExportedValue<T>();
        }
    }
}