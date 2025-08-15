using P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;

public partial class AlbumPage : ContentPage
{
	public AlbumPage(AlbumPageModel albumPageModel)
	{
		InitializeComponent();
		this.BindingContext = albumPageModel;
	}
}