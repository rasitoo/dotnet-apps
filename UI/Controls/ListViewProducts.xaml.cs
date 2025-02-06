using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.UI.Controls;

public partial class ListViewProducts : UserControl
{
    public ListViewProducts()
    {
        InitializeComponent();
    }
    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ListViewProducts), new PropertyMetadata(null));
    public Object SelectedProduct
    {
        get { return (Object)GetValue(SelectedProductProperty); }
        set { SetValue(SelectedProductProperty, value); }
    }
    public static readonly DependencyProperty SelectedProductProperty =
        DependencyProperty.Register("SelectedProduct", typeof(Object), typeof(ListViewProducts), new PropertyMetadata(null));
}