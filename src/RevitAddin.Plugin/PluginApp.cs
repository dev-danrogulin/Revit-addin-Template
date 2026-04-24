using Autodesk.Revit.UI;

namespace RevitAddin.Plugin;

public sealed class PluginApp : IExternalApplication
{
    public Result OnStartup(UIControlledApplication application)
    {
        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }
}
