using System;
using System.Windows.Input;
using RevitAddin.Plugin.Infrastructure.Mvvm;

namespace RevitAddin.Plugin.ViewModels;

// ViewModel for the main dockable pane UI.
// Holds display state and commands bound from XAML.
public sealed class MainPaneViewModel : ViewModelBase {
    // Backing fields for bindable properties.
    private string _title = "Revit Addin Pattern";
    private string _statusText = "Ready";

    // Pane title shown in the UI.
    public string Title {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    // Status text shown in the UI and updated by RefreshCommand.
    public string StatusText {
        get => _statusText;
        set => SetProperty(ref _statusText, value);
    }

    // Command bound to a button in XAML.
    public ICommand RefreshCommand { get; }

    // Initialize commands and default state.
    public MainPaneViewModel() {
        RefreshCommand = new RelayCommand(OnRefresh);
    }

    // Simple demo action to prove command execution + property binding updates.
    private void OnRefresh() {
        StatusText = $"Last refresh: {DateTime.Now:HH:mm:ss}";
    }
}