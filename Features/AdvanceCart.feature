﻿Feature: AdvanceCart

A short summary of the feature

@UnitTestAdvanceCart
Scenario: Nevigate to the login page
	Given Nevigate to the admin page
	When Nevigate to Click on the login url
	Then After login go to admin home
	And logout link should be visible
	Then After go to admin home configure attributes
	
