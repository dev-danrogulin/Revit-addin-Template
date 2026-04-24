using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using RevitAddin.Plugin.Dockable;

namespace RevitAddin.Plugin.Commands;

[Transaction(TransactionMode.Manual)]
// Shows the dockable pane registered at plugin startup.
public sealed class ShowDockablePaneCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
    {
        try
        {
            // Resolve pane by stable ID and show it in the Revit UI.
            var pane = commandData.Application.GetDockablePane(DockablePaneIds.MainPaneId);
            pane.Show();
            return Result.Succeeded;
        }
        catch (System.Exception ex)
        {
            // Revit displays this message when command execution fails.
            message = ex.Message;
            return Result.Failed;
        }
    }
}