using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace CaliburnSampleApp.Components.DataModels
{
    public class TemplatedDataGridDataModel
    {
        #region Fields
        /// <summary>
        /// The _path collection
        /// </summary>
        private readonly ObservableCollection<string> _pathCollection = new ObservableCollection<string>();
        private readonly ObservableCollection<MyItem> _itemCollection = new ObservableCollection<MyItem>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets the path collection.
        /// </summary>
        /// <value>
        /// The path collection.
        /// </value>
        public ObservableCollection<string> PathCollection => _pathCollection;

        /// <summary>
        /// Gets the item collection.
        /// </summary>
        /// <value>
        /// The item collection.
        /// </value>
        public ObservableCollection<MyItem> ItemCollection => _itemCollection;
        #endregion

        public TemplatedDataGridDataModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            _pathCollection.Add("Images/1.jpg");
            _pathCollection.Add("Images/2.jpg");
            _pathCollection.Add("Images/3.jpg");
            _pathCollection.Add("Images/4.jpg");
            _pathCollection.Add("Doing the string thing");
            _pathCollection.Add("Images/5.jpg");
            _pathCollection.Add("Images/6.jpg");
            _pathCollection.Add("More stringing");

            try
            {
                _itemCollection.Add(new MyItem { Name = "dfsdfsd", Address = "sdfsdfs", Stuff = "moreStuff", IsStuff = true, MyImage = _pathCollection[1] });
                _itemCollection.Add(new MyItem { Name = "dfsd2fsd", Address = "sdfsd3423423432fs", Stuff = "moreStuff1132", IsStuff = false, MyImage = _pathCollection[0] });
                _itemCollection.Add(new MyItem { Name = "dfsdf4sd", Address = "sdf342342sdfs", Stuff = "moreSt3432sssssuff", IsStuff = true, MyImage = _pathCollection[2] });
                _itemCollection.Add(new MyItem { Name = "df222sdfsd", Address = "sdfs22222dfs", Stuff = "moreStuff3253252", IsStuff = true, MyImage = _pathCollection[3] });
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXception: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

    }
}
