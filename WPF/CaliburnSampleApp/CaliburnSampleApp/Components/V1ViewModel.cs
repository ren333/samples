using Caliburn.Micro;
using System;

namespace CaliburnSampleApp.Components
{
    public class V1ViewModel : PropertyChangedBase
    {
        private readonly V1DataModel _dataModel;
        private IEventAggregator _eventAggregator;

        public V1ViewModel(IEventAggregator eventAggregator, V1DataModel dataModel)
        {
            _dataModel = dataModel;
            _eventAggregator = eventAggregator;
        }

        public int Id
        {
            get { return _dataModel.Id; }
            set
            {
                if (_dataModel.Id == value) return;
                
                _dataModel.Id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public string Description
        {
            get { return _dataModel.Description; }
            set
            {
                if (string.Equals(_dataModel.Description, value.Trim(), StringComparison.CurrentCulture)) 
                    return;
                
                _dataModel.Description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }

        public bool Hidden
        {
            get { return _dataModel.Hidden; }
            set
            {
                if (_dataModel.Hidden == value) 
                    return;
                
                _dataModel.Hidden = value;
                NotifyOfPropertyChange(() => Hidden);
            }
        }
    }
}
