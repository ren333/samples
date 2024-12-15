﻿using Autofac;
using CSharpFeaturesDemo.Infra;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfPluginInterface;

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

            Plugins = [];
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
