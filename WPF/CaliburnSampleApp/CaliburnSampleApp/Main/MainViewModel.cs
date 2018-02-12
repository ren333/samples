namespace CaliburnSampleApp.Main
{
    using System;
    using Caliburn.Micro;
    using System.Windows;
    
    //using WPFCaliburnApp.Features.F1;

    public class MainViewModel : PropertyChangedBase
    {
        private IEventAggregator _eventAggregator;
        private readonly MainDataModel _dataModel;

        //public MainViewModel(IEventAggregator eventAggregator, MainDataModel dataModel, F1ViewModel f1View)
        public MainViewModel(IEventAggregator eventAggregator, MainDataModel dataModel)
        {
            _eventAggregator = eventAggregator;
            _dataModel = dataModel;
            _dataModel.Message = "Initial Message.";
            //this.f1View = f1View;
        }
        
        //private F1ViewModel f1View;
/*
        public F1ViewModel F1View
        {
            get { return f1View; }
        }
*/
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
