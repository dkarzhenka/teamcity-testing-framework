namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public class Role : BaseModel
    {
        public string? RoleId { get; set; } = "SYSTEM_ADMIN";
        public string? Scope { get; set; } = "g";
    }
}
