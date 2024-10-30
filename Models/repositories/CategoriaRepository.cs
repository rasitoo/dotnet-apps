using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.repositories;

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

        if (Categorias.Count != 0)
            categoria.Id = Categorias.Last().Id + 1;
        else
            categoria.Id = 0;
        Categorias.Add(categoria);
    }

    public void Borrar(int pos)
    {
        if (pos != -1)
        {
            Categorias.RemoveAt(pos);
        }
    }

    public Categoria Consultar(int id)
    {
        if (id == -1)
        {
            return new Categoria("null");
        }
        else
        {
            foreach (var categoria in Categorias)
            {
                if (categoria.Id == id)
                {
                    return categoria;
                }
            }
        }

        return null;
    }
    public Categoria ConsultarNombre(string nombre)
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
        if (Categorias.Count > 0)
            return Categorias.ElementAt(pos);
        return new Categoria("null");
    }

    public void Modificar(int id, Categoria categoria)
    {
        int posicion = buscarPosicion(id);
        if (posicion != -1)
        {
            int ident = Categorias[posicion].Id;
            categoria.Id = ident;
            Categorias[posicion] = categoria;
        }
    }
}
