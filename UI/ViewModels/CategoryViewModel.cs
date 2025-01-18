using CommunityToolkit.Mvvm.ComponentModel;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;
using System.Collections.ObjectModel;

namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.UI.ViewModels;

partial class CategoryViewModel : ObservableObject
{
    private readonly IRepositoryService<Category> _categoryService;

    public CategoryViewModel(IRepositoryService<Category> categoryService)
    {
        _categoryService = categoryService;
        _categories = new ObservableCollection<Category>(_categoryService.GetAll());
    }

    [ObservableProperty]
    private object _activeView;

    [ObservableProperty]
    private ObservableCollection<Category> _categories;
}
