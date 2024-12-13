using Autofac;
using Caliburn.Micro;
using CSharpFeaturesDemo.Infra;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using EventAggregator;
using WpfPluginInterface;
using EventAggregator.Interfaces;

namespace CSharpFeaturesDemo.ViewModels
{
    public class MainViewModel : ViewModelBase, EventAggregator.Interfaces.IHandle<string>
    {
        #region Properties
        private readonly EventAggregator.Interfaces.IEventAggregator _eventAggregator;
        private readonly ILifetimeScope _lifetimeScope;

        public ObservableCollection<object> LoadedViews { get; } = [];
        public ObservableCollection<IWpfPlugin> Plugins { get; }
        public ICommand LoadPluginCommand { get; }
        #endregion

        public MainViewModel(EventAggregator.Interfaces.IEventAggregator eventAggregator, ILifetimeScope lifetimeScope)
        {
            _eventAggregator = eventAggregator;
            _lifetimeScope = lifetimeScope;

            _eventAggregator.Subscribe(this);

            Plugins = new ObservableCollection<IWpfPlugin>();
            LoadPluginCommand = new RelayCommand(LoadPlugin);

            foreach (var plugin in _lifetimeScope.Resolve<IEnumerable<IWpfPlugin>>())
            {
                Plugins.Add(plugin);
            }
        }

        private void LoadPlugin(object parameter)
        {
            if (parameter is Type viewType)
            {
                var view = _lifetimeScope.Resolve(viewType);
                LoadedViews.Add(view);
            }
        }

        public void Handle(string message)
        {
            MessageBox.Show(message);
        }
    }
}
