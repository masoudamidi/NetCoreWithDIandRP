public interface IUnitOfWork
{
    ILocationsRepository LocationsModel { get; }
    Task CompleteAsync();
    void Dispose();
}