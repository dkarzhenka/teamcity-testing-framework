using RandomAttribute = teamcity_testing_framework.main.com.example.teamcity.api.Attributes.RandomAttribute;

using teamcity_testing_framework.main.com.example.teamcity.api.Attributes;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public class BuildType : BaseModel
    {
        [Random]
        public string? Id {get; set; }
        [Random]
        public string? Name { get; set; }
        [Parameterizable]
        public Project? Project { get; set; }
        [Optional]
        public Steps? Steps { get; set; }
    }
}
