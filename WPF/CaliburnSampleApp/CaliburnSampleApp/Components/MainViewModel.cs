using Autofac;
using CaliburnSampleApp.Autofac;
using CaliburnSampleApp.Main;

namespace CaliburnSampleApp.Components
{
    using System;
    using Caliburn.Micro;
    using System.Windows;
    
    public class MainViewModel : PropertyChangedBase
    {
        private IEventAggregator _eventAggregator;
        private readonly MainDataModel _dataModel;
        private readonly V1ViewModel _v1ViewModel;

        public MainViewModel(IEventAggregator eventAggregator, MainDataModel dataModel, V1ViewModel v1ViewModel)
        {
            _eventAggregator = eventAggregator;
            _dataModel = dataModel;
            _dataModel.Message = "Initial Message.";
            _v1ViewModel = v1ViewModel;

            // Initialise value of randomdata to something;
            var rD = AppBootstrapper.Container.Resolve<RandomData>();
            rD.Name = "Main -> Random";
            rD.Number = 22;
        }

        public V1ViewModel V1ViewModel
        {
            get { return _v1ViewModel; }
        }
        
        /// <summary>
        /// Get/Set stored message.
        /// </summary>
        public string Message
        {
            get { return _dataModel.Message; }
            set
            {
                if (string.Equals(_dataModel.Message, value.Trim(), StringComparison.CurrentCulture)) 
                    return;
                
                _dataModel.Message = value;
                
                NotifyOfPropertyChange(() => Message); // Notify the message string.
                NotifyOfPropertyChange(() => CanShowMessage); // Toggle visibility of the button. 
            }
        }

        /// <summary>
        /// Turns button on/off, depending on the message not being null.
        /// </summary>
        public bool CanShowMessage
        {
            get { return !string.IsNullOrWhiteSpace(Message); }
        }

        /// <summary>
        /// Display the message in a messageBox.
        /// </summary>
        public void ShowMessage()
        {
            MessageBox.Show(string.Format("Message given: {0}!", Message));
        }
    }
}
