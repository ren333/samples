namespace CaliburnSampleApp.Autofac
{
    using System.Linq;

    using Caliburn.Micro;

    using global::Autofac;

    /// <inheritdoc />
    /// <summary>The main autofac module.</summary>
    public class MainAutofacModule : Module
    {
        #region Methods

        /// <inheritdoc />
        /// <summary>According to convention, register each class that ends with DataModel, ViewModel or 
        /// View with Autofac
        /// </summary>
        /// <param name="builder">The autofac builder instance.</param>
        protected override void Load(ContainerBuilder builder)
        {
            // register data models
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray()).
                Where(type => type.Name.EndsWith("DataModel")).
                Where(type => !string.IsNullOrWhiteSpace(type.Namespace)).
                AsSelf().InstancePerDependency();

            // register view models
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray()).
                Where(type => type.Name.EndsWith("ViewModel")).
                Where(type => !string.IsNullOrWhiteSpace(type.Namespace)).
                AsSelf().InstancePerDependency();

            // register views
            builder.RegisterAssemblyTypes(AssemblySource.Instance.ToArray()).
                Where(type => type.Name.EndsWith("View")).
                Where(type => !string.IsNullOrWhiteSpace(type.Namespace)).
                AsSelf().InstancePerDependency();
        }

        #endregion
    }
}
