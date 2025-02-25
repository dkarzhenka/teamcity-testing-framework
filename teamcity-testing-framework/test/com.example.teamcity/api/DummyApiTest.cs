using RestAssured.Logging;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;
using teamcity_testing_framework.main.com.example.teamcity.api.Spec;
using static RestAssured.Dsl;

namespace teamcity_testing_framework.test.com.example.teamcity.api
{
    public class DummyApiTest : BaseApiTest
    {
        [Test]
        public void UserShouldBeAbleGetAllProjects()
        {
            var user = new User("admin", "admin");
            Given()
                .Spec(Specifications.AuthSpec(user))
                .When()
                .Get("/app/rest/projects")
                .Then()
                .StatusCode(200);
        }
    }
}
