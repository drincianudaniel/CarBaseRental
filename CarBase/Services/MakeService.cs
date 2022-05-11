using CarBase.Models;
using CarBase.Repositories.Interfaces;
using CarBase.Services.Interfaces;
using System.Linq.Expressions;

namespace CarBase.Services
{
    public class MakeService : IMakeService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public MakeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<make> PopulateMake()
        {
            var make = new List<make>();
            make = _repositoryWrapper.MakeRepository.getAll().ToList();
            return make;
        }

        public void AddMake(make make){
            _repositoryWrapper.MakeRepository.Create(make);
            _repositoryWrapper.Save();
        }
    }
}