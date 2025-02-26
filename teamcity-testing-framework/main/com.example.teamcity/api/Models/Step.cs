namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public class Step : BaseModel
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string Type { get; set; } = "simpleRunner";
    }
}
