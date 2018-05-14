using Autofac;
using CaliburnSampleApp.Autofac;
using CaliburnSampleApp.Components.DataModels;

namespace CaliburnSampleApp.Components.ViewModels
{
    using System;
    using Caliburn.Micro;
    using System.Windows;
    
    public class MainViewModel : PropertyChangedBase
    {
        #region Fields
        private IEventAggregator eventAggregator;
        private readonly MainDataModel dataModel;
        #endregion

        #region Properties
        public SampleViewModel SampleViewModel { get; }
        public TemplateExamplesViewModel TemplateExamplesViewModel { get; }

        /// <summary>
        /// Get/Set stored message.
        /// </summary>
        public string Message
        {
            get => dataModel.Message;
            set
            {
                if (string.Equals(this.dataModel.Message, value.Trim(), StringComparison.CurrentCulture))
                    return;

                dataModel.Message = value;

                NotifyOfPropertyChange(() => Message); // Notify the message string.
                NotifyOfPropertyChange(() => CanShowMessage); // Toggle visibility of the button. 
            }
        }

        /// <summary>
        /// Turns button on/off, depending on the message not being null.
        /// </summary>
        public bool CanShowMessage => !string.IsNullOrWhiteSpace(Message);
        #endregion

        public MainViewModel(
            IEventAggregator eventAggregator, 
            MainDataModel dataModel, 
            SampleViewModel sampleViewModel,
            TemplatedDataGridViewModel templatedDataGridViewModel,
            TemplateExamplesViewModel templateExamplesViewModel)
        {
            this.eventAggregator = eventAggregator;

            this.dataModel = dataModel;
            this.dataModel.Message = "Initial Message.";

            SampleViewModel = sampleViewModel;
            TemplateExamplesViewModel = templateExamplesViewModel;

            // Resolve RandomData object from Autofac and initialise value.
            var rD = AppBootstrapper.Container.Resolve<RandomData>();
            rD.Name = "Main -> Random";
            rD.Id = 22;
        }

        /// <summary>
        /// Display the message in a messageBox.
        /// </summary>
        public void ShowMessage()
        {
            MessageBox.Show($"Message given: {Message}!");
        }
    }
}
