namespace P03_02_DI_Contactos_TAPIADOR_rodrigo.Models.repositories;

public interface IRepository<T>
{
    void Anadir(T objeto);
    void Modificar(int pos, T objeto);
    T Consultar(int id);
    void Borrar(int id);
    public void GuardarEnXml();
    public void CargarDesdeXml();

}
