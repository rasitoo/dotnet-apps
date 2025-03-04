namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Publisher { get; set; }
    public int? Year { get; set; }
    public int? Track_num { get; set; }
    public string File { get; set; }
    public int? Album_id { get; set; }
    public int? Genre_id { get; set; }
    public Album? Album { get; set; }
    public Genre? Genre { get; set; }
    public List<Playlist>? Playlists { get; set; }
}
