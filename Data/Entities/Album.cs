namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

class Album
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int? Year { get; set; }
    public string? Picture { get; set; }
    public string? Mbid { get; set; }
    public int? Artist_id { get; set; }
    public Artist? Artist { get; set; }
    public List<Genre>? Songs { get; set; }


}
