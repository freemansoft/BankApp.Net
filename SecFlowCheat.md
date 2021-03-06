# A Speflow Lab Cheat Sheet #

## Feature Definition ##
Different types of Given/When/Then bindings and feature definitions

#### Run a test with string parameters ####
~~~~
Scenario: Example - Search with Google
  Given I want to search with "google"
  When When I search for "microsoft"
  Then My search term should be in the title bar
~~~~
binds to a step with signature
~~~
 public void GivenIWantToSearchWithGoogle(string p0)
~~~

#### Run the same test with multiple sets ####
A scenario outline can be used to run a test multiple times with different data
~~~~
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
~~~~
binds to a step with the same signature as above
~~~
 [Given(@"I want to search with ""(.*)""")]
 public void GivenIWantToSearchWithGoogle(string p0)
~~~

#### Run a step with a table of data ####

When a step in a feature has a table of data
~~~
When User enter credentials
| Key      | Value      |
| Username | testuser_1 |
| Password | Test@123   |
~~~

The step has a parameter of type _Table_
~~~
  [When(@"User enters credentials")]
  public void WhenUserEntersCredentials(Table table)
  {
  }
~~~


## Step Classes ##
These global classes can be generated by SpecFlow.

### Step Class Attributes ###

|Attribute|Binding Type|Purpose |Generated?| Method Signature|
|---|---|---|---|---|
|[Binding]|Class|Denotes class containing _steps_| no | n/a|
|[BeforeScenario]|Method|Initialization to be run before each scenario| no |public void BeforeScenario()|
|[AfterScenario]|Method|Scenario tear down| no | public void AfterScenario()|
|---|---|---|---|---|
|[Given...]|Method|Marks method as step implementation| Yes |public void GivenIWantSomething(\<optional parameters\>)|
|[When...]| Method|Marks method as step implementation| Yes |public void WhenIDoSomething(\<optional parameters\>)|
|[Then...]| Method|Marks method as step implementation| Yes |public void ThenMySearchShouldReturn(\<optional parameters\>)|


### Step Class Scenario Context ###
Use the scenario context to pass state between steps.  It is essentially a dictionary

Add state
~~~
  ScenarioContext.Current.Add("POI", new HelloWorldExample());
~~~

Get state
~~~
  ScenarioContext.Current.Get<HelloWorldExample>("POI");
~~~