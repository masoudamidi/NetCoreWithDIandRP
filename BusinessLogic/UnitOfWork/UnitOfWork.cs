using BusinessLogic.BLL;
using DataAccess.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly NetCoreWithDIandRPContext _context;

    public ILocationsRepository LocationsModel { get; private set; }

    public UnitOfWork(NetCoreWithDIandRPContext context)
    {
        _context = context;
        LocationsModel = new LocationsRepository(context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}