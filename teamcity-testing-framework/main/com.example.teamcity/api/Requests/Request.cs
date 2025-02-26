using RestAssured.Request.Builders;
using teamcity_testing_framework.main.com.example.teamcity.api.Enums;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Requests
{
    public class Request
    {
        protected readonly RequestSpecification _spec;
        protected readonly Endpoint _endpoint;

        public Request(RequestSpecification spec, Endpoint endpoint)
        {
            _spec = spec;
            _endpoint = endpoint;
        }
    }
}
