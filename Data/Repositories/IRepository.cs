namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Data.Repositories;

internal interface IRepository<T>
{
    T Get(int id);
    List<T> GetAll();
    void Add(T item);
    void Delete(T item);
    void Update(T item);
}
