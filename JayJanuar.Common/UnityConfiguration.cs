using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace JayJanuar.Common
{
    public class UnityConfiguration
    {
        private static IUnityContainer _container;

        public static void Initialise()
        {
            BuildUnityContainer();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void RegisterTypes()
        {
            _container.LoadConfiguration();
        }

        private static void BuildUnityContainer()
        {
            _container = new UnityContainer();
            RegisterTypes();
        }
    }
}
