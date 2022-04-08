using System.ComponentModel;

namespace CarBase.Models
{
    public class vehicle
    {
        public int vehicleID { get; set; }
        public string? Model { get; set; }
        public int year { get; set; }
        public int horsepower { get; set; }
        public string? rent_status { get; set; }
        public string? img_url { get; set; }

        //make
        [DisplayName("Make: ")]
        public int makeID { get; set; }
        public make? make { get; set; }

        //type
        [DisplayName("Type: ")]
        public int typeID { get; set; }
        public type? type { get; set; }

        //engine
        [DisplayName("Engine: ")]
        public int engineID { get; set; }
        public engine? engine { get; set; }

        public ICollection<FavoriteVehicles>? FavoriteVehicles { get; set; }
        public ICollection<RentedVehicles>? RentedVehicles { get; set; }
    }
}
