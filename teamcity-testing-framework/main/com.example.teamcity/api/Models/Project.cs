using RandomAttribute = teamcity_testing_framework.main.com.example.teamcity.api.Attributes.RandomAttribute;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public class Project : BaseModel
    {
        [Random]
        public string? Id { get; set; }
        [Random]
        public string? Name { get; set; }

        public string? Locator { get; set; } = "_Root";
    }
}
