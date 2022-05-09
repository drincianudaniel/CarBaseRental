using CarBase.Models;
using System.Linq.Expressions;

namespace CarBase.Services.Interfaces
{
    public interface ITypeService
    {
        List<type> PopulateType();
    }
}