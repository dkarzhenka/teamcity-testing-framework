using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RestAssured.Logging;
using RestAssured.Request.Builders;
using teamcity_testing_framework.main.com.example.teamcity.api.Configs;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Spec
{
    public class Specifications
    {
        private static readonly string _jsonContentType = "application/json";

        private static readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

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
                .WithJsonSerializerSettings(jsonSerializerSettings)
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
                .WithBasicAuth(user.Username, user.Password);
            return requestBuilder.Build();
        }

        public static RequestSpecification SuperUserAuth()
        {
            return RequestSpecBuilder().WithBasicAuth("", ConfigManager.GetProperty<string>("superUserToken"))
                .Build();
        }
    }
}
