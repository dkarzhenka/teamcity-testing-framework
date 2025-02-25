using System.ComponentModel.DataAnnotations;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Models
{
    public record User(
    [Required] 
    string Login,
    [Required] 
    string Password
);
}
