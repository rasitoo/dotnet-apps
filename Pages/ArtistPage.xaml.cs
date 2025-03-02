using P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;

public partial class ArtistPage : ContentPage
{
	public ArtistPage(ArtistPageModel artistPageModel)
	{
		InitializeComponent();
		BindingContext = artistPageModel;
	}
}