using Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AccessToGithub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubUserController : ControllerBase
    {
        private readonly IGitHubUserManager _gitHubUserManager;
        private readonly ILogger<GitHubUserController> _logger;
        public GitHubUserController(IGitHubUserManager gitHubUserManager, ILogger<GitHubUserController> logger)
        {
            _gitHubUserManager = gitHubUserManager;
            _logger = logger;
        }

        [HttpPost("RetrieveUsers")]
        public async Task<IActionResult> GetUsersInfo([FromBody] List<String> userList, String? gitHubToken)
        {  
            
            if (string.IsNullOrEmpty(gitHubToken))
            {
                //default gitHubToken for testing purpose
                gitHubToken = "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";
            }
            
            var userListInfo = await _gitHubUserManager.GetUserListInfoAsync(userList, gitHubToken);
           if(userListInfo == null)
            {
                _logger.LogError("Bad request...");
                return BadRequest();
            }
            _logger.LogInformation("Returning all the user information");
           return Ok(userListInfo);
        }
    }
}
