using DotnetApiBoilerplatev2._0.Core.Interfaces;
using DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails;
using DotnetApiBoilerplatev2._0.Infrastructure.Repositories.AccountDetails;

namespace DotnetApiBoilerplatev2._0.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IAccountsRepository Accounts { get; set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Accounts = new AccountsRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
