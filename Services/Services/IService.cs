namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

public interface IService<T>
{
    public int Total { get; set; }
    public int TotalPages { get; set; }
    Task<T?> Get(int id, int subItemsPage = 0, double subItemsPerPage = 0);
    Task<List<T>> GetAll(int page = 1);
    void Add(T item);
    void Delete(T item);
    void Update(T item);
}