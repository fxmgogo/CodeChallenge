using Entities.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessToGithub.Tests
{
    public class RestApiTest
    {
        private readonly List<System.String> UserNameList = new()
        {
            "ivey",
            "wycats",
            "defunkt"
        };

        private readonly List<String> UserNameListWithDuplicatedItem = new ()
        {
            "ivey",
            "wycats",
            "defunkt",
            "wycats",
            "defunkt",
        };

        private readonly List<String> UserNameListWithInvalidItem = new()
        {
            "ivey",
            "wycats",
            "defunkt",
            "sdfskdjf[sdjfnsdj"
        };

        private readonly List<BasicUserInfo> expectedContent = new List<BasicUserInfo> {
                new BasicUserInfo(){
                    Name = "Chris Wanstrath",
                    Login="defunkt",
                    //company = null,
                    Followers= 21661,
                    Public_repos=107,
                    //FollowersPerRepository=202.4392523364486
                },
                 new BasicUserInfo{
                    Name = "Michael D. Ivey",
                    Login="ivey",
                    Company = "@RiotGames ",
                    Followers= 140,
                    Public_repos=37,
                    //followersPerRepository=3.7837837837837838
                },
                new BasicUserInfo{
                    Name = "Yehuda Katz",
                    Login="wycats",
                    Company = "@tildeio ",
                    Followers= 10127,
                    Public_repos=278,
                    //FollowersPerRepository=36.42805755395683
                }
        };

        [Fact]
        public async Task GivenARequest_WhenCallingGetUserInfoWithoutDuplicatedUserName_ThenTheAPIReturnsExpectedResponse()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            HttpClient _httpClient = new HttpClient();
            var userNameTmpList = new StringContent(JsonConvert.SerializeObject(UserNameList), Encoding.UTF8, "application/json");

            // Act.
            var response = await _httpClient.PostAsync("https://localhost:7278/api/GitHubUser/RetrieveUsers", userNameTmpList);
            var contents = await response.Content.ReadAsStringAsync();
            //API return List<BasicUserInfo>
            var res = JsonConvert.DeserializeObject<List<BasicUserInfo>>(contents);
            var ResCount = res == null ? 0 : res.Count();

            //assert
            Assert.Equal(expectedContent.Count(), ResCount);
            Assert.Equal(expectedStatusCode, response.StatusCode);

        }


        [Fact]
        public async Task GivenARequest_WhenCallingGetUserInfoWithDuplicatedUserName_ThenTheAPIReturnsExpectedResponse()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            HttpClient _httpClient = new HttpClient();
            var userNameTmpList = new StringContent(JsonConvert.SerializeObject(UserNameListWithDuplicatedItem), Encoding.UTF8, "application/json");

            // Act.
            var response = await _httpClient.PostAsync("https://localhost:7278/api/GitHubUser/RetrieveUsers", userNameTmpList);
            var contents = await response.Content.ReadAsStringAsync();
            //API return List<BasicUserInfo>
            var res = JsonConvert.DeserializeObject<List<BasicUserInfo>>(contents);
            var ResCount = res == null ? 0 : res.Count();

            //assert
            Assert.Equal(expectedContent.Count(), ResCount);
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }

        [Fact]
        public async Task GivenARequest_WhenCallingGetUserInfoWithInvalidUserName_ThenTheAPIReturnsExpectedResponse()
        {
            // Arrange.
            var expectedStatusCode = System.Net.HttpStatusCode.OK;
            HttpClient _httpClient = new HttpClient();
            var userNameTmpList = new StringContent(JsonConvert.SerializeObject(UserNameListWithInvalidItem), Encoding.UTF8, "application/json");

            // Act.
            var response = await _httpClient.PostAsync("https://localhost:7278/api/GitHubUser/RetrieveUsers", userNameTmpList);
            var contents = await response.Content.ReadAsStringAsync();
            //API return List<BasicUserInfo>
            var res = JsonConvert.DeserializeObject<List<BasicUserInfo>>(contents);
            var ResCount = res == null ? 0 : res.Count();

            //assert
            Assert.Equal(expectedContent.Count(), ResCount);
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }




        //[Fact]
        //public async Task GivenARequest_WhenCallingGetUserInfoOrderByName_ThenTheAPIReturnsExpectedResponse()
        //{
        //    // Arrange.
        //    var expectedStatusCode = System.Net.HttpStatusCode.OK;
        //    HttpClient _httpClient = new HttpClient();
        //    var userNameTmpList = new StringContent(JsonConvert.SerializeObject(UserNameListWithInvalidItem), Encoding.UTF8, "application/json");

        //    // Act.
        //    var response = await _httpClient.PostAsync("https://localhost:7278/api/GitHubUser/RetrieveUsers", userNameTmpList);
        //    var contents = await response.Content.ReadAsStringAsync();
        //    //API return List<BasicUserInfo>
        //    var res = JsonConvert.DeserializeObject<List<BasicUserInfo>>(contents);
        //    var ResCount = res == null ? 0 : res.Count();

        //    //assert  compare two List<BasicUserInfo>
        //    Assert.Equal(expectedContent.Count(), ResCount);
        //    Assert.Equal(expectedStatusCode, response.StatusCode);
        //}

    }
}
