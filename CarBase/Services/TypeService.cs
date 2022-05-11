using CarBase.Models;
using CarBase.Repositories.Interfaces;
using CarBase.Services.Interfaces;
using System.Linq.Expressions;

namespace CarBase.Services
{
    public class TypeService : ITypeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public TypeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<type> PopulateType()
        {
            var type = new List<type>();
            type = _repositoryWrapper.TypeRepository.getAll().ToList();
            return type;
        }
        public void AddType(type type){
            _repositoryWrapper.TypeRepository.Create(type);
            _repositoryWrapper.Save();
        }
    }
}