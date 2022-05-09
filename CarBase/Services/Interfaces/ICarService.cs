using CarBase.Models;
using System.Linq.Expressions;

namespace CarBase.Services.Interfaces
{
    public interface ICarService
    {
        List<vehicle> GetVehicle();
        void AddVehicle(vehicle vehicle);
    }
}