namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

public interface IRepositoryService<T>
{
    Task<T?> Get(int id);
    Task<List<T>> GetAll();
    void Add(T item);
    void Delete(T item);
    void Update(T item);
}