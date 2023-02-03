using DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountsRepository Accounts { get; }
        int Complete();
    }
}
