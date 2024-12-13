using Autofac;
using Caliburn.Micro;
using CSharpFeaturesDemo.Infra;
using CSharpFeaturesDemo.ViewModels;
using CSharpFeaturesDemo.Views;
using EventAggregator;
using EventAggregator.Interfaces;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows;
using WpfPluginInterface;
using IContainer = Autofac.IContainer;

namespace CSharpFeaturesDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            // Register EventAggregator as a singleton
            builder.RegisterType<EventAggregator.EventAggregator>().As<EventAggregator.Interfaces.IEventAggregator>().SingleInstance();

            // Register MainView and MainViewModel
            builder.RegisterType<MainView>().AsSelf().SingleInstance();
            builder.RegisterType<MainViewModel>().AsSelf().InstancePerDependency();

            LoadPlugins(builder);

            _container = builder.Build();

            var mainWindow = _container.Resolve<MainView>();
            mainWindow.Show();
        }

        private void LoadPlugins(ContainerBuilder builder)
        {
            var pluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");

            if (!Directory.Exists(pluginPath))
            {
                Directory.CreateDirectory(pluginPath);
            }

            var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");

            foreach (var pluginFile in pluginFiles)
            {
                var assembly = Assembly.LoadFrom(pluginFile);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IWpfPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

                foreach (var pluginType in pluginTypes)
                {
                    var plugin = (IWpfPlugin)Activator.CreateInstance(pluginType);

                    foreach (var viewType in plugin.ViewTypes)
                    {
                        builder.RegisterType(viewType).AsSelf().InstancePerDependency();
                    }

                    foreach (var viewModelType in plugin.ViewModelTypes)
                    {
                        builder.RegisterType(viewModelType).AsSelf().InstancePerDependency();
                    }

                    builder.RegisterInstance(plugin).As<IWpfPlugin>();


                    builder.RegisterViewsAndViewModels(assembly);
                }
            }
        }
    }

}
