// <copyright file="ViewModelCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WPFSipBiteUnite.ViewModel
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A command that relays its functionality to other objects by invoking delegates.
    /// </summary>
    public class ViewModelCommand : ICommand
    {
        private readonly Action<object?> _executeAction;
        private readonly Predicate<object?>? _canExecuteAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The execution logic.</param>
        public ViewModelCommand(Action<object?> executeAction)
        {
            this._executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The execution logic.</param>
        /// <param name="canExecuteAction">The execution status logic.</param>
        public ViewModelCommand(Action<object?> executeAction, Predicate<object?>? canExecuteAction)
        {
            this._executeAction = executeAction ?? throw new ArgumentNullException(nameof(executeAction));
            this._canExecuteAction = canExecuteAction;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns>A boolean value indicating if the command can be executed.</returns>
        public bool CanExecute(object? parameter)
        {
            return this._canExecuteAction?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public void Execute(object? parameter)
        {
            this._executeAction(parameter);
        }
    }
}
