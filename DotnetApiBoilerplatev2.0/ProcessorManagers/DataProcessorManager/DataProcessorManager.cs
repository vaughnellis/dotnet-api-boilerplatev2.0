using DotnetApiBoilerplatev2._0.Core.DTO.In;
using DotnetApiBoilerplatev2._0.Core.Interfaces;
using DotnetApiBoilerplatev2._0.Core.Models.AccountDetails;

namespace DotnetApiBoilerplatev2._0.ProcessorManagers.DataProcessorManager
{
    public class DataProcessorManager : IDataProcessorManager
    {
        private readonly ILogger<DataProcessorManager> _logger;
        private IUnitOfWork _unitOfWork;
        public DataProcessorManager(
           ILogger<DataProcessorManager> logger,
           IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public Task<Accounts> GetAccountDetailsByEmail(string email)
        {
            Accounts accounts = new Accounts();

            try
            {
                accounts = _unitOfWork.Accounts.GetAccountByEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

            return Task.FromResult(accounts);
        }
        public Task<List<GroupAccounts>> GetGroupAccountsByAccountId(int accountId)
        {
            List<GroupAccounts> groupAccounts = new List<GroupAccounts>();

            try
            {
                groupAccounts = _unitOfWork.GroupAccounts.GetGroupAccountsByAccountId(accountId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

            return Task.FromResult(groupAccounts);
        }
        public Task<List<Roles>> GetRolesByGroupAccounts(List<GroupAccounts> groupUsers)
        {
            List<Roles> roles = new List<Roles>();
            try
            {
                foreach (var group in groupUsers)
                {
                    var role = _unitOfWork.Roles.GetRolesByRoleId(group.RoleId);
                    roles.Add(role);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

            return Task.FromResult(roles);
        }
    }
}
