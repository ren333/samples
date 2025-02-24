
namespace WpfPluginInterface
{
    public interface IWpfPlugin
    {
        #region Properties
        /// <summary>
        /// Name of the plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Views.
        /// </summary>
        IEnumerable<Type> ViewTypes { get; }
        
        /// <summary>
        /// ViewModels.
        /// </summary>
        IEnumerable<Type> ViewModelTypes { get; }
        #endregion
    }
}
