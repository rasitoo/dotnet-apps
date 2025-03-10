namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public interface IRestClient<T>
{
    public int Offset { get; set; } 
    public int Limit { get; set; }
    Task<T?> Get(int id);
    Task<List<T>> GetAll(int offset = 0, int Limit = 0);
    Task<T?> Add(T item);
    void Delete(T item);
    void Update(T item);
    void UpdatePlaylist(int id1, int id2);
}