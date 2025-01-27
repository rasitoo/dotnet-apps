namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

public interface IRepositoryService<T>
{
    T? Get(int id);
    List<T> GetAll();
    void Add(T item);
    void Delete(T item);
    void Update(T item);
}
