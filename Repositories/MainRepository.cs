namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Repositories;

internal class MainRepository
{
    internal CategoriaRepository CategoriaRepository { get ; set ; }
    internal ProductoRepository ProductoRepository1 { get ; set; }

    public MainRepository()
    {
        CategoriaRepository = new();
        ProductoRepository1 = new();
    }
}
