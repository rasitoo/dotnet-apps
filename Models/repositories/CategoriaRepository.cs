using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;
using System.Xml.Serialization;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.repositories;

internal class CategoriaRepository : IRepository<Categoria>
{
    private string filePath = "./Categoria.xml";
    public List<Categoria> Categorias { get; set; }
    public CategoriaRepository()
    {
        Categorias = new();
        CargarDesdeXml();
    }
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
    public void Modificar(int pos, Categoria categoria)
    {
        if (pos != -1)
        {
            int ident = Categorias[pos].Id;
            categoria.Id = ident;
            Categorias[pos] = categoria;
        }
    }
    public void GuardarEnXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Categoria>));
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, Categorias);
        }
    }

    public void CargarDesdeXml()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Categoria>));
        using (StreamReader reader = new StreamReader(filePath))
        {
            Categorias = (List<Categoria>)serializer.Deserialize(reader);
        }
    }
}
