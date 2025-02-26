using teamcity_testing_framework.main.com.example.teamcity.api.Attributes;
using teamcity_testing_framework.main.com.example.teamcity.api.Enums;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Extentions
{
    public static class ApiEndpointExtentions
    {
        public static ApiEndpointAttribute GetApiEndpointAttribute(this Endpoint endpoint)
        {
            var member = typeof(Endpoint).GetMember(endpoint.ToString()).FirstOrDefault();
            if (member == null)
            {
                throw new InvalidOperationException($"No member found for endpoint: {endpoint}");
            }
            var attribute = member.GetCustomAttributes(typeof(ApiEndpointAttribute), false).FirstOrDefault() as ApiEndpointAttribute;
            if (attribute == null)
            {
                throw new InvalidOperationException($"No ApiEndpointAttribute found for endpoint: {endpoint}");
            }
            return attribute;
        }

        public static string GetUrl(this Endpoint endpoint)
        {
            return endpoint.GetApiEndpointAttribute().Url;
        }

        public static Type GetTypeName(this Endpoint endpoint)
        {
            return endpoint.GetApiEndpointAttribute().ModelType;
        }
    }
}
