using Microsoft.Practices.Prism.StoreApps;
using Microsoft.Practices.Unity;
using System;
using Windows.ApplicationModel.Activation;

namespace BlacksmithPress.Diabetes.WinRT
{
    sealed partial class App : MvvmAppBase
    {
        private readonly IUnityContainer _container = new UnityContainer();

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunchApplication(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate("Main", null);
        }

        protected override void OnInitialize(IActivatedEventArgs args)
        {
            _container.RegisterInstance(NavigationService);
        }

        protected override object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}
