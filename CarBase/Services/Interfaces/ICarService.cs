using CarBase.Models;
using System.Linq.Expressions;

namespace CarBase.Services.Interfaces
{
    public interface ICarService
    {
        List<vehicle> GetVehicle();
        void AddVehicle(vehicle vehicle);
        vehicle FindID(int id);
        void DeleteVehicle(vehicle vehicle);
        void UpdateVehicle(vehicle vehicle);
        List<vehicle> searchVehicle(string searchName);
    }
}