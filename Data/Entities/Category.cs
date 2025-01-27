namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Product> Products { get; set; } = [];

}
