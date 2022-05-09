using CarBase.Models;
using CarBase.Repositories.Interfaces;

namespace CarBase.Repositories
{
    public class TypeRepository : RepositoryBase<type>, ITypeRepository
    {
        public TypeRepository(VehicleContext vehicleContext)
            : base(vehicleContext)
        {
        }
    }
}