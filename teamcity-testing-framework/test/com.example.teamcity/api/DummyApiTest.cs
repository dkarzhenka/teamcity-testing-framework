using RestAssured.Logging;
using teamcity_testing_framework.main.com.example.teamcity.api.Configs;
using teamcity_testing_framework.main.com.example.teamcity.api.Enums;
using teamcity_testing_framework.main.com.example.teamcity.api.Extentions;
using teamcity_testing_framework.main.com.example.teamcity.api.Generators;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;
using teamcity_testing_framework.main.com.example.teamcity.api.Requests.Checked;
using teamcity_testing_framework.main.com.example.teamcity.api.Spec;
using static RestAssured.Dsl;

namespace teamcity_testing_framework.test.com.example.teamcity.api
{
    public class DummyApiTest : BaseApiTest
    {
        [Test]
        public void SuperUserShouldBeAbleCreateUser()
        {
            
            var checkedUserRequester = new CheckedBaseRequest<User>(Specifications.SuperUserAuth(), Endpoint.Users);
            var user = TestDataGenerator.Generate<User>();
            var response = checkedUserRequester.Create(user);    
        }

        [Test]
        public void UserShouldBeAbleGetAllProjects()
        {
            var verifayableResponse = Given()
                .Spec(Specifications.SuperUserAuth())
                .When()
                .Get(Endpoint.Projects.GetUrl());

            verifayableResponse
                .Then()
                .StatusCode(200);
        }

        [Test]
        public void UserShouldBeAbleReadProject() { 
            var checkedUserRequester = new CheckedBaseRequest<Project>(Specifications.SuperUserAuth(), Endpoint.Projects);
            
            var response = checkedUserRequester.Read("_Root");
        }
    }
}
