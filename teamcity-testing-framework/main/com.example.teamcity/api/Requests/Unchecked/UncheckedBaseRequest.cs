using RestAssured.Request.Builders;
using static RestAssured.Dsl;
using teamcity_testing_framework.main.com.example.teamcity.api.Enums;
using teamcity_testing_framework.main.com.example.teamcity.api.Models;
using teamcity_testing_framework.main.com.example.teamcity.api.Extentions;
using RestAssured.Response;

namespace teamcity_testing_framework.main.com.example.teamcity.api.Requests.Unchecked
{
    public class UncheckedBaseRequest : Request, ICrudInterface<VerifiableResponse, VerifiableResponse>
    {
        public UncheckedBaseRequest(RequestSpecification spec, Endpoint endpoint) : base(spec, endpoint)
        {
        }

        public VerifiableResponse Create(BaseModel model)
        {
            return Given()
                .Spec(_spec)
                .Body(model)
                .Post(_endpoint.GetUrl());
        }

        public VerifiableResponse Delete(string id)
        {
            return Given()
                .Spec(_spec)
                .When()
                .Delete(_endpoint.GetUrl() + "/" + id);
        }

        public VerifiableResponse Read(string id)
        {
            return Given()
                .Spec(_spec)
                .When()
                .Get(_endpoint.GetUrl() + "/" + id);
        }

        public VerifiableResponse Update(string id, BaseModel model)
        {
            return Given()
                .Spec(_spec)
                .Body(model)
                .When()
                .Put(_endpoint.GetUrl() + "/" + id);
        }
    }    
}
