Feature: Announcement

A short summary of the feature

@Announcement
Scenario: Implementation in announcement plugin
	Given Go to the admin page
	When Click on the login Url
	Then Give email and pass for login
	And Make sure that the username should be visible after login
	Then Go to admin home and configure announcement item
	Then Make changes on the configuration part

