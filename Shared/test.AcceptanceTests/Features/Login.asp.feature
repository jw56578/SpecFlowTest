
@Evo2
Feature: Logging In
	In order to log into Evo2
	As a user
	I should be able to attempt to log into evo2 crm 

@Selenium
Scenario: Login to Evo2 successfully
	Given I have navigated to the url "http://localhost/evolution2/fresh/loginstay.asp"
	When I type "ashows" into the "#user" element
	And I type "sales3" into the "[name=Password]" element
	And I click the element "#image1"
	Then I wait "4" seconds until the browser is redirected to "http://localhost/evolution2/fresh/eLead-V45/elead_track/index.aspx?login=1"

	
@Selenium
Scenario: Login to Evo2 unsuccessfully
	Given I have navigated to the url "http://localhost/evolution2/fresh/loginstay.asp"
	When I type "ashows" into the "#user" element
	And I type "salesxxx3" into the "[name=Password]" element
	And I click the element "#image1"
	Then The element "form div:nth-child(1) div.Login:nth-child(2)" contains the text "User Name or Password were not found."