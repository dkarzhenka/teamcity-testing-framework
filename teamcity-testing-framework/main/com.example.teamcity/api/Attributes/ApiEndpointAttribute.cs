namespace teamcity_testing_framework.main.com.example.teamcity.api.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ApiEndpointAttribute : Attribute
    {
        public string Url { get; }
        public Type ModelType { get; }

        public ApiEndpointAttribute(string url, Type modelType)
        {
            Url = url;
            ModelType = modelType;
        }
    }
}
