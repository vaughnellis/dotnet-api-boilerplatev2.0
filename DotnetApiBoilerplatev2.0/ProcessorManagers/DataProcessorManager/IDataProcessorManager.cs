using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.ProcessorManagers.DataProcessorManager
{
    public interface IDataProcessorManager
    {
        Task<Accounts> GetAccountDetailsByEmail(string email);
        Task<List<GroupAccounts>> GetGroupAccountsByAccountId(int accountId);
        Task<List<Roles>> GetRolesByGroupAccounts(List<GroupAccounts> groupUsers);
    }
}
