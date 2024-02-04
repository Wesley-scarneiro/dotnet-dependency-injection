using DotnetDi.Models;
using DotnetDi.Repository.Interfaces;

namespace DotnetDi.Repository;
public class UnitOfWork : IUnitOfWork
{
    public Guid UnitOfWorkId {get; init;}
    private IDbSession _dbSession;
    public IRepository<Client> ClientRepository {get; init;}
    public IRepository<Product> ProductRepository {get; init;}

    public UnitOfWork(IDbSession dbSession, 
        IRepository<Client> clientRepo, 
        IRepository<Product> productRepo)
    {
        _dbSession = dbSession;
        ClientRepository = clientRepo;
        ProductRepository = productRepo;
        UnitOfWorkId = Guid.NewGuid();
    }

    public override string ToString()
    {
        return @$"UnitOfWorkId: {UnitOfWorkId.ToString("N")[..5]}
        DbSession: {_dbSession}
        ClientRepository: {ClientRepository}
        ProductRepository: {ProductRepository}";
    }
}
