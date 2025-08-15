namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.dataclases;

public class Categoria
{
    public string Nombre { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        return $"{nameof(Nombre)}: {Nombre}";
    }

    public Categoria() { }
    public Categoria(string nombre)
    {
        Nombre = nombre;
    }

}
