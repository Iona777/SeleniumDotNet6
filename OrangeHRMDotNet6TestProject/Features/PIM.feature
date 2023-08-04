Feature: PIM

A short summary of the feature



@tag1
Scenario Outline: Select PIM
	Given I navigate to the Login page
	When I enter username "<username>" and password "<password>"
	Then the dashboard page is displayed
	When I select the the PIM menu item
	And I get the options list
	Examples: 
	| username | password	|
	| Admin    | admin123	|