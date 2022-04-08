namespace CarBase.Models
{
    public class type
    {
        public int typeID { get; set; }
        public string? name { get; set; }
        public ICollection<vehicle>? vehicle { get; set; }
    }
}
