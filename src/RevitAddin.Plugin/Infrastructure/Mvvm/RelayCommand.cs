using System;
using System.Windows.Input;

namespace RevitAddin.Plugin.Infrastructure.Mvvm;

// Simple ICommand implementation for MVVM button/actions binding.
public sealed class RelayCommand : ICommand {
    // Main action to run when the command executes.
    private readonly Action _execute;
    // Optional predicate that controls whether the command is currently enabled.
    private readonly Func<bool>? _canExecute;

    // execute is required; canExecute is optional.
    public RelayCommand(Action execute, Func<bool>? canExecute = null) {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    // WPF listens to this event and re-evaluates CanExecute for bound controls.
    public event EventHandler? CanExecuteChanged;

    // Returns whether the command can execute right now.
    // If no predicate is provided, the command is always enabled.
    public bool CanExecute(object? parameter) {
        return _canExecute?.Invoke() ?? true;
    }

    // Executes the command action.
    public void Execute(object? parameter) {
        _execute();
    }

    // Triggers WPF to refresh command enabled/disabled state in the UI.
    public void RaiseCanExecuteChanged() {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}