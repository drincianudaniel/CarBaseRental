using CarBase.Models;
using CarBase.Repositories.Interfaces;

namespace CarBase.Repositories
{
    public class CarRepository : RepositoryBase<vehicle>, ICarRepository
    {
        public CarRepository(VehicleContext vehicleContext)
            : base(vehicleContext)
        {
        }
    }
}