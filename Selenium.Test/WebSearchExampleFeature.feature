#This is the default step class name
Feature: Basic Google Search
	In order to find stuff on the web
	As a google user
	I want to to search for stuff

Scenario: Example - Search with Google
	Given I want to search with "google"
	When When I search for "freemansoft"
	Then My search term should be in the title bar

Scenario: Example - Search with Bing
	Given I want to search with "bing"
	When When I search for "freemansoft"
	Then My search term should be in the title bar

Scenario Outline: Example - Search and Title Matches
	Given I want to search with "<engine>"
	When When I search for "<criteria>"
	Then My search term should be in the title bar
	Examples: 
	  | engine | criteria |
	  | google | amazon   |
	  | bing   | amazon   |
	  | google | facebook |
	  | bing   | facebook |
