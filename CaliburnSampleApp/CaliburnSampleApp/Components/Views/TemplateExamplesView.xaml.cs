using System.Collections.ObjectModel;

namespace CaliburnSampleApp.Components.Views
{
    using System;
    using System.Windows;

    using CaliburnSampleApp.Components.DataModels;

    /// <summary>
    /// Interaction logic for TemplateExamplesView.xaml
    /// </summary>
    public partial class TemplateExamplesView
    {
        #region Fields
        /// <summary>
        /// The _path collection
        /// </summary>
        private ObservableCollection<string> _pathCollection = new ObservableCollection<string>();
        private ObservableCollection<MyItem> _itemCollection = new ObservableCollection<MyItem>();

        #endregion

        #region Properties
        /// <summary> Gets the path collection. </summary>
        /// <value> The path collection. </value>
        public ObservableCollection<string> PathCollection => _pathCollection;

        /// <summary> Gets the item collection. </summary>
        /// <value> The item collection. </value>
        public ObservableCollection<MyItem> ItemCollection => _itemCollection;
        #endregion

        public TemplateExamplesView()
        {
            InitializeComponent();

            _pathCollection.Add("./Images/1.jpg");
            _pathCollection.Add("./Images/2.jpg");
            _pathCollection.Add("./Images/3.jpg");
            _pathCollection.Add("./Images/4.jpg");
            _pathCollection.Add("Doing the string thing");
            _pathCollection.Add("./Images/5.jpg");
            _pathCollection.Add("./Images/6.jpg");
            _pathCollection.Add("More stringing");

            try
            {
                _itemCollection.Add(new MyItem { Name = "dfsdfsd", Address = "sdfsdfs", Stuff = "moreStuff", IsStuff = true, MyImage = @"./Images/1.jpg" });
                _itemCollection.Add(new MyItem { Name = "dfsd2fsd", Address = "sdfsd3423423432fs", Stuff = "moreStuff1132", IsStuff = false, MyImage = @"./Images/2.jpg" });
                _itemCollection.Add(new MyItem { Name = "dfsdf4sd", Address = "sdf342342sdfs", Stuff = "moreSt3432sssssuff", IsStuff = true, MyImage = @"./Images/3.jpg" });
                _itemCollection.Add(new MyItem { Name = "df222sdfsd", Address = "sdfs22222dfs", Stuff = "moreStuff3253252", IsStuff = true, MyImage = @"./Images/4.jpg" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("EXception: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}
