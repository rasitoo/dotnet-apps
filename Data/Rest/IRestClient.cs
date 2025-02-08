using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

public interface IRestClient<T>
{
    public int Total { get; set; }
    public int TotalPages { get; set; }
    Task<T?> Get(int id);
    Task<List<T>> GetAll(int page);
    void Add(T item);
    void Delete(T item);
    void Update(T item);
}
