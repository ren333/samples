using Caliburn.Micro;
using System;
using Autofac;
using CaliburnSampleApp.Autofac;

namespace CaliburnSampleApp.Components
{
    /// <summary>
    /// Example viewmode for demonstrating Caliburn binding.
    /// </summary>
    public class V1ViewModel : PropertyChangedBase
    {
        #region Fields
        private readonly V1DataModel _dataModel;
        private IEventAggregator _eventAggregator;
        #endregion

        #region Properties
        /// <summary>
        /// Get/Set for display.
        /// </summary>
        public int Id
        {
            get => _dataModel.Id;
            set
            {
                if (_dataModel.Id == value)
                    return;

                _dataModel.Id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        /// <summary>
        /// Get/Set for description.
        /// </summary>
        public string Description
        {
            get => _dataModel.Description;
            set
            {
                if (string.Equals(_dataModel.Description, value.Trim(), StringComparison.CurrentCulture))
                    return;

                _dataModel.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        /// <summary>
        /// Get/Set for hidden boolean value.
        /// </summary>
        public bool IsEnabled
        {
            get => _dataModel.IsEnabled;
            set
            {
                if (_dataModel.IsEnabled == value)
                    return;

                _dataModel.IsEnabled = value;
                NotifyOfPropertyChange(() => IsEnabled);
            }
        }
        #endregion

        public V1ViewModel(IEventAggregator eventAggregator, V1DataModel dataModel)
        {
            _dataModel = dataModel;
            _eventAggregator = eventAggregator;

            // Resolve RandomData class from Autofac container and assign it to the DataModel.
            _dataModel.RandomData = AppBootstrapper.Container.Resolve<RandomData>();
        }
    }
}
