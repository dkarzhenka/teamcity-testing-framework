namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public class BuildType : BaseModel
    {
        public string? Id {get; set; }
        public string? Name { get; set; }
        public Project? Project { get; set; }
        public Steps? Steps { get; set; }
    }
}
