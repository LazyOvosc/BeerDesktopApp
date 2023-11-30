using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace WPFSipBiteUnite.CustomControls;

public partial class BindablePasswordBox : UserControl
{
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox));

    public string Password
    {
        get { return (string)GetValue(PasswordProperty); }
        set{SetValue(PasswordProperty, value);}
    }
    public BindablePasswordBox()
    {
        InitializeComponent();
        TxtPasswordBox.PasswordChanged += onPasswordChange;
    }

    private void onPasswordChange(object sender, RoutedEventArgs e)
    {
        Password = TxtPasswordBox.Password;
    }
}