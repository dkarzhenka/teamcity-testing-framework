using teamcity_testing_framework.main.com.example.teamcity.api.Models;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Requests
{
    interface ICrudInterface<T, N>
    {
        T Create(BaseModel model);
        T Read(string id);
        T Update(string id, BaseModel model);
        N Delete(string id);
    }
}
