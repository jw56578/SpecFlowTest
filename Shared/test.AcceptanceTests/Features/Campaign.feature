Feature: Campaign
	
Background:
	Given I am logged into evolution with username "yacosta1" and password "camry14" and environment "PROD"


@Selenium
Scenario: Campaign Media Type Exists For Special Survey Live Calls
	Given I have a list of campaign step ids for company "3238"
	When I navigate to the view campaign step media resource for each of them
	Then every id should return sample media not found

