
namespace WpfPluginInterface
{
    public interface IWpfPlugin
    {
        string Name { get; }
        IEnumerable<Type> ViewTypes { get; }
        IEnumerable<Type> ViewModelTypes { get; }
    }
}
