using System.ComponentModel.DataAnnotations;

namespace CarBase.Models
{
    public class Users
    {
        public int UsersID { get; set; }
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? email { get; set; }

        public string? username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? password { get; set; }

        public string? user_type { get; set; }

        public ICollection<FavoriteVehicles>? FavoriteVehicles { get; set; }
        public ICollection<RentedVehicles>? RentedVehicles { get; set; }

    }
}
