using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BasicUserInfo
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Company { get; set; }
        public int Followers { get; set; }
        public int Public_repos { get; set; }
        public double FollowersPerRepository { 
            get
            {
                return Public_repos == 0? 0: (double)Followers / Public_repos;
            }
        }
    }
}
