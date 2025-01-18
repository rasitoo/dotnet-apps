using CommunityToolkit.Mvvm.ComponentModel;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

partial class CategoryViewModel(IRepositoryService<Category> categoryService) : ObservableObject
{

    [ObservableProperty]
    private object _activeView;

    [ObservableProperty]
    private ObservableCollection<Category> _categories = new(categoryService.GetAll());
}
