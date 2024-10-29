using P03_02_DI_Contactos_TAPIADOR_rodrigo.Models;

namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Repositories;

public interface IRepository<T>
{
    void Anadir(T objeto);
    void Modificar(int id, T objeto);
    T Consultar(int id);
    T ConsultarNombre(string nombre);

    void Borrar(int id);
    int buscarPosicion(int id);
    T buscarDesdePosicion(int pos);

}
