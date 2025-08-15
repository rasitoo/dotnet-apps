﻿using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.Controls;

public partial class ListViewCategories : UserControl
{
    public ListViewCategories()
    {
        InitializeComponent();
    }
    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ListViewCategories), new PropertyMetadata(null));
    public Object SelectedItem
    {
        get { return (Object)GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
    public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register("SelectedItem", typeof(Object), typeof(ListViewCategories), new PropertyMetadata(null));
}