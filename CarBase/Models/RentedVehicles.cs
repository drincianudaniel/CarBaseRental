using Microsoft.EntityFrameworkCore;

namespace CarBase.Models
{
    public class RentedVehicles
    {
        public int UsersID { get; set; }
        public virtual Users? Users { get; set; }
        public int vehicleID { get; set; }
        public virtual vehicle? vehicle { get; set; }
    }
}
