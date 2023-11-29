using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace WPFSipBiteUnite.CustomControls;

public partial class BindablePasswordBox : UserControl
{
    public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

    public SecureString Password
    {
        get { return (SecureString)GetValue(PasswordProperty); }
        set{SetValue(PasswordProperty, value);}
    }
    public BindablePasswordBox()
    {
        InitializeComponent();
        TxtPasswordBox.PasswordChanged += onPasswordChange;
    }

    private void onPasswordChange(object sender, RoutedEventArgs e)
    {
        Password = TxtPasswordBox.SecurePassword;
    }
}