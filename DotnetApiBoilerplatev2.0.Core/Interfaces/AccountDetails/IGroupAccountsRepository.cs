using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails
{
    public interface IGroupAccountsRepository : IGenericRepository<GroupAccounts>
    {
        public List<GroupAccounts> GetGroupAccountsByAccountId(int accountId);
    }
}
