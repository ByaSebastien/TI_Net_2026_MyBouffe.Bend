namespace TI_Net_2026_MyBouffe.Bend.BLL.Models
{
    public class CompletionResponse
    {
        public List<Choice> Choices { get; set; } = null!;

        public class Choice
        {
            public int Index { get; set; }
            public CompletionRequest.Message Message { get; set; } = null!;
        }
    }
}
