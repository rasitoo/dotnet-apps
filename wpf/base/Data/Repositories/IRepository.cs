namespace P05_01_DI_Productos_TAPIADOR_rodrigo.Data.Repositories;

internal interface IRepository<T>
{
    T Get(int id);
    List<T> GetAll();
    void Add(T objeto);
    void Delete(int id);
    void Update(int pos, T objeto);
}
