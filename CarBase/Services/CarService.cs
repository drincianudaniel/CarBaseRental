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

        public List<vehicle> searchVehicle(string searchName){
            var vehicles = new List<vehicle>();
            vehicles = _repositoryWrapper.CarRepository.FindAllWhere(e=> e.engine, e=> e.make, e=> e.type, e => e.Model.Contains(searchName) || searchName == null || searchName=="" || e.make.name.Contains(searchName)).ToList();   
            return vehicles;
        }
        public vehicle FindID(int id){
            var vehicle = new vehicle();
            vehicle = _repositoryWrapper.CarRepository.FindByCondition(x => x.vehicleID == id, e=> e.engine, e=> e.make, e=> e.type);
            return vehicle;
        }

        public void AddVehicle(vehicle vehicle){
            _repositoryWrapper.CarRepository.Create(vehicle);
            _repositoryWrapper.Save();
        }

        public void DeleteVehicle(vehicle vehicle){
            _repositoryWrapper.CarRepository.Delete(vehicle);
            _repositoryWrapper.Save();
        }

        public void UpdateVehicle(vehicle vehicle){
            _repositoryWrapper.CarRepository.Update(vehicle);
            _repositoryWrapper.Save();
        }
    }
}