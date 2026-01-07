using TI_Net_2026_MyBouffe.Bend.BLL.Models;

namespace TI_Net_2026_MyBouffe.Bend.BLL.Interfaces
{
    public interface IOpenAIService
    {
        Task<CompletionResponse> GetCompletionAsync(CompletionRequest request);
        Task<ImageResponse> GetImageAsync(ImageRequest request);
        Task<Stream> GetSpeechAsync(SpeechRequest request);

    }
}
