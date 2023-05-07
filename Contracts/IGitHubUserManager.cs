using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IGitHubUserManager
    {
        public Task<List<BasicUserInfo>> GetUserListInfoAsync(List<string> userList,string accessToken);
    }
}
