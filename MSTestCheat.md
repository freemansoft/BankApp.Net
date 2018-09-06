

## Primary MSTest Attributes ##
These Attributes are applied to _test classes_ and picked up as part of test processing.

|Construct|Annotation Target|Purpose|Sample Signature|
|===|===|===|===|
|[TestClass]|Class|Identifies a test class| public class Foo{}|
| | | | |
|[AssemblyInitialize]|Static Method|Invoke one time on assembly load|public static void AssemblyInit(TestContext context)|
|[ClassInitialize]|Static Method|One time inovke for all test methods in class|public static void TestClassSetup(TestContext context)|
|[TestInitialize]|Instance Method|Invoked prior to every test in class|public void Setup()|
| | | | |
|[AssemblyCleanup()]|Static Method|Invoke one time on Assembly unload|public Static void AssemblyCleanup()|
|[ClassCleanup]|Static Method|Invoke one time after all tests in class complete|public static void TestClassCleanup()|
|[TestCleanup]|Instance Method|Invoked after each test in class completes|public void TearDown()|
| | | | |
|[TestMethod]|TestMethod|Mark method as test|public void MyTest()|
|[ExpectedException(typeof(\<ExceptionClassName\>))]|Test Method|Declare 'TestMethod' expects to throw an exception|public void MyTest()|
| | | | |

## Excluding code from coverage ##
VS includes all assemblies when calculating code coverage, including test assemblies.  This is pretty stupid.
See the Microsoft documentation for [customizing code coverage](https://docs.microsoft.com/en-us/visualstudio/test/customizing-code-coverage-analysis?view=vs-2017)

* Use a .runsettings file for project / global level exclusions.  Exclude an entire dll with the ModulePath XML section.
~~~
<ModulePaths>  
  <Exclude>  
   <ModulePath>Fabrikam.Math.UnitTest.dll</ModulePath>  
   <!-- Add more ModulePath nodes here. -->  
  </Exclude>  
</ModulePaths>  
~~~
** You can use the following attribute to tell VS to ignore some code block from code coverage calculations.
This can be applied at various scopes.
~~~
  [ExcludeFromCodeCoverageAttribute]
~~~ 
