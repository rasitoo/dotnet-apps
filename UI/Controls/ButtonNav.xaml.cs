using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Controls;

public partial class ButtonNav : UserControl
{
    public ButtonNav()
    {
        InitializeComponent();
    }
    public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.Register("IsChecked", typeof(bool), typeof(ButtonNav));
    public bool IsChecked
    {
        get { return (bool)GetValue(IsCheckedProperty); }
        set { SetValue(IsCheckedProperty, value); }
    }
    public static readonly DependencyProperty GroupNameProperty =
        DependencyProperty.Register("GroupName", typeof(string), typeof(ButtonNav));
    public string GroupName
    {
        get { return (string)GetValue(GroupNameProperty); }
        set { SetValue(GroupNameProperty, value); }
    }
    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register("Command", typeof(ICommand), typeof(ButtonNav));
    public ICommand Command
    {
        get { return (ICommand)GetValue(CommandProperty); }
        set { SetValue(CommandProperty, value); }
    }
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(ButtonNav));
    public string Icon
    {
        get { return (string)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(ButtonNav));
    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
}