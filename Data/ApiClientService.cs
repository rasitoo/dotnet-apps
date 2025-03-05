using System.Text;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data;

public class ApiClientService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;
    private readonly string url = "http://192.168.16.10:8080/";

    public ApiClientService(HttpClient client)
    {
        _client = client;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<JsonDocument> GetJsonAsync(string urlextension)
    {

        var response = await _client.GetAsync(url + urlextension);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(jsonString);
    }

    public async Task<HttpResponseMessage> PostJsonAsync(string urlextension, object data)
    {
        var jsonString = JsonSerializer.Serialize(data, _serializerOptions);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        return await _client.PostAsync(url + urlextension, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string urlextension)
    {
        return await _client.DeleteAsync(url + urlextension);
    }

    public async Task<HttpResponseMessage> PutJsonAsync(string urlextension, object data)
    {
        var jsonString = JsonSerializer.Serialize(data, _serializerOptions);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        return await _client.PutAsync(url + urlextension, content);
    }
}
