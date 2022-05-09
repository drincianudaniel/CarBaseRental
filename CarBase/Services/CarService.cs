using CarBase.Models;
using CarBase.Repositories.Interfaces;
using CarBase.Services.Interfaces;
using System.Linq.Expressions;

namespace CarBase.Services
{
    public class CarService : ICarService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CarService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<vehicle> GetVehicle(){
            var vehicles = new List<vehicle>();
            vehicles = _repositoryWrapper.CarRepository.FindAll(e=> e.engine, e=> e.make, e=> e.type).ToList();
            return vehicles;
        }

        public void AddVehicle(vehicle vehicle){
            _repositoryWrapper.CarRepository.Create(vehicle);
        }
    }
}