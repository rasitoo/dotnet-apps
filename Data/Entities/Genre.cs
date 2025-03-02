namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Genre>? Songs { get; set; }
}
