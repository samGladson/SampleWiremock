using NUnit.Framework;
using WireMock.Server;
using WireMock.Settings;
using System;
using System.Net;
using MockingPOC.dtos.RequestModels.AccessToken;
using MockingPOC.WiremockTests.UserToken;
using RestSharp;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace MockingPOC.Hooks
{
    public class Utilities
    {
        public static WireMockServer stub;
        public static string baseUrl;

        [OneTimeSetUp]
        public void prepareTest()
        {
            var port = new Random().Next(5000, 6000);
            baseUrl = "http://localhost:" + port;
            
      
            stub = WireMockServer.Start(new WireMockServerSettings
            {
                Urls = new[] { "http://+:" + port },
                ReadStaticMappings = true
            });
            var logEntries = stub.LogEntries;
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            stub.Stop();
        }

        public string getAccessToken()
        {
            var requestBody = new AccessTokenRequest()
            {
                client_id = "system-admin",
                client_secret = "system-admin-integration-secret",
                grant_type = "client_credentials",
                scope = "urn:rxscope:admin"
            };
            var responseBody = new AccessTokenResponse()
            {
                access_token = UserTokenClass.SystemAdmin,
                expires_in = 300,
                token_type = "Bearer",
                scope = "urn:rxscope:admin"

            };
            
            //stub for getting Access token
            
            stub.Given(Request.Create().
                WithPath("/secure/connect/token").UsingPost().
                                WithHeader("Content-Type","application/x-www-form-urlencoded").
                                WithParam("client_id", requestBody.client_id).
                                WithParam("client_secret", requestBody.client_secret).
                                WithParam("grant_type", requestBody.grant_type).
                                WithParam("scope", requestBody.scope)).
                RespondWith(Response.Create()
                                .WithStatusCode(HttpStatusCode.OK)
                                .WithHeader("Content-Type","application/json")
                                .WithBodyAsJson(requestBody)
                );


            var client = new RestClient(baseUrl+"/secure/connect/token");
            var request = new RestRequest(Method.POST);
            
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("client_id", requestBody.client_id);
            request.AddParameter("client_secret", requestBody.client_secret);
            request.AddParameter("grant_type", requestBody.grant_type);
            request.AddParameter("scope", requestBody.scope);
            
            var response = client.Execute(request);
           // Assert.True(response.StatusCode == HttpStatusCode.OK);
            return response.Content;
        }
    }
}