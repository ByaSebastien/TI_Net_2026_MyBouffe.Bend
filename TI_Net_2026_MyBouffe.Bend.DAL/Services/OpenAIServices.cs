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
                Console.WriteLine(response.Content);
                throw new Exception("Echec de connection API");
            }

            return await response.Content.ReadFromJsonAsync<CompletionResponse>() ?? throw new Exception();
        }

        public async Task<ImageResponse> GetImageAsync(ImageRequest request)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("images/generations", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Connection à l'API impossible");
            }
            string content = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadFromJsonAsync<ImageResponse>()
                ?? throw new Exception();
        }

        public async Task<Stream> GetSpeechAsync(SpeechRequest request)
        {
            HttpResponseMessage response = await httpClient.PostAsJsonAsync("audio/speech", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Connection à l'API impossible");
            }
            return await response.Content.ReadAsStreamAsync();
        }
    }
}
