using CarBase.Models;
using System.Linq.Expressions;

namespace CarBase.Services.Interfaces
{
    public interface IEngineService
    {
        List<engine> PopulateEngine();
    }
}