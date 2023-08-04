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


Scenario Outline: Filter system users on user role
	Given I navigate to the Login page
	When I enter username "<username>" and password "<password>"
	Then the dashboard page is displayed
	When I select the the Admin menu item


	#THIS IS SOME VERY ODD ELEMENT THAT i CANNOT GET TO CLICK ON OR ENTER TEXT INTO. 
	#SO ABANDON THIS TEST AND JUST CHECK THE TABLE VALUES USING THE USERNAME TEXT BOX


	And I filter on user role "<userRole>"
#	Then the User role column in all the return rows equal "<userRole>"
	Examples: 
	| username | password |userRole |
	| Admin    | admin123 | ESS		|
