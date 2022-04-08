namespace CarBase.Models
{
    public class engine
    {
        public int engineID { get; set; }
        public string? type { get; set; }
        public string? size { get; set; }
        public ICollection<vehicle>? vehicle { get; set; }
    }
}
