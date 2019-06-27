 ## TEST AUTOMATION ARCHITECTURE (Documentation In Progress)
- [Architecture](#Architecture)
- [Solution Components](#Solution-Components)
    - [Test Specification Layer](#Test-Specification-Layer)
    - [Factory Layer](#Factory)
    - [Electron Application Page Layer](#Electron-Application-Page-Layer)
    - [Library](#Library)
      - [Common Library](#Library)
      - [Selenium Library](#Library)
      - [Logger](#Logger)
      - [Environment Manager](#EnvironmentManager)
      - [Extent Report Integration](#Extent-Report-Integration)
      
 - [Solution setup](#Solution-Setup)
     - [Pre-requisites](#Prerequisites)
     - [How to write a test](#How-to-write-a-test)
 - Features
 - Custom attributes used
 - Guidelines (Important)
 - Packages Used 
 - FAQs
 - Checklist

---
### Architecture

> ![alt text](TestArchitecture.jpg)
---
### Solution Components

> ![Solution Structure](SolutionStructure.png)

#### Test Specification Layer

> ![Test Specification Layer](TestSpecificationLayer.png)

##### Tests

- Project is independent of the application type (Web,Mobile App, Electron)
- Each test case is written with clear and concise test steps, just like a test requirement document.
- This project DO NOT directly use or reference any Library methods.
- The Page class object to be used in the test case is decided by the Platform provided in the TestFixture attribute (Available Platform types: Electron, Android, iOS, Web)
- Factory in the Test Class constructor takes Page Interface as input and depending on platform, provides you the page object.

###### Sample Code

    [TestFixture(Platform.Electron), Regression]
    public class ExpressPointLogin : TestBase
    {
        private ILogIn _LogIn;

        public ExpressPointLogin(Platform pType) : base(pType)
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(pType, _base);
        }

        [TestCase]
        public void LogInTest()
        {
            #region Test Data Initialization

            UserDto userData = TestDataHelper.ReadJsonText<UserDto>();

            #endregion Test Data Initialization

            _LogIn.ResetLogIn();
            _LogIn.SearchDistrict(userData.Data.District);
            _LogIn.LogIn(userData.Data.Username, userData.Data.Password);
            _LogIn.SelectServiceLocation(userData.Data.ServingLocation);
        }
    }
##### TestBase Class

- TestBase Class has TestCaseSetup, TestCaseTeardown, TestSuiteTearDown and a constructor acting as a test suite setup.
- This class also uses factory to generate base class object depending on the platform.
- This class also DO NOT directly consume any library methods and is independent of the platform.

###### Sample Code

```<language>
    public class TestBase
    {
        protected ITestBase _base;

        public TestBase() : this(Platform.Electron)
        { }

        public TestBase(Platform toolType)
        {
            _base = BaseFactory.GetInstance<ITestBase>(toolType);
        }

        [SetUp]
        public void TestSetup()
        {
            _base.TestSetUp();
        }

        [TearDown]
        public void TestTeardown()
        {
            _base.TestTearDown();
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            _base.FinalTearDown();
        }
    }
```
##### AssemblyBase Class
- AssemblyBase contains Setup and Teardown methods which runs before  and after all the tests in project runs.
- This class is without nampespance and uses NUnit attributes

###### Code
```<language>
using Cybersoft.Common.Library;
using NUnit.Framework;

[SetUpFixture]
public class AssemblyBase
{
    [OneTimeSetUp]
    public void AssemblySetup()
    {
        ExtentReport.InitiateExtentReport();
    }

    [OneTimeTearDown]
    public void AssemblyTeardown()
    {
        ExtentReport.Extent.Flush();
    }
}
```


#####  Test Data Strategy

- Test execution data required for populating and verifying fields is stored in Json files.
- Name of the Json file should be of format <TestMethodName>_data.Json
- One json test data file per test method (can also provide shared test data file)
- NewtonsoftJson is used to read json data and map it to Test data object classes
- Refer https://app.quicktype.io/ to convert json files to typed data objects (do not copy the converter methods, just typed data objects)

###### Sample Json Test Data
```<language>
{
  "data": {
    "username": "vikram",
    "password": "demopass",
    "district": "MONROE COUNTY SCHOOLS",
    "serving_location": "503 - JAMES MONROE HIGH SCHOOL"
  }
}
```
###### Sample TDO

```<language>
using Newtonsoft.Json;

namespace Cybersoft.Common.Library.DTO
{
    public class UserDto
    {
        [JsonProperty("data")]
        public Datum Data { get; set; }
    }

    public class Datum
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("serving_location")]
        public string ServingLocation { get; set; }
    }
}
```
##### Factory
- Cybersoft.ExpressPoint.Pages.Factory project is responsible for providing desired page objects depending on the type of Platform and Interface provided to it.
- It contains a BaseFactory class with a generic method GetInstance<T>

###### Code:

```<language>
namespace Cybersoft.ExpressPoint.Pages.Factory
{
    public class BaseFactory
    {
        public static T GetInstance<T>(Platform tool, object param = null)
        {
            T obj = default(T);
            try
            {
                if (tool == Platform.Electron)
                {
                    switch (typeof(T).Name)
                    {
                        case nameof(ITestBase):
                            obj = (T)Activator.CreateInstance(typeof(ElectronBase));
                            break;

                        case nameof(ILogIn):
                            obj = (T)Activator.CreateInstance(typeof(LogInPage), param);
                            break;

                        default:
                            obj = default; ;
                            break;
                    }
                }

                if (obj == null)
                    throw new Exception("Platform or Instance Creation Case not added: Tool:- " + tool.ToString() + ", Instance: " + typeof(T).Name);

                return obj;
            }
            catch (Exception ex)
            {
                Assert.Fail("Exception occured!!" + ex.Message);
                return obj;
            }
        }
```

###### Usage Example
```<language>
public ExpressPointLogin(Platform pType) : base(pType)
        {
            _LogIn = BaseFactory.GetInstance<ILogIn>(pType, _base);
        }
```
### Electron Application Page Layer
- Separate project is created for storing Pages (Screens of the application) build over Electron app (If the application is created over Android/Web/iOS, separate project should be created )
- Page classes is this project will consume Selenium library project methods (for Android/Web separate library projects shoukd be created)to perform test operations.
- No direct reference of Selenium Native components should be called here, only wrapper methods (from Selenium library project) should be called.

Example:

> ![Page Implementation](PageImplementation.png)

---
### Library
- To deal with elements of application of any platform (Android, web or electron) for automation, we need different types of library components (like selenium, appium etc.). We also need some common components which are platform indepndent (like reading json/execl, logging , file operations.)
- This framework has two library components
    - **Cybersoft.Common.Library project**: 
      - Contains all the methods which can be used across the projects  ![Common Library](CommonLibrary.png)
      - *Attribues*: Contains custom made NUnit attributes Ex: Regression, Smoke
      - *Contracts*: Contains all the interfaces created for page classes
      - *DTO*: Contains all the Data Typed Object classes, used for mapping test data from JSON.
      - *Enums*: Contains all the enums created. Ex: Platform, TestType
      - *Helper*: Contains helper classe that can be used across all the projects Ex: TestdataHelper and Logger class
    - **Cybersoft.ExpressPoint.Selenium.Library project**:
      - Contains C# extension methods over Selenium native methods.
      - It handles basic webdriver synchronization issues.
      - For Appium related helper, Cybersoft.ExpressPoint.Appium.Library project will be used.
      - All the pages should consume the wrapped methods of Selenium and not the direct methods.
#### Logger
- Logger class is present inside common library project and is responsible for logging all the activities through ExtentReport package.
- Logger methods should be used before and after each step of page class test step methods
- Logging will get reported in in Extent Report created at the end of test suite.
- Screenshot can also be provide along with the log. Example:
```<language>
    public static void LogFail(string logmsg, MediaEntityModelProvider provider = null)
    {
        var status = Status.Fail;
        ExtentReport.ExtentTest.Log(status, logmsg, provider);
    }
    *USAGE*
    Logger.LogFail("Specified functionality: "+ functionality.ToString()+" not available in the Menu!",ExtentReport.CreateScreenCapture(_driver.GetScreenshot()));
```

### EnvironmentManager 
- EnvironmentManager class is present inside common library project, responsible for providing TestAutomation Environment variables that can be used across the automation framework.
- All the relative paths of various files used by frameworks are stored here.
- Any new path or variable that you think will accessible across the framework can be stored here , care should be taken while providing the path, it should be accessible by any user in any environments (Use System Environment class to get the path required.)
- Example: 
```<language>
namespace Cybersoft.Common.Library
{
    //----Chromedriver.exe specificaly for Electron downloaded from https://github.com/electron/electron/releases
    //----chromedriver version used: chromedriver-v4.2.2-win32-x64 (Because our app is build over chromium version 66)
    //----ExpressPoint app should be built with devtools enabled

    public static class EnvironmentManager
    {
        public static string LogPath { get; } = Path.GetTempPath() + @"\ExpressPointLogs\Logs\";
        public static string AssemblyPath { get; } = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/TestData/";
        public static string ExpressPointPath { get; } = Environment.GetEnvironmentVariable("LocalAppData") + @"\ExpressPoint\app-1.2.0\ExpressPoint.exe";
        public static string ExpressPointPort { get; } = "9515";

        public static string ElectronDriverPath { get; } = Path.Combine(
                                                           Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                                                           , @"..\..\..\..\..") + @"\Solution Items\ElectronDriver";

        public static TimeSpan GlobalTimeOut { get; } = TimeSpan.FromSeconds(120);
        public static string ScreenshotPath { get; } = Path.GetTempPath() + @"ExpressPointLogs\Screenshots\";
        public static string ExtentReportPath { get; } = Path.GetTempPath() + @"ExpressPointLogs\Reports\dashboard.html";
        public static string HtmlReportTitle { get; } = @"Automation Test Report";
        public static string HtmlReportName { get; } = @"Functional Report";
        public static Theme HtmlReportTheme { get; } = Theme.Standard;
        public static string EnvironmentName { get; } = "Test Environment";
        public static string CurrentUserName { get; } = Environment.UserName;
    }
}
```

### Extent Report Integration
- Test Automation framework uses Extent Reports for reporting detailed test case results along with logging.
- ExtentReport class which contains helper methods for dealing with Extent Report is present in the common library.
![Extent Report](ExtentReport.png)
![Extent Report1](ExtentReport1.png)
  
### Solution Setup

- Checkout the solution from TFS Location: *$/Express/ExpressPointTestAutomation*
- Open .sln file in Visual Studio and make sure you are able build it successfully

#### Prerequisites
- Should have ExpressPoint (app-1.2.0) installed on the system (I you want to change the path of Expresspoint.exe , 
change at -EnvironmentManager.cs and update ExpressPointPath (Exclude this file during checkin))
- Location of the ExpressPoint.exe should be inside of the app-1.2.0 folder and not of the root level

#### How to Write a Test
Points to remember before start writing a test:
1. Each test class acts as a test suite (generally the feature name) Ex: LogInSuite.cs
2. Each test method inside a test class acts as a test case (Test name as method name) Ex: SuccessfulLogInTest.cs
3. Each step inside a test method acts as a test step, they should also get asserted.
4. Before adding any test class, check if any test class is already present for the test you are adding, if not then only create a new test class otherwise use the existing one.

- [ ] *Step 1*: In Cybersoft.ExpressPoint.Test project, inside Tests folder add a new Test class (if not already present)
- [ ] *Step 2*: Test Class should be inherited from TestBase class (See [sample code](#Sample-Code) for reference)
- [ ] *Step 3*: Add a new interface in Contracts folder of Cybersoft.Common.Library project for every page class you add in Cybersoft.ExpressPoint.Selenium.Pages project (Again, please make sure you do not add duplicate Interface and Page).
- [ ] *Step 4*: Add a new case of added Interface in BaseFactory class.
- [ ] *Step 5*: Every page class will implement the respective interface test steps.
- [ ] *Step 6*: For adding test data refer [Test Data Strategy](#Test-Data-Strategy)
- [ ] *Step 7*: In test class add a constructor and call GetInstance method to get instance of the page class based on the interface provided to it
- [ ] *Step 8*: Add a test method and access test steps using instance of the page object recieved using Step 6.
- [ ] *Step 9*: If a test involves dealing with multiple pages, then create multiple page instances by calling GetInstance method multiple times in the constructor.
Example:         
```<language>
private ILogIn _LogIn;
private IAdmin _Admin;

public ExpressPointLogin(Platform pType) : base(pType)
{
    _LogIn = BaseFactory.GetInstance<ILogIn>(pType, _base);
    _Admin = BaseFactory.GetInstance<IAdmin>(pType, _base);
}
```
- [ ] *Step 10*: As mentioned in Step 5, add a Page class in Cybersoft.ExpressPoint.Selenium.Pages Project and implement test step methods.
