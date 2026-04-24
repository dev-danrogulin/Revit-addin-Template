using System.Windows.Controls;

namespace RevitAddin.Plugin.Views;

// Dockable pane view host. DataContext is assigned by the pane provider.
public partial class MainPaneView : UserControl {
    public MainPaneView() {
        InitializeComponent();
    }
}