using CarBase.Models;
using CarBase.Repositories.Interfaces;

namespace CarBase.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private VehicleContext _locationContext;

        private ICarRepository? _locationRepository;

        private IEngineRepository? _engineRepository;

        private IMakeRepository? _makeRepository;

        private ITypeRepository? _typeRepository;

        public ICarRepository CarRepository
        {
            get
            {
                if (_locationRepository == null)
                {
                    _locationRepository = new CarRepository(_locationContext);
                }

                return _locationRepository;
            }
        }

        public IEngineRepository EngineRepository
        {
            get
            {
                if (_engineRepository == null)
                {
                    _engineRepository = new EngineRepository(_locationContext);
                }

                return _engineRepository;
            }
        }

        public IMakeRepository MakeRepository
        {
            get
            {
                if (_makeRepository == null)
                {
                    _makeRepository = new MakeRepository(_locationContext);
                }

                return _makeRepository;
            }
        }

        public ITypeRepository TypeRepository
        {
            get
            {
                if (_typeRepository == null)
                {
                    _typeRepository = new TypeRepository(_locationContext);
                }

                return _typeRepository;
            }
        }

        public RepositoryWrapper(VehicleContext locationContext)
        {
            _locationContext = locationContext;
        }

        public void Save()
        {
            _locationContext.SaveChanges();
        }
    }
}