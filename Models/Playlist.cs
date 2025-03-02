namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Models;

class Playlist
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public List<Song>? Songs { get; set; }
}
