using teamcity_testing_framework.main.com.example.teamcity.api.Attributes;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Enums
{
    public enum Endpoint
    {
        [ApiEndpoint("/app/rest/buildTypes", typeof(BuildType))]
        BuildTypes,
        [ApiEndpoint("/app/rest/users", typeof(User))]
        Users,
        [ApiEndpoint("/app/rest/projects", typeof(Project))]
        Projects
    }
}
