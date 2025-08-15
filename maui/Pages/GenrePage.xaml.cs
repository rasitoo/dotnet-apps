using P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;

public partial class GenrePage : ContentPage
{
	public GenrePage(GenrePageModel genrePageModel)
	{
		InitializeComponent();
		BindingContext = genrePageModel;
	}
}