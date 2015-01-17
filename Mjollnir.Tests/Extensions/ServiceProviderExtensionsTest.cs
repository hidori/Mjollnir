using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir.Extensions.Tests
{
    [TestClass]
    public class ServiceProviderExtensionsTest
    {
        interface IService1 { }

        interface IService2 { }

        class Service1 : IService1
        {
            // nothing to do.
        }

        class ServiceProivider : IServiceProvider
        {
            public ServiceProivider()
            {

                this.Service1 = new Service1();
            }

            public Service1 Service1 { get; private set; }

            public object GetService(Type serviceType)
            {
                if (serviceType == typeof(IService1))
                {
                    return this.Service1;
                }

                return null;
            }
        }

        [TestMethod]
        public void GetServiceTest()
        {
            var provider = new ServiceProivider();

            AssertEx.Throws<ArgumentNullException>(() => ServiceProviderExtensions.GetService<string>(null));

            provider.GetService<IService1>().Is(provider.Service1);
            provider.GetService<IService2>().IsNull<IService2>();
        }
    }
}
