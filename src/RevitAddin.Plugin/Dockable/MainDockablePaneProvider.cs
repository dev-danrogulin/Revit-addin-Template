using Autodesk.Revit.UI;
using RevitAddin.Plugin.ViewModels;
using RevitAddin.Plugin.Views;

namespace RevitAddin.Plugin.Dockable;

// Supplies WPF content and initial state for Revit dockable pane.
public sealed class MainDockablePaneProvider : IDockablePaneProvider
{
    public void SetupDockablePane(DockablePaneProviderData data)
    {
        // Create view and attach its ViewModel (MVVM binding source).
        var view = new MainPaneView
        {
            DataContext = new MainPaneViewModel()
        };

        data.FrameworkElement = view;

        // Initial docking behavior when pane is first shown.
        data.InitialState = new DockablePaneState
        {
            DockPosition = DockPosition.Right
        };
    }
}