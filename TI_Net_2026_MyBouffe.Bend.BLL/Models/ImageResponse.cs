namespace TI_Net_2026_MyBouffe.Bend.BLL.Models
{
    public class ImageResponse
    {
        public List<ListItem> Data { get; set; } = null!;
        public class ListItem
        {
            public byte[] B64_json { get; set; } = null!;
        }
    }
}
