using DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails;
using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Infrastructure.Repositories.AccountDetails
{
    public class GroupAccountsRepository : GenericRepository<GroupAccounts>, IGroupAccountsRepository
    {
        public GroupAccountsRepository(DataContext context)
           : base(context)
        { }

        public List<GroupAccounts> GetGroupAccountsByAccountId(int accountId)
        {
            return this.GetAll().Where(x => x.AccountId == accountId).ToList();
        }
    }
}
