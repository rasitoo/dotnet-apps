namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Models;

class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Year { get; set; }
    public string? Picture { get; set; }
    public int? Mbid { get; set; }
    public int? Artist_id { get; set; }
    public Artist? Artist { get; set; }
    public List<Song>? Songs { get; set; }


}
