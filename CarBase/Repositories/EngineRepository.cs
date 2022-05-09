using CarBase.Models;
using CarBase.Repositories.Interfaces;

namespace CarBase.Repositories
{
    public class EngineRepository : RepositoryBase<engine>, IEngineRepository
    {
        public EngineRepository(VehicleContext vehicleContext)
            : base(vehicleContext)
        {
        }
    }
}