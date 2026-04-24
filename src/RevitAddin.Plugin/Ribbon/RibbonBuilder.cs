// Ribbon/RibbonBuilder.cs
using System.Reflection;
using Autodesk.Revit.UI;

namespace RevitAddin.Plugin.Ribbon;

// Builds and maintains plugin ribbon UI (tab, panel, and action buttons).
public static class RibbonBuilder
{
    private const string TabName = "Revit Addin Pattern";
    private const string PanelName = "Main";

    public static void Build(UIControlledApplication application)
    {
        // Revit throws if tab already exists, so we ensure it safely.
        EnsureTab(application, TabName);

        // Reuse panel if already created in this session, otherwise create it.
        var panel = GetOrCreatePanel(application, TabName, PanelName);

        // Revit needs fully qualified command class names and assembly path.
        var assemblyPath = Assembly.GetExecutingAssembly().Location;

        var openWindowButton = new PushButtonData(
            "OpenWindowBtn",
            "Open Window",
            assemblyPath,
            "RevitAddin.Plugin.Commands.ShowWindowCommand");

        var openDockableButton = new PushButtonData(
            "OpenDockableBtn",
            "Open Dockable Pane",
            assemblyPath,
            "RevitAddin.Plugin.Commands.ShowDockablePaneCommand");

        panel.AddItem(openWindowButton);
        panel.AddItem(openDockableButton);
    }

    private static void EnsureTab(UIControlledApplication application, string tabName)
    {
        try
        {
            application.CreateRibbonTab(tabName);
        }
        catch
        {
            // Tab already exists in this Revit session.
        }
    }

    private static RibbonPanel GetOrCreatePanel(
        UIControlledApplication application,
        string tabName,
        string panelName)
    {
        foreach (var panel in application.GetRibbonPanels(tabName))
        {
            if (panel.Name == panelName)
            {
                return panel;
            }
        }

        return application.CreateRibbonPanel(tabName, panelName);
    }
}