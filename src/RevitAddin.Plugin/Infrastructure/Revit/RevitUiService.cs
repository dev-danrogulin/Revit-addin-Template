using System;
using Autodesk.Revit.UI;
using RevitAddin.Plugin.Dockable;
using RevitAddin.Plugin.Views;

namespace RevitAddin.Plugin.Infrastructure.Revit;

// Centralized UI helper for Revit-facing actions.
// Keeps command classes thin and makes future refactoring easier.
public sealed class RevitUiService
{
    private readonly UIApplication _uiApplication;

    public RevitUiService(UIApplication uiApplication)
    {
        _uiApplication = uiApplication ?? throw new ArgumentNullException(nameof(uiApplication));
    }

    // Shows the plugin dockable pane if it was registered at startup.
    public void ShowMainDockablePane()
    {
        var pane = _uiApplication.GetDockablePane(DockablePaneIds.MainPaneId);
        pane.Show();
    }

    // Opens the plugin demo window as a modal dialog.
    public void ShowMainWindow()
    {
        var window = new MainWindow();
        window.ShowDialog();
    }
}
