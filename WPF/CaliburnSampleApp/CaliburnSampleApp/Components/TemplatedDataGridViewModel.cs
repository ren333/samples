using System.Collections.ObjectModel;
using Caliburn.Micro;

namespace CaliburnSampleApp.Components
{
    public class TemplatedDataGridViewModel : PropertyChangedBase
    {
        private readonly TemplatedDataGridDataModel _dataModel;

        #region Properties
        /// <summary>
        /// Gets the path collection.
        /// </summary>
        /// <value>
        /// The path collection.
        /// </value>
        public ObservableCollection<string> PathCollection => _dataModel.PathCollection;

        /// <summary>
        /// Gets the item collection.
        /// </summary>
        /// <value>
        /// The item collection.
        /// </value>
        public ObservableCollection<MyItem> ItemCollection => _dataModel.ItemCollection;
        #endregion

        public TemplatedDataGridViewModel(TemplatedDataGridDataModel dataModel)
        {
            _dataModel = dataModel;
        }
    }
}
