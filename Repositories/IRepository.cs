namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Repositories;

public interface IRepository<T>
{
    void Anadir(T objeto);
    void Modificar(int id, T objeto);
    T Consultar(int id);
    void Borrar(int id);
}
