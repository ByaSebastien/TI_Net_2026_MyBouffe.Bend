using System.Net.Http.Json;
using TI_Net_2026_MyBouffe.Bend.BLL.Interfaces;
using TI_Net_2026_MyBouffe.Bend.BLL.Models;

namespace TI_Net_2026_MyBouffe.Bend.DAL.Services
{
    public class OpenAIServices(HttpClient httpClient) : IOpenAIService
    {
        public async Task<CompletionResponse> GetCompletionAsync(CompletionRequest request)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("chat/completions", request);

            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Echec de connection API");
            }

            return await response.Content.ReadFromJsonAsync<CompletionResponse>() ?? throw new Exception();
        }
    }
}
