using System.Collections.ObjectModel;
using Caliburn.Micro;
using CaliburnSampleApp.Components.DataModels;

namespace CaliburnSampleApp.Components.ViewModels
{
    public class TemplatedDataGridViewModel : PropertyChangedBase
    {
        private readonly TemplatedDataGridDataModel dataModel;

        #region Properties
        /// <summary>
        /// Gets the path collection.
        /// </summary>
        /// <value>
        /// The path collection.
        /// </value>
        public ObservableCollection<string> PathCollection => this.dataModel.PathCollection;

        /// <summary>
        /// Gets the item collection.
        /// </summary>
        /// <value>
        /// The item collection.
        /// </value>
        public ObservableCollection<MyItem> ItemCollection => this.dataModel.ItemCollection;
        #endregion

        public TemplatedDataGridViewModel(TemplatedDataGridDataModel dataModel)
        {
            this.dataModel = dataModel;
        }
    }
}
