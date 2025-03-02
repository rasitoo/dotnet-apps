namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Models;

class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Song>? Songs { get; set; }
}
