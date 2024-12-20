using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class AJAXDataPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private WebDriverWait _longerWait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private AJAXDataPage _AjaxDataPage;
    
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--disable-search-engine-choice-screen");
        options.AddArguments("--start-maximized");
        var testName = TestContext.CurrentContext.Test.Name;
        if (testName.Contains("ooterTest2_RapiseLink") || testName.Contains("ooterTest3_InflectraCorporationLink"))
        {
            options.AddUserProfilePreference("profile.managed_default_content_settings.images", 2); // Képek blokkolása
        }
        
        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        _longerWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        _mainPage = new MainPage(_driver, _wait);
        _navbar = new Navbar(_driver, _wait);
        _footer = new Footer(_driver, _wait);
        _AjaxDataPage = new AJAXDataPage(_driver, _longerWait);
        _mainPage.LoadMainPage();
        _mainPage.OpenAJAXDataPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void AJAXDataPageTest00_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'AJAX Data')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'An element may appaear on a page ')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Record the following steps. Press')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your test to make sure it waits')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Class Attribute page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Class Attribute page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Class Attribute page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Class Attribute page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Class Attribute page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Class Attribute page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void AJAXDataPageTest01_ClickButtonLongWait()
    {
        _AjaxDataPage.ButtonClicker();
        var ajaxResultElement = _longerWait.Until(driver => driver.FindElement(By.ClassName("bg-success")));
        
        Assert.IsTrue(ajaxResultElement.Displayed, "Green result element is not loaded in 20 sec.");
    }
    
    // This test is for demonstration purposes only, to illustrate the behavior of delayed loading.
    // This part of the site is working correctly, but the test "fails" intentionally to show the expected behavior for educational purposes.
    [Test]
    public void AJAXDataPageTest02_ClickButtonShortWait()
    {
        _AjaxDataPage.ButtonClicker();
        var ajaxResultElement = _wait.Until(driver => driver.FindElement(By.ClassName("bg-success")));
        Assert.IsTrue(ajaxResultElement.Displayed, "Green result element is not loaded in 5 sec (below 20 sec is good enough).");
    }
    
    [Test]
    public void AJAXDataPageTest03_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void AJAXDataPageTest04_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void AJAXDataPageTest05_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void AJAXDataPageTest06_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void AJAXDataPageTest07_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void AJAXDataPageTest08_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void AJAXDataPageTest09_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void AJAXDataPageTest10_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}