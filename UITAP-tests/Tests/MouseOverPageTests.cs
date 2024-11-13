using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class MouseOverPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private MouseOverPage _MouseOverPage;

    
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
        _mainPage = new MainPage(_driver, _wait);
        _navbar = new Navbar(_driver, _wait);
        _footer = new Footer(_driver, _wait);
        _MouseOverPage = new MouseOverPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenMouseOverPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void MouseOverPageTest00_AllTextsAreVisible()
    {
    
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Mouse Over')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Placing mouse over an element ')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Record 2 consecutive')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Execute the test and make')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
        var playgroundDescription1= _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'The link below will be replaced')]")));
        var playgroundDescription2= _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'The link below will be replaced with identical')]")));
    
        Assert.IsTrue(title.Displayed, "Mouse Over page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Mouse Over page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Mouse Over page is not loaded properly (Scenario is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Mouse Over page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Mouse Over page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Mouse Over page is not loaded properly (Playground is not visible)");
        Assert.IsTrue(playgroundDescription1.Displayed, "Mouse Over page is not loaded properly (Playground description1 is not visible)");
        Assert.IsTrue(playgroundDescription2.Displayed, "Mouse Over page is not loaded properly (Playground description2 is not visible)");
    }
    
    [Test]
    public void MouseOverPageTest01_ClickMeCounterZeroWithoutClicking()
    {
       Assert.AreEqual(0, _MouseOverPage.GetClickMeCounter(), "The Click me counter is not zero before clicking!");
    }
    
    [Test]
    public void MouseOverPageTest02_LinkButtonCounterZeroWithoutClicking()
    {
        Assert.AreEqual(0, _MouseOverPage.GetLinkButtonCounter(), "The Link Button counter is not zero before clicking!");
    }
    
    [Test]
    public void MouseOverPageTest03_ClickMeClicking()
    {
        _MouseOverPage.ClickMeLinkClicker();
        _MouseOverPage.ClickMeLinkClicker();
        _MouseOverPage.ClickMeLinkClicker();
        _MouseOverPage.ClickMeLinkClicker();
        Assert.AreEqual(4, _MouseOverPage.GetClickMeCounter(), "The Click me counter is not 4 after 4 clicking!");
    }
    
    [Test]
    public void MouseOverPageTest04_LinkButtonClicking()
    {
        _MouseOverPage.LinkButtonLinkClicker();
        _MouseOverPage.LinkButtonLinkClicker();
        _MouseOverPage.LinkButtonLinkClicker();
        _MouseOverPage.LinkButtonLinkClicker();
        Assert.AreEqual(4, _MouseOverPage.GetLinkButtonCounter(), "The Link Button counter is not 4 after 4 clicking!");
    }
    
    [Test]
    public void MouseOverPageTest05_ClickMeCounterAfterRefresh()
    {
        _MouseOverPage.ClickMeLinkClicker();
        _MouseOverPage.ClickMeLinkClicker();
        _MouseOverPage.ClickMeLinkClicker();
        _MouseOverPage.ClickMeLinkClicker();
        _driver.Navigate().Refresh();
        Assert.AreEqual(0, _MouseOverPage.GetClickMeCounter(), "The Click me counter is not 4 after 4 clicking!");
    }
    
    [Test]
    public void MouseOverPageTest06_LinkButtonCounterAfterRefresh()
    {
        _MouseOverPage.LinkButtonLinkClicker();
        _MouseOverPage.LinkButtonLinkClicker();
        _MouseOverPage.LinkButtonLinkClicker();
        _MouseOverPage.LinkButtonLinkClicker();
        _driver.Navigate().Refresh();
        Assert.AreEqual(0, _MouseOverPage.GetLinkButtonCounter(), "The Link Button counter is not 4 after 4 clicking!");
    }
    
    [Test]
    public void MouseOverPageTest07_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void MouseOverPageTest08_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void MouseOverPageTest09_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void MouseOverPageTest10_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void MouseOverPageTest11_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void MouseOverPageTest12_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void MouseOverPageTest13_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void MouseOverPageTest14_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}