using P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data.Rest;

internal class RestClientProduct(ApiClientService apiClientService) : IRestClient<Product>
{

    //Donde se hace el await???

    public void Add(Product item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Product item)
    {
        throw new NotImplementedException();
    }

    public Product? Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Product>> GetAll()
    {
        int currentPage = 1;
        int totalPages = 1;
        List<Product> productos = new();

        while (currentPage <= totalPages)
        {
            string url = $"https://rickandmortyapi.com/api/character?page={currentPage}";
            try
            {
                JsonDocument doc = await apiClientService.GetJsonAsync(url);
                JsonElement info = doc.RootElement.GetProperty("info");
                totalPages = info.GetProperty("pages").GetInt32();

                foreach (JsonElement jsonProduct in doc.RootElement.GetProperty("results").EnumerateArray())
                {
                    Product product = new()
                    {
                        Name = jsonProduct.GetProperty("name").GetString(),
                        //Precio = jsonProduct.GetProperty("status").GetDouble(),
                        Category = new() { Name = jsonProduct.GetProperty("species").GetString() },
                        Description = jsonProduct.GetProperty("type").GetString(),
                        ImageUri = jsonProduct.GetProperty("image").GetString()
                    };
                    productos.Add(product);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            currentPage++;
        }

        return productos;
    }

    public void Update(Product item)
    {
        throw new NotImplementedException();
    }
}
