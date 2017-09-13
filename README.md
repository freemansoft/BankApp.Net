# BankApp.net

This Workshop lab assumes you have an IDE and runtime that supports .Net Framework.  
Visual studio on Windows is the most obvious candidate for this.  
The simplest thing for Mac users is to run a Windows VM on the Mac or in a cloud provider

# Windows Users
  * Install Visaual Studio 2017 (any version)
    * The following workloads are required: This will require 6.5GB of disk space if using VS 2017 Community
    * .Net desktop development
    * ASP.net and web development
  * Install the following extensions. You can try and install these from "tools and options" but I had to download this extension and install it from outside VS2017 community.  
    * [SpecFlow for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017)
    * [GitHub for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=GitHub.GitHubExtensionforVisualStudio) (optional)
    
# Mac Users
  * TBD

# Projects
  * Exercises
    * Class library, MSTest, [moq](https://github.com/moq) and [Specflow](http://specflow.org/) test projects for the HelloWorld, StringSet and any other TDD class exercises other than "Bank"
      * Exercies: StringSet and HelloWorld exercies classes
      * Exercises.Test: StringSet and HelloWorld test classes
      * Exercises.BDD.Test: SpecFlow feature and step files executed with MSTest
    * Example files include "example" in the names. Other files are stubs for exercises
  * BankLibrary
    * Class library and test projects for the Banking class exercise.  
      * BankLibrary: Banking exercise classes
      * BankLibrary.Test: MSTest test classes
      * BankLibrary.BDD.Test: Specflow feature and step files executed with MSTest
    * Example files include "example" in the names. Other files are stubs for exercises
  * Selenium
    * A place to put Selenium based web test exercises.
      * Selenium.Test: Specflow feature and step files executed with MSTest
    * Example files include "example" in the names. Other files are stubs for exercises
  * BankApp
    * The default ASP.Net Bank App demo. This is included in case we wish to deploy an application into the cloud.  It is not tied to the other projects.
      * BankApp: ASP.Net web application
      * BankApp.Tests: MSTest classes


# Troubleshooting
An exception occurred while invoking executor 'executor://mstestadapter/v2': Constructor on type 'Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter.Execution.UnitTestRunner' not found.

Clear the Cache. See: [Stack Overflow](https://stackoverflow.com/questions/45444266/couldnt-run-tests-after-updating-testframework-in-nuget)


# Links
  * [Moq Tutorial](https://github.com/Moq/moq4/wiki/Quickstart)
  * [Selenium Page Patter on Pluralsight](https://www.pluralsight.com/guides/software-engineering-best-practices/getting-started-with-page-object-pattern-for-your-selenium-tests)
  * [Code Style Analysis](https://blogs.msdn.microsoft.com/dotnet/2016/12/15/code-style-configuration-in-the-vs2017-rc-update/)
  * [Better Code Analysis with Resharper](https://www.jetbrains.com/resharper/features/code_analysis.html)
  


