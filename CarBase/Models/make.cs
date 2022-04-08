namespace CarBase.Models
{
    public class make
    {
        public int makeID { get; set; }
        public string? name { get; set; }
        public ICollection<vehicle>? vehicle { get; set; }
    }
}
