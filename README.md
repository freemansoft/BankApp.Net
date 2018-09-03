# BankApp.net

This Workshop lab assumes you have an IDE and runtime that supports .Net Framework.  
Visual studio on Windows is the most obvious candidate for this.  
The simplest thing for Mac users is to run a Windows VM on the Mac or in a cloud provider

# Windows Users
The project is currently bound to .Net 4.7 with the expectation that teams will be running Windows 10.
The solution can probably be targeted at earlier versions of .Net without any issues

  * Install Visual Studio 2017 (any version)
    * The following workloads are required: This will require 6.5GB of disk space if using VS 2017 Community
      * .Net desktop development
      * ASP.net and web development
        * This is to support BankApp and BankApp.Tests. You can remove this dependency if you delete those projects.
  * Install the following Visual Studio extensions. You can try and install these from "tools and options" but I had to download this extension and install it from outside VS2017 community.  
    * [SpecFlow for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017)
    * [GitHub for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=GitHub.GitHubExtensionforVisualStudio) (optional)
    
# Mac Users
  * TBD

# Projects

The projects are organized to segregate the code from unit tests as we would in a real project.
Some people, for class, will just do all the work in a single project

## Exercises ##
 Class library, MSTest, [moq](https://github.com/moq) and [Specflow](http://specflow.org/) test projects for the HelloWorld, StringSet and any other TDD class exercises other than "Bank"
  * **Exercises**: StringSet and HelloWorld exercies classes
    * Files with _example_ in the name show possible solutions
  * **Exercises.Test**: StringSet and HelloWorld test classes
    * Files with _example_ in the name show possible solutions
  * **Exercises.BDD.Test**: SpecFlow feature and step files executed with MSTest
    * Files with _example_ in the name show possible solutions

## BankLibrary ##
Class library and test projects for the Banking class exercise.  
  * **BankLibrary**: Banking exercise classes
      * Files with _example_ in the name show possible solutions
  * **BankLibrary.Test**: MSTest test classes
    * Files with _example_ in the name show possible solutions
  * **BankLibrary.BDD.Test**: Specflow feature and step files executed with MSTest
    * Files with _example_ in the name show possible solutions

## Selenium ##
A place to put Selenium based web test exercises.
  * **Selenium.Test**: Specflow feature and step files executed with MSTest
    * **BDDExample... **demonstrates SpecFlow style BDD
    * **ExampleWebSearchTest** demonstrates selenium tests directly using the API
    * **PoPExample...** Demonstrate one style of PageObjectPattern

## BankApp ##
The default ASP.Net Bank App demo. This is included in case we wish to deploy an application into the cloud.  It is not tied to the other projects.
  * **BankApp**: ASP.Net web application
  * **BankApp.Tests**: MSTest classes
    * This project contains no _example_ test solutions


# Troubleshooting
An exception occurred while invoking executor 'executor://mstestadapter/v2': Constructor on type 'Microsoft.VisualStudio.TestPlatform.MSTest.TestAdapter.Execution.UnitTestRunner' not found.

Clear the Cache. See: [Stack Overflow](https://stackoverflow.com/questions/45444266/couldnt-run-tests-after-updating-testframework-in-nuget)


# Links
  * [Moq Tutorial](https://github.com/Moq/moq4/wiki/Quickstart)
  * [Selenium Page Patter on Pluralsight](https://www.pluralsight.com/guides/software-engineering-best-practices/getting-started-with-page-object-pattern-for-your-selenium-tests)
  * [Code Style Analysis](https://blogs.msdn.microsoft.com/dotnet/2016/12/15/code-style-configuration-in-the-vs2017-rc-update/)
  * [Better Code Analysis with Resharper](https://www.jetbrains.com/resharper/features/code_analysis.html)
  


