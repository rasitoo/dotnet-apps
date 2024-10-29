namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Repositories;

public interface IRepository<T>
{
    void Anadir(T objeto);
    void Modificar(string nombre, T objeto);
    T Consultar(string nombre);
    void Borrar(string nombre);
}
