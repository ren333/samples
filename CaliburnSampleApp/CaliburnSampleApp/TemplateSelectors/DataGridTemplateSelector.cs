namespace CaliburnSampleApp.TemplateSelectors
{
    using System.Windows;
    using System.Windows.Controls;

    public class DataGridTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate StringTemplate { get; set; }

        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate" /> based on custom logic.
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The data-bound object.</param>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate" /> or null. The default value is null.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var path = (string)item;
            var ext = System.IO.Path.GetExtension(path);

            if (System.IO.File.Exists(path) && (ext == ".jpg" || ext == ".png"))
            {
                return ImageTemplate;
            }

            return StringTemplate;
        }
    }
}
