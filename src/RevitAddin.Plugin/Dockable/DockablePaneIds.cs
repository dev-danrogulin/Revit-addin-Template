using System;
using Autodesk.Revit.UI;

namespace RevitAddin.Plugin.Dockable;

public static class DockablePaneIds
{
    // Keep this GUID stable to preserve pane identity across sessions/versions.
    public static readonly DockablePaneId MainPaneId =
        new DockablePaneId(new Guid("7F4DFB3A-5F12-4C6B-9F6D-8C0B6B60F7A1"));
}