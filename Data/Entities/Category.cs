namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

internal class Category
{
    public string Name { get; set; }
    public int Id { get; set; }

    public Category(string nombre)
    {
        Name = nombre;
    }
}
