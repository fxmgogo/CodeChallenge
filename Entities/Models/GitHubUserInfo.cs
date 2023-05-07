using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class GitHubUserInfo
    {
        public string Name { get; set; }
        public string Login { get; set; } //userName
        public string Company { get; set; }
        public int Followers { get; set; }
        public int Public_repos { get; set; }

    }
}
