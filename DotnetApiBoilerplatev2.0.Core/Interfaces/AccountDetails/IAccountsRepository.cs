using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails
{
    public interface IAccountsRepository : IGenericRepository<Accounts>
    {
        Accounts GetAccountByEmail(string email);
    }
}
