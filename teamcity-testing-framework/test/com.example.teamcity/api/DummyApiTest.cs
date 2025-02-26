using teamcity_testing_framework.main.com.example.teamcity.api.Enums;
using teamcity_testing_framework.main.com.example.teamcity.api.Extentions;
using teamcity_testing_framework.main.com.example.teamcity.api.Generators;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;
using teamcity_testing_framework.main.com.example.teamcity.api.Requests.Checked;
using teamcity_testing_framework.main.com.example.teamcity.api.Spec;
using static RestAssured.Dsl;
using NUnit.Framework;

namespace teamcity_testing_framework.test.com.example.teamcity.api
{
    public class DummyApiTest : BaseApiTest
    {
        [Test]
        public void UserShouldBeAbleCreateBuildType()
        {
            //Step 1: Create admin User
            var checkedUserRequester = new CheckedBaseRequest<User>(Specifications.SuperUserAuth(), Endpoint.Users);
            var user = TestDataGenerator.Generate<User>();
            var userResponse = checkedUserRequester.Create(user);

            //Step 2: Create project
            var project = TestDataGenerator.Generate<Project>();
            var checkedProjectRequester = new CheckedBaseRequest<Project>(Specifications.AuthSpec(user), Endpoint.Projects);
            var projectResponse = checkedProjectRequester.Create(project);

            var projectId = projectResponse.Id;

            //Step 3: Create buildType
            var buildType = TestDataGenerator.Generate<BuildType>();
            buildType.Project.Id = projectId;
            buildType.Project.Locator = null;
            var checkedBuildTypeRequester = new CheckedBaseRequest<BuildType>(Specifications.AuthSpec(user), Endpoint.BuildTypes);
            var buildTypeResponse = checkedBuildTypeRequester.Create(buildType);

            //Step 4: Read buildType
            var readBuildType = checkedBuildTypeRequester.Read(buildTypeResponse.Id);
            Assert.That(buildTypeResponse.Name, Is.EqualTo(readBuildType.Name), "Names are not equal");
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
        public void UserShouldBeAbleReadProject()
        {
            var checkedUserRequester = new CheckedBaseRequest<Project>(Specifications.SuperUserAuth(), Endpoint.Projects);

            var response = checkedUserRequester.Read("_Root");
        }
    }
}
