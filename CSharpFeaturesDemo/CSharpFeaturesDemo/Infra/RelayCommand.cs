

namespace CSharpFeaturesDemo.Infra
{
    using System.Windows;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        #region Properties
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public event EventHandler? CanExecuteChanged;
        #endregion

        #region Methods
        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter == null)
                return false;

            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
    }
}
