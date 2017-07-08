# BankApp.net

This Workshop lab assumes you have an IDE and runtime that supports .Net Framework.  
Visual studio on Windows is the most obvious candidate for this.  
The simplest thing for Mac users is to run a Windows VM on the Mac or in a cloud provider

# Windows Users
  * Install Visaual Studio 2017 (any version)
    * The following workloads are required: This will require 5GB if using VS 2017 Community
    * .Net desktop development
    * ASP.net and web development
  * Install the following extensions. You can try and install these from "tools and options" but I had to download this extension and install it from outside VS2017 community.  
    * [SpecFlow for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio2017)
    * [GitHub for Visual Studio 2017](https://marketplace.visualstudio.com/items?itemName=GitHub.GitHubExtensionforVisualStudio) (optional)
	
# Mac Users
  * TBD

# Projects
  * BankApp
    * The default ASP.Net Bank App demo. This is included in case we wish to deploy an application into the cloud.  It is not tied to the other projects.
  * BankLibrary
    * The library and test projects for the Banking class exercise.  
    * Example files include "example" in the names. Other files are stubs for exercises
  * Exercises
    * The library, MSTest and Specflow test projects for the HelloWorld, StringSet and any other TDD class exercises other than "Bank"
    * Example files include "example" in the names. Other files are stubs for exercises
  * Selenium
    * A place to put Selenium based web test exercises.
    * Example files include "example" in the names. Other files are stubs for exercises


