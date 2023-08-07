Feature: Admin

I want to filter the system users

@tag1
Scenario Outline: Filter system users on username
	Given I navigate to the Login page
	When I enter username "<username>" and password "<password>"
	Then the dashboard page is displayed
	When I select the the Admin menu item
	And I filter on username "<username>"
	Then the Username column in all the return rows equal "<username>"
	Examples: 
	| username | password	|
	| Admin    | admin123	|


