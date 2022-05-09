using CarBase.Models;
using CarBase.Repositories.Interfaces;

namespace CarBase.Repositories
{
    public class MakeRepository : RepositoryBase<make>, IMakeRepository
    {
        public MakeRepository(VehicleContext vehicleContext)
            : base(vehicleContext)
        {
        }
    }
}