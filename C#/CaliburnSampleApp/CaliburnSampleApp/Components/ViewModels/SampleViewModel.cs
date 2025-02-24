using Caliburn.Micro;
using System;
using Autofac;
using CaliburnSampleApp.Autofac;
using CaliburnSampleApp.Components.DataModels;

namespace CaliburnSampleApp.Components.ViewModels
{
    /// <summary>
    /// Example viewmode for demonstrating Caliburn binding.
    /// </summary>
    public class SampleViewModel : PropertyChangedBase
    {
        #region Fields
        private readonly SampleDataModel dataModel;
        private IEventAggregator eventAggregator;
        #endregion

        #region Properties
        /// <summary>
        /// Get/Set for display.
        /// </summary>
        public int Id
        {
            get => this.dataModel.Id;
            set
            {
                if (this.dataModel.Id == value)
                    return;

                this.dataModel.Id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        /// <summary>
        /// Get/Set for description.
        /// </summary>
        public string Description
        {
            get => this.dataModel.Description;
            set
            {
                if (string.Equals(this.dataModel.Description, value.Trim(), StringComparison.CurrentCulture))
                    return;

                this.dataModel.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        /// <summary>
        /// Get/Set for hidden boolean value.
        /// </summary>
        public bool IsEnabled
        {
            get => this.dataModel.IsEnabled;
            set
            {
                if (this.dataModel.IsEnabled == value)
                    return;

                this.dataModel.IsEnabled = value;
                NotifyOfPropertyChange(() => IsEnabled);
            }
        }
        #endregion

        public SampleViewModel(IEventAggregator eventAggregator, SampleDataModel dataModel)
        {
            this.dataModel = dataModel;
            this.eventAggregator = eventAggregator;

            // Resolve RandomData class from Autofac container and assign it to the DataModel.
            this.dataModel.RandomData = AppBootstrapper.Container.Resolve<RandomData>();
        }
    }
}
