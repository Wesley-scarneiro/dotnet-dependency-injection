using DotnetDi.Repository.Interfaces;

namespace DotnetDi.Repository;
public class Repository<T> : IRepository<T>
{
    public Guid RepositoryId {get;}

    private readonly IDbSession _dbSession;

    public Repository(IDbSession dbSession)
    {
        _dbSession = dbSession;
        RepositoryId = Guid.NewGuid();
    }

    public override string ToString()
    {
        return $"{RepositoryId.ToString("N")[..5]} | DbSessionId: {_dbSession}";
    }
}
