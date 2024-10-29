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

    public void Borrar(int id)
    {
        int posicion = buscarPosicion(id);
        if (posicion != -1)
        {
            Categorias.RemoveAt(posicion);
        }
    }

    public Categoria Consultar(int id)
    {
        foreach (var categoria in Categorias)
        {
            if (categoria.Id == id)
            {
                return categoria;
            }
        }

        return null;
    }
    public Categoria ConsultarNombre(String nombre)
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

    public int buscarPosicion(int id)
    {
        return Categorias.FindIndex(c => c.Id == id);
    }
    public Categoria buscarDesdePosicion(int pos)
    {
        return Categorias.ElementAt(pos);
    }

    public void Modificar(int id, Categoria categoria)
    {
        int posicion = buscarPosicion(id);
        if (posicion != -1)
        {
            Categorias[posicion] = categoria;
        }
    }
}
