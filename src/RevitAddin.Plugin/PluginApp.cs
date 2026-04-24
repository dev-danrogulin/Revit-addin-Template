// PluginApp.cs
using Autodesk.Revit.UI;
using RevitAddin.Plugin.Dockable;
using RevitAddin.Plugin.Ribbon;

namespace RevitAddin.Plugin;

// Revit entry point for application-level startup/shutdown events.
public sealed class PluginApp : IExternalApplication
{
    public Result OnStartup(UIControlledApplication application)
    {
        // Create ribbon tab/panel/buttons for user actions.
        RibbonBuilder.Build(application);

        // Register dockable pane once during startup.
        application.RegisterDockablePane(
            DockablePaneIds.MainPaneId,
            "Main Pane",
            new MainDockablePaneProvider());

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        // Reserved for cleanup when plugin grows (events, services, disposables).
        return Result.Succeeded;
    }
}