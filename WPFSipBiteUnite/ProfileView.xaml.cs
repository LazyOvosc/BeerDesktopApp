using System.Windows;
using System.Windows.Input;

namespace WPFSipBiteUnite;

public partial class ProfileView : Window
{
    public ProfileView()
    {
        InitializeComponent();
    }
    
    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            DragMove();
        }
    }
    
    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        
        Application.Current.Shutdown();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }
}