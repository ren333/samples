using Autofac;
using CSharpFeaturesDemo.Infra;
using EventAggregator.Interfaces;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfPluginInterface;

namespace CSharpFeaturesDemo.ViewModels
{
    public class MainViewModel : ViewModelBase, IHandle<string>
    {
        #region Properties
        private readonly IEventAggregator _eventAggregator;
        private readonly ILifetimeScope _lifetimeScope;

        public ObservableCollection<object> LoadedViews { get; } = [];
        public ObservableCollection<IWpfPlugin> Plugins { get; }
        public ICommand LoadPluginCommand { get; }

        public ICommand ShowMessageCommand { get; }
        #endregion

        public MainViewModel(IEventAggregator eventAggregator, ILifetimeScope lifetimeScope)
        {
            _eventAggregator = eventAggregator;
            _lifetimeScope = lifetimeScope;
            _eventAggregator.Subscribe(this);

            Plugins = [];
            LoadPluginCommand = new RelayCommand(LoadPlugin);

            foreach (var plugin in _lifetimeScope.Resolve<IEnumerable<IWpfPlugin>>())
                Plugins.Add(plugin);

            ShowMessageCommand = new RelayCommand(_ => OnMessageButtonClick());
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

        private void OnMessageButtonClick()
        {
            _eventAggregator.Publish("Hello from the toolbar!"); // Display MessageBox.
        }
    }
}
