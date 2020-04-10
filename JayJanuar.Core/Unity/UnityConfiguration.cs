using JayJanuar.Core.Mappers;
using JayJanuar.Core.Services;
using JayJanuar.Data.UOW;
using Unity;
using Unity.Resolution;

namespace JayJanuar.Core.Unity
{
    public class UnityConfiguration
    {
        private static IUnityContainer container;

        public static void Initialise()
        {
            BuildUnityContainer();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static T Resolve<T>(ResolverOverride[] resolverOverrides)
        {
            return container.Resolve<T>(resolverOverrides);
        }
        private static void RegisterTypes()
        {
            container.RegisterType<IUnitOfWork, RestUnitOfWork>();
            container.RegisterType<IPersonService, PersonServices>();
            container.RegisterType<IDisplayPersonMapper, DisplayPersonMapper>();
        }

        private static void BuildUnityContainer()
        {
            container = new UnityContainer();
            RegisterTypes();
        }
    }
}
