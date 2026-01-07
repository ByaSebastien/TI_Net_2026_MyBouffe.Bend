namespace TI_Net_2026_MyBouffe.Bend.BLL.Models
{
    public class ImageRequest : OpenAIRequest
    {
        public string Prompt { get; set; } = null!;
        public int N { get; set; }
        public string Size { get; set; } = null!;
        public string Response_format { get; set; } = null!;
    }
}
