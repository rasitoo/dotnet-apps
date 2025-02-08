using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.Controls;

public partial class ListViewCharacters : UserControl
{
    public ListViewCharacters()
    {
        InitializeComponent();
    }
    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ListViewCharacters), new PropertyMetadata(null));
    public Object SelectedCharacter
    {
        get { return (Object)GetValue(SelectedCharacterProperty); }
        set { SetValue(SelectedCharacterProperty, value); }
    }
    public static readonly DependencyProperty SelectedCharacterProperty =
        DependencyProperty.Register("SelectedCharacter", typeof(Object), typeof(ListViewCharacters), new PropertyMetadata(null));
    public double ScrollPercentage
    {
        get { return (double)GetValue(ScrollPercentageProperty); }
        set { SetValue(ScrollPercentageProperty, value); }
    }

    public static readonly DependencyProperty ScrollPercentageProperty =
        DependencyProperty.Register("ScrollPercentage", typeof(double), typeof(ListViewCharacters), new PropertyMetadata(0.0));

    private void ListCharacters_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        if (e.ExtentHeight > 0)
        {
            ScrollPercentage = e.VerticalOffset / e.ExtentHeight;
        }
    }
}