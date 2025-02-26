namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public class Steps : BaseModel
    {
        public int Count { get; set; }
        public List<Step>? Step { get; set; }
    }
}
