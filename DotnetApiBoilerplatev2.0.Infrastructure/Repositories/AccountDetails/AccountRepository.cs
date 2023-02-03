using DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails;
using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Infrastructure.Repositories.AccountDetails
{
    public class AccountsRepository : GenericRepository<Accounts>, IAccountsRepository
    {
        public AccountsRepository(DataContext context)
            : base(context)
        { }

        public Accounts GetAccountByEmail(string email)
        {
            return this.GetAll().Where(x => x.Email == email)
                .Where(y => y.IsActive == true)
                .FirstOrDefault();
        }
    }
}
