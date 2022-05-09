namespace CarBase.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICarRepository CarRepository { get;}
        IEngineRepository EngineRepository {get; }
        IMakeRepository MakeRepository {get;}
        ITypeRepository TypeRepository{get;}
        void Save();
    }
}