namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

internal class Category
{
    public string Name { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public Category() { }
    public Category(string nombre)
    {
        Name = nombre;
    }
}
