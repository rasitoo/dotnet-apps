using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

internal class RestClientCategory : IRestClient<Category>
{
    public void Add(Category item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Category item)
    {
        throw new NotImplementedException();
    }

    public Category? Get(int id)
    {
        throw new NotImplementedException();
    }
    Task<List<Category>> IRestClient<Category>.GetAll()
    {
        throw new NotImplementedException();
    }
    public void Update(Category item)
    {
        throw new NotImplementedException();
    }

}
