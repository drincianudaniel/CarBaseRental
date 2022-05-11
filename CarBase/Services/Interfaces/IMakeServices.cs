using CarBase.Models;
using System.Linq.Expressions;

namespace CarBase.Services.Interfaces
{
    public interface IMakeService
    {
        List<make> PopulateMake();
        void AddMake(make make);
    }
}