using TechTalk.SpecFlow;

namespace MockingPOC.SpecflowTests.StepDefinitions
{
    [Binding]
    public class EventCreationSteps
    {
        [Given(@"I perform a POST operation for ""(.*)"" with body")]
        public void GivenIPerformApostOperationForWithBody(string p0)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"the Authorisation Token is System Admin")]
        public void WhenTheAuthorisationTokenIsSystemAdmin()
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"I should get ""(.*)"" in the response headers with response code ""(.*)""")]
        public void ThenIShouldGetInTheResponseHeadersWithResponseCode(string eventId, string p1)
        {
            ScenarioContext.StepIsPending();
        }
    }
}