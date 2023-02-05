using DotnetApiBoilerplatev2._0.Core.DTO.In;
using DotnetApiBoilerplatev2._0.Core.DTO.Out;

namespace DotnetApiBoilerplatev2._0.ProcessorManager.AccountDetailsProcessorManager
{
    public interface IAuthenticationProcessorManager
    {
        Task<PostLoginResponseByBasicCredentialDTO> AuthenticateByBasicCredential(PostLoginRequestByBasicCredentialDTO requestByBasicCredential);
    }
}
