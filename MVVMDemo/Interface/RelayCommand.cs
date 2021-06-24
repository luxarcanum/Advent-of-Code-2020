using System;
using System.Windows.Input;

namespace MVVMDemo
{
    /// <summary>
    /// A Command Object that implements ICommand
    /// Action and CanExecute methods are not required to have any parameters
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Members
        private Action mExecute;
        private Func<bool> mCanExecute;
        #endregion

        #region Public Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// A Relay Command that includes a canExecute predicate
        /// </summary>
        /// <param name="execute">The Delegated Command</param>
        /// <param name="canExecute">The method that determines if the command can be executed</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            mExecute = execute;
            mCanExecute = canExecute;
        }

        /// <summary>
        /// A Relay Command that can always be executed
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action execute) => mExecute = execute;
        #endregion

        #region Command Methods
        public bool CanExecute(object parameter) => mCanExecute == null ? true : mCanExecute();

        public void Execute(object parameter) => mExecute();
        #endregion
    }

    /// <summary>
    /// A Command Object that implements ICommand
    /// The Action<typeparamref name="T"/> of the Command takes a parameter of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RelayCommand<T> : ICommand
    {
        #region Private Members
        private Action<T> mExecute;
        private Predicate<object> mCanExecute;
        #endregion

        #region Public Events
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// A Relay Command that includes a canExecute predicate
        /// </summary>
        /// <param name="execute">The Delegated Command</param>
        /// <param name="canExecute">The method that determines if the command can be executed</param>
        public RelayCommand(Action<T> execute, Predicate<object> canExecute)
        {
            mExecute = execute;
            mCanExecute = canExecute;
        }

        /// <summary>
        /// A Relay Command that can always be executed
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<T> execute) => mExecute = execute;
        #endregion

        #region Command Methods
        public bool CanExecute(object parameter) => mCanExecute == null ? true : mCanExecute(parameter);

        public void Execute(object parameter) => mExecute((T)parameter);
        #endregion
    }
}
