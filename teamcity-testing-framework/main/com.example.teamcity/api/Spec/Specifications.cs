using RestAssured.Logging;
using RestAssured.Request.Builders;
using teamcity_testing_framework.main.com.example.teamcity.api.Configs;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Spec
{
    public class Specifications
    {
        private static readonly string _jsonContentType = "application/json";

        public static LogConfiguration GetLogConfiguration()
        {
            return new LogConfiguration
            {
                RequestLogLevel = RequestLogLevel.All,
                ResponseLogLevel = ResponseLogLevel.All,
                SensitiveRequestHeadersAndCookies = new List<string>() { "Authorization" },
            };
        }

        private static RequestSpecBuilder RequestSpecBuilder()
        {
            return new RequestSpecBuilder()
                .WithBaseUri(ConfigManager.GetProperty<string>("apiUrl"))
                .WithLogConfiguration(GetLogConfiguration())
                .WithContentType(_jsonContentType)
                .WithHeader("Accept", _jsonContentType);
        }

        public static RequestSpecification UnauthSpec()
        {
            return RequestSpecBuilder().Build();
        }

        public static RequestSpecification AuthSpec(User user)
        {
            var requestBuilder = RequestSpecBuilder();
            requestBuilder
                .WithBasicAuth(user.Login, user.Password);
            return requestBuilder.Build();
        }
    }
}
