using System.Windows;
using RevitAddin.Plugin.ViewModels;

namespace RevitAddin.Plugin.Views;

// Regular WPF window launched from ribbon command.
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // For now the same ViewModel is reused to keep the template minimal.
        DataContext = new MainPaneViewModel(); // later can be MainWindowViewModel
    }
}