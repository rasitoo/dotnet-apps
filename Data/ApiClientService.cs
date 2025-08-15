using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace P07_01_DI_Contactos_TAPIADOR_rodrigo.Data;

internal class ApiClientService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;

    public ApiClientService()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<JsonDocument> GetJsonAsync(string url)
    {
        var response = await _client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        return JsonDocument.Parse(jsonString);
    }

    public async Task<HttpResponseMessage> PostJsonAsync(string url, object data)
    {
        var jsonString = JsonSerializer.Serialize(data, _serializerOptions);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        return await _client.PostAsync(url, content);
    }

    public async Task<HttpResponseMessage> DeleteAsync(string url)
    {
        return await _client.DeleteAsync(url);
    }

    public async Task<HttpResponseMessage> PutJsonAsync(string url, object data)
    {
        var jsonString = JsonSerializer.Serialize(data, _serializerOptions);
        var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
        return await _client.PutAsync(url, content);
    }
}
