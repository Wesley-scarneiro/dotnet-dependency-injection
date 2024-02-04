using DotnetDi.Repository.Interfaces;

namespace DotnetDi.Repository;
public class DbSession : IDbSession
{
    public Guid ConnectionId {get;}

    public DbSession()
    {
        ConnectionId = Guid.NewGuid();
    }

    public override string ToString()
    {
        return ConnectionId.ToString("N")[..5];
    }
}
