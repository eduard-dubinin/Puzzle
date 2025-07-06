using UnityEngine;
using Zenject;

namespace Project.Utility
{
    public static class ZenjectExtension
    {
        public static void BindInterfacesInstance<T>(this DiContainer diContainer, T instance) where T : Object
        {
            diContainer.BindInterfacesTo<T>().FromInstance(instance).AsSingle();
        }

        public static void BindInterfacesAndSelfInstance<T>(this DiContainer diContainer, T instance) where T : Object
        {
            diContainer.BindInterfacesAndSelfTo<T>().FromInstance(instance).AsSingle();
        }

        public static void BindSignalBus(this DiContainer diContainer)
        {
            if (diContainer.HasBinding<SignalBus>()) return;
            SignalBusInstaller.Install(diContainer);
        }
    }
}