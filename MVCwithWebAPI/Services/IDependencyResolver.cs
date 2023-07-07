using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithWebAPI.Services
{
    public interface IDependencyResolver : IDisposable
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
        IDependencyScope BeginScope();
    }

    public interface IDependencyScope : IDisposable
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}