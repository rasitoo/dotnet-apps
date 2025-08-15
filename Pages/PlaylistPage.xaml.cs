using P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;

public partial class PlaylistPage : ContentPage
{
	public PlaylistPage(PlaylistPageModel playlistPageModel)
	{
		InitializeComponent();
		this.BindingContext = playlistPageModel;
	}
}