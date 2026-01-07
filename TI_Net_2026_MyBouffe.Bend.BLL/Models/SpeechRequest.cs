namespace TI_Net_2026_MyBouffe.Bend.BLL.Models
{
    public class SpeechRequest : OpenAIRequest
    {
        public string Input { get; set; } = null!;
        public string Voice { get; set; } = null!;
    }
}
