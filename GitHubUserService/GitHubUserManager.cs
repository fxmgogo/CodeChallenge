using Contracts;
using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GitHubUserService
{
    public class GitHubUserManager : IGitHubUserManager
    {
        private const string baseUrl = "https://api.github.com/";
        private const string userAgent = "SamFDemo App";
        public async Task<List<BasicUserInfo>> GetUserListInfoAsync(List<string> userList,string accessToken)
        {
            var basicUserInfoList = new List<BasicUserInfo>();
            var gitHubUserInfoList = new List<GitHubUserInfo>();
            //remove the duplicated userName from userList
            foreach (var userName in userList.Distinct().ToList())
            {
                var userJson = await GetStringAsync(baseUrl + "users/" + userName, accessToken);
                if (!string.IsNullOrEmpty(userJson))
                {
                    var userInfoItem = JsonConvert.DeserializeObject<GitHubUserInfo>(userJson);
                    gitHubUserInfoList.Add(userInfoItem);
                }
            }
            //The returned users should be sorted alphabetically by name
            var gitHubUserInfoOrderedList = gitHubUserInfoList.OrderBy(x => x.Name);
            foreach(var item in gitHubUserInfoOrderedList)
            {
                var basicUserInfo = new BasicUserInfo()
                {
                    Name = item.Name,
                    Login = item.Login,
                    Company =item.Company,
                    Public_repos =item.Public_repos,
                    Followers =item.Followers
                };
                basicUserInfoList.Add(basicUserInfo);
            }
            return basicUserInfoList;
        }

        private static async Task<string> GetStringAsync(string url,string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                //Populate the header so as to access the github API
                httpClient.DefaultRequestHeaders.Add("Authorization", accessToken);
                httpClient.DefaultRequestHeaders.Add("User-Agent", userAgent);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));

                //Get the status code by using GetAsync rather than GetStringAsync
                HttpResponseMessage response = await httpClient.GetAsync(url);               
                if (!response.IsSuccessStatusCode)
                {
                    return string.Empty;
                }
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
