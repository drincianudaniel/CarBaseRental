using CarBase.Models;
using CarBase.Repositories.Interfaces;
using CarBase.Services.Interfaces;
using System.Linq.Expressions;

namespace CarBase.Services
{
    public class EngineService : IEngineService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public EngineService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public List<engine> PopulateEngine()
        {
            var engine = new List<engine>();
            engine = _repositoryWrapper.EngineRepository.getAll().ToList();
            return engine;
        }
    }
}