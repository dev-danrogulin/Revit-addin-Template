using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using RevitAddin.Plugin.Views;

namespace RevitAddin.Plugin.Commands;

[Transaction(TransactionMode.Manual)]
// Opens a regular WPF window from the Revit ribbon.
public sealed class ShowWindowCommand : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
    {
        try
        {
            // Simple modal window flow for the template baseline.
            var window = new MainWindow();
            window.ShowDialog(); // modal for now
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