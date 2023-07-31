Feature: Login

I want to login to the OrangeHRM site

@tag1
Scenario Outline: Log in to the OrangeHRM site
	Given I navigate to the Login page
	When I enter username "<username>" and password "<password>"
	Then the dashboard page is displayed
	And I click on Leave from the menu
	Examples: 
	| username | password	|
	| Admin    | admin123	|
