namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public class Project : BaseModel
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Locator { get; set; } = "_Root";
    }
}
