Feature: HelloWorldExample
	

@mytag
Scenario: Example - Hello World - Say Hello to Someone
	Given I meet a person I wish to greet
	And I know their name is "John"
	When I greet them
	Then The result should be "Hello John"
