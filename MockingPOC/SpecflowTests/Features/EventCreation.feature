Feature: EventCreation
	Create an event in royalbox

Scenario: Verify event is created successfully with response code 201
	Given I perform a POST operation for "v1/events" with body
	     | businessUnitId                           | eventGbsCode | locale | name                    |
	     | bun-a01b198f-36d5-46ce-a98e-75bad7d38e9e | TVE          | en-gb  | Test Verification Event |
	When the Authorisation Token is System Admin
	Then I should get "eventId" in the response headers with response code "201"