namespace P05_01_DI_Productos_TAPIADOR_rodrigo.Data.Entities;

internal class Category
{
    public string Nombre { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        return $"{nameof(Nombre)}: {Nombre}";
    }

    public Category() { }
    public Category(string nombre)
    {
        Nombre = nombre;
    }
}
