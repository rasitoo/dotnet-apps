namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double? Price { get; set; }
    public string? ImageUri { get; set; }
    public int? LocationId { get; set; }
    public Location? Location { get; set; }
}