namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

public class Location
{
    public int Id { get; set; }
    public int ResidentsNum { get; set; }
    public string? Name { get; set; }
    public List<Character> Characters { get; set; } = [];
}