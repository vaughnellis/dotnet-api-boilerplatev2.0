using AutoMapper;
using DotnetApiBoilerplatev2._0.Core.DTO.In;
using DotnetApiBoilerplatev2._0.Core.DTO.Out;
using DotnetApiBoilerplatev2._0.ExceptionHandlers;
using DotnetApiBoilerplatev2._0.ProcessorManagers.DataProcessorManager;

namespace DotnetApiBoilerplatev2._0.ProcessorManager.AccountDetailsProcessorManager
{
    public class AuthenticationProcessorManager : IAuthenticationProcessorManager
    {
        private readonly ILogger<AuthenticationProcessorManager> _logger;
        private readonly IMapper _mapper;
        private readonly IDataProcessorManager _dataProcessorManager;

        public AuthenticationProcessorManager(
           ILogger<AuthenticationProcessorManager> logger,
           IExceptionHandler exceptionHandler,
           IMapper mapper,
           IDataProcessorManager dataProcessorManager)
        {
            _logger = logger;
            _mapper = mapper;
            _dataProcessorManager = dataProcessorManager;
        }

        public async Task<PostLoginResponseByBasicCredentialDTO> AuthenticateByBasicCredential(PostLoginRequestByBasicCredentialDTO requestByBasicCredential)
        {
            PostLoginResponseByBasicCredentialDTO responseDTO = new PostLoginResponseByBasicCredentialDTO();
            try
            {
                var accounts = await _dataProcessorManager.GetAccountDetailsByEmail(requestByBasicCredential.Email);
                var groupAccounts = await _dataProcessorManager.GetGroupAccountsByAccountId(accounts.Id);
                var roles = await _dataProcessorManager.GetRolesByGroupAccounts(groupAccounts);
                responseDTO = _mapper.Map<PostLoginResponseByBasicCredentialDTO>(accounts);
                responseDTO.Roles = roles;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

            return responseDTO;
        }
    }
}
