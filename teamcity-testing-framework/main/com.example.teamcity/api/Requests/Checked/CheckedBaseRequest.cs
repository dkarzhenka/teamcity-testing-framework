using RestAssured.Request.Builders;
using System.Net;
using teamcity_testing_framework.main.com.example.teamcity.api.Enums;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;
using teamcity_testing_framework.main.com.example.teamcity.api.Requests.Unchecked;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Requests.Checked
{
    public class CheckedBaseRequest<T> : Request, ICrudInterface<T, string> where T : BaseModel
    {
        private readonly UncheckedBaseRequest _uncheckedBaseRequest;

        public CheckedBaseRequest(RequestSpecification spec, Endpoint endpoint) : base(spec, endpoint)
        {
            _uncheckedBaseRequest = new UncheckedBaseRequest(spec, endpoint);
        }

        public T Create(BaseModel model)
        {
            return (T)_uncheckedBaseRequest.Create(model)
                .Then()
                .AssertThat()
                .StatusCode(HttpStatusCode.OK)
                .DeserializeTo(typeof(T)) ?? throw new InvalidCastException($"Not able to cast response body to Type '{typeof(T).Name}'");
        }

        public string Delete(string id)
        {
            return _uncheckedBaseRequest.Delete(id)
                .Then()
                .AssertThat()
                .StatusCode(HttpStatusCode.OK)
                .Extract()
                .BodyAsString();
        }

        public T Read(string id)
        {
            return (T)_uncheckedBaseRequest.Read(id)
                .Then()
                .AssertThat()
                .StatusCode(HttpStatusCode.OK)
                .DeserializeTo(typeof(T)) ?? throw new InvalidCastException($"Not able to cast response body to Type '{typeof(T).Name}'");
        }

        public T Update(string id, BaseModel model)
        {
            return (T)_uncheckedBaseRequest.Update(id, model)
                .Then()
                .AssertThat()
                .StatusCode(HttpStatusCode.OK)
                .DeserializeTo(typeof(T)) ?? throw new InvalidCastException($"Not able to cast response body to Type '{typeof(T).Name}'");
        }
    }
}
