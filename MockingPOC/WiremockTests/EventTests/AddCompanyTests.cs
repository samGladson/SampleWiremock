using System.Net;
using MockingPOC.dtos.RequestModels.AddCompany;
using MockingPOC.EnvironmentSetup;
using MockingPOC.Hooks;
using NUnit.Framework;
using RestSharp;
using WireMock.RequestBuilders;

namespace MockingPOC.WiremockTests.EventTests
{
    public class AddCompanyTests : WiremockSetup
    {
        private IRestClient client;
        private IRestRequest request;
        private string accessToken;
        
        
        [SetUp]
        public void setupEndPoint()
        {
          client = new RestClient(baseUrl);
          request = new RestRequest(GetRoyalboxEndpoints.addCompany, Method.PUT);
          request.AddUrlSegment("eventId", "evt-3456789");
          request.AddHeader("Authorization" ,"bearer " + getAccessToken());
        }

        [Test]
        public void addCompanyToEvent()
        {
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new AddCompany()
            {
                companyId = "cpy-a3f85735-f326-45c4-8ea5-f7e214b25c0d"
            });

            var response = client.Execute(request);
            Assert.True(response.StatusCode == HttpStatusCode.NoContent);
        }
        
    }

   
}