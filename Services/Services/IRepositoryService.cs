namespace P06_01_DI_Contactos_TAPIADOR_rodrigo.Services.Services;

internal interface IRepositoryService<T>
{
    T Get(int id);
    List<T> GetAll();
    void Add(T objeto);
    void Delete(int id);
    void Update(int pos, T objeto);
}
