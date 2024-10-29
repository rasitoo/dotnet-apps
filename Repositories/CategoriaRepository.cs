using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Repositories;

internal class CategoriaRepository : IRepository<Categoria>
{
    public CategoriaRepository()
    {
        Categorias = new();
        Anadir(new Categoria("Otros"));
    }

    public List<Categoria> Categorias { get; set; }

    public void Anadir(Categoria categoria)
    {
        Categorias.Add(categoria);
    }

    public void Borrar(string nombre)
    {
        int posicion = buscarPosicion(nombre);
        if (posicion != -1)
        {
            Categorias.RemoveAt(posicion);
        }
    }

    public Categoria Consultar(string nombre)
    {
        foreach (var categoria in Categorias)
        {
            if (categoria.Nombre.Equals(nombre))
            {
                return categoria;
            }
        }

        return null;
    }

    public int buscarPosicion(string nombre)
    {
        return Categorias.FindIndex(c => c.Nombre.Equals(nombre));
    }

    public void Modificar(string nombre, Categoria categoria)
    {
        int posicion = buscarPosicion(nombre);
        if (posicion != -1)
        {
            Categorias[posicion] = categoria;
        }
    }
}
