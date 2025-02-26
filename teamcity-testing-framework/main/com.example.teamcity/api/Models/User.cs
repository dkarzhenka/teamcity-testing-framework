using RandomAttribute = teamcity_testing_framework.main.com.example.teamcity.api.Attributes.RandomAttribute;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{  
    public class User : BaseModel
    {
        [Random]
        public string? Username { get; set; }
        [Random]
        public string? Password { get; set; }
    }
}
