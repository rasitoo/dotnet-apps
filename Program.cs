using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.repositories;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Presenters;
using P03_02_DI_Contactos_TAPIADOR_rodrigo.Views;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        MainView mainView = new();
        Model model = new();
        MainPresenter mainPresenter = new MainPresenter(mainView, model);

        Application.Run(mainView);
    }
}