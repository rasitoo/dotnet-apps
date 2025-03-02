using P07_01_DI_Contactos_TAPIADOR_rodrigo.PageModels;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageModel settingsPageModel)
	{
		InitializeComponent();
		BindingContext = settingsPageModel;
	}
}