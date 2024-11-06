using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class SampleAppPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private SampleAppPage _sampleAppPage;
    private string _testDataPath;
    
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--disable-search-engine-choice-screen");
        options.AddArguments("--start-maximized");
        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        _mainPage = new MainPage(_driver, _wait);
        _navbar = new Navbar(_driver, _wait);
        _footer = new Footer(_driver, _wait);
        _sampleAppPage = new SampleAppPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenSampleAppPage();
        _testDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "testdata.csv");
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void SampleAppPageTest00_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Sample App')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Fill in and submit the form')]")));
        var button = _wait.Until(driver => driver.FindElement(By.XPath("//button[text()='Log In']")));
    
        Assert.IsTrue(title.Displayed, "Sample App page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Sample App page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(button.Displayed, "Sample App page is not loaded properly (Log In button is not visible)");
        
    }
    
    [TestCase(1,1)]
    [TestCase(2,2)]
    [TestCase(3,3)]
    [TestCase(4,4)]
    public void SampleAppPageTest01_LoginWithValidUserNamePassword(int testDataRowIndex, int rowIndexToAssertion)
    {
        string[] lines = File.ReadAllLines(Path.Combine(_testDataPath));
        string name = lines[rowIndexToAssertion].Split(",").ToArray()[1];
        _sampleAppPage.LoginWithFormFill(_testDataPath, testDataRowIndex);
        Assert.IsTrue(_sampleAppPage.GetLoginStatus() == $"Welcome, {name}!", $"Welcome, {name}! sentence is not displayed!" );
    }
    
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    public void SampleAppPageTest02_LoginWithInvalidValidUserNameAndOrPassword(int rowIndex)
    {
        _sampleAppPage.LoginWithFormFill(_testDataPath, rowIndex);
        Assert.IsTrue(_sampleAppPage.GetLoginStatus() == "Invalid username/password", "Successful login with invalid password/username!");
    }
    
    [Test]
    public void SampleAppPageTest03_CheckLogoutButtonIsWorkingAfterSuccessfulLoginProcess()
    {
        _sampleAppPage.LoginWithFormFill(_testDataPath, 1);
        _sampleAppPage.LogOutButtonClick();
        var button = _wait.Until(driver => driver.FindElement(By.XPath("//button[text()='Log In']")));
        Assert.IsTrue(button.Displayed, "Log In button is not displayed after log out.");
    }
    
    
    [Test]
    public void SampleAppPageTest04_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void SampleAppPageTest05_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void SampleAppPageTest06_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void SampleAppPageTest07_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void SampleAppPageTest08_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void SampleAppPageTest09_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void SampleAppPageTest10_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void SampleAppPageTest11_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}