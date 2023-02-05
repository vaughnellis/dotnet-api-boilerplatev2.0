using DotnetApiBoilerplatev2._0.Common;
using DotnetApiBoilerplatev2._0.Core.DTO.In;
using DotnetApiBoilerplatev2._0.ExceptionHandlers;
using DotnetApiBoilerplatev2._0.ExceptionHandlers.CustomExceptions;
using DotnetApiBoilerplatev2._0.ProcessorManager.AccountDetailsProcessorManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StatsdClient;

namespace DotnetApiBoilerplatev2._0.Controllers.AuthenticationController
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IAuthenticationProcessorManager _authenticationProcessorManager;

        public AuthenticationController(
            ILogger<AuthenticationController> logger,
            IExceptionHandler exceptionHandler,
            IAuthenticationProcessorManager authenticationProcessorManager
            )
        {
            _logger = logger;
            _exceptionHandler = exceptionHandler;
            _authenticationProcessorManager = authenticationProcessorManager;
        }

        ///TO DO: Add Authentication Scheme
        //[Authorize] 
        [HttpPost]
        public async Task<IActionResult> AuthenticateByBasicCredential([FromBody] PostLoginRequestByBasicCredentialDTO loginRequestByBasicCredentialDTO)
        {
            using (_logger.BeginScope(loginRequestByBasicCredentialDTO?.Email ?? string.Empty))
            {
                using (DogStatsd.StartTimer("PostController"))
                {
                    DogStatsd.StartTimer("PostControllerCount");

                    try
                    {
                        if (!ModelState.IsValid)
                        {
                            var errors = ModelState.GetRequestModelErrors();
                            var exception = new InvalidRequestException(errors) { Request = JsonConvert.SerializeObject(loginRequestByBasicCredentialDTO) };
                            _exceptionHandler.HandleException(exception, _logger);
                            return BadRequest(errors);
                        }

                        var responseByBasicCredentialDTO = await _authenticationProcessorManager.AuthenticateByBasicCredential(loginRequestByBasicCredentialDTO);
                        return Ok(responseByBasicCredentialDTO);
                    }
                    catch (Exception ex)
                    {
                        var exception = new BaseException(ex.Message, ex)
                        {
                            Request = JsonConvert.SerializeObject(loginRequestByBasicCredentialDTO)
                        };
                        _exceptionHandler.HandleException(exception, _logger);
                        return StatusCode(500, ex.Message);
                    }
                }
            }
        }
    }
}
