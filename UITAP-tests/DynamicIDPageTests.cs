using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class DynamicIDPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private DynamicIDPage _dynamicIdPage;

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
        _dynamicIdPage = new DynamicIDPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenDynamicIdPage();   
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void DynamicIDPageTest0_AllTextsAreVisible()
    { 
    var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Dynamic ID')]")));
    var description = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Modern applications often')]")));
    var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
    var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Record button')]")));
    var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your test')]")));
    var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
    Assert.IsTrue(title.Displayed, "Dynamic ID is not loaded properly (Title is not visible)");
    Assert.IsTrue(description.Displayed, "Dynamic ID is not loaded properly (Description is not visible)");
    Assert.IsTrue(scenarioList.Displayed, "Dynamic ID is not loaded properly (ScenarioList is not visible)");
    Assert.IsTrue(scenarioListElement1.Displayed, "Dynamic ID is not loaded properly (ScenarioListElement1 is not visible)");
    Assert.IsTrue(scenarioListElement2.Displayed, "Dynamic ID is not loaded properly (ScenarioListElement2 is not visible)");
    Assert.IsTrue(playground.Displayed, "Dynamic ID is not loaded properly (Playground is not visible)");
    
    }
    
    // Scenario
    // Record button click.
    // Then execute your test to make sure that ID is not used for button identification.
    [Test]
    public void DynamicIDPageTest1_ButtonBehavior()
    {
        // Record button click.
        _dynamicIdPage.ButtonClicker();
        // Then execute your test to make sure that ID is not used for button identification.
        _driver.Navigate().Refresh();
        _dynamicIdPage.ButtonClicker();
    }
    
    [Test]
    public void DynamicIDPageTest2_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void DynamicIDPageTest3_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void DynamicIDPageTest4_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void DynamicIDPageTest5_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void DynamicIDPageTest6_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void DynamicIDPageTest7_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void DynamicIDPageTest8_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void DynamicIDPageTest9_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}