namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public string? ImageUri { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
}