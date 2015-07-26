Feature: Upsheet
	In order to ensure the upsheet works

Background:
	Given I am logged into evolution with username "ashows" and password "sales5"

@Selenium
Scenario: Validate Free Form Text
	Given I go to the upsheet
	When I enter over the maximum characters into the field:
	| MaxCharacter | CssSelector     |
	| 50           | #txtLotLocation |
	| 100          | #txtLastName    |
	| 30           | #txtFirstName   |
	| 100          | #txtTOOutcome   |
	| 100          | #txtCoaching    |

	Then I am told:
	| Description  | MaxCharacter |
	| Lot Location | 50           |
	| Last Name    | 100          |
	| First Name   | 30           |
	| TO Outcome   | 100          |
	| Coaching     | 100          |

	
	And The field should have the number of characters in it:
	| MaxCharacter | CssSelector     |
	| 50           | #txtLotLocation |
	| 100          | #txtLastName    |
	| 30           | #txtFirstName   |
	| 100          | #txtTOOutcome   |
	| 100          | #txtCoaching    |

@Selenium
Scenario: Validate Save
	Given I go to the upsheet
	When I enter maximum characters into the field:
	| MaxCharacter | CssSelector     |
	| 50           | #txtLotLocation |
	| 100          | #txtLastName    |
	| 30           | #txtFirstName   |
	| 100          | #txtTOOutcome   |
	| 100          | #txtCoaching    |


	And I click the element "#btnSave"
	And I wait "2000" milliseconds
	And I navigate to the upsheet log
	And I find the last id created
	And I navigate to the specific upsheet url
	Then All the fields have the same values



	