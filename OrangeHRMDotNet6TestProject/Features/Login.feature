﻿Feature: Login

A short summary of the feature

@tag1
Scenario Outline: Log in to the OrangeHRM site
	Given I navigate to the Login page
	When I enter username "<username>" and password "<password>"
	Then the dashboard page is displayed
	Examples: 
	| username | password	|
	| Admin    | admin123	|