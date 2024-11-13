using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class VisibilityPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private VisibilityPage _visibilityPage;
    
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
        _visibilityPage = new VisibilityPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenVisibilityPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void VisibilityPageTest00_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Visibility')]")));
        var description = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Checking if element is visible on screen')]")));
        var descriptionListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'An element may ')]")));
        var descriptionListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'it may have')]")));
        var descriptionListElement3 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'it may be covered')]")));
        var descriptionListElement4 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'it may be hidden')]")));
        var descriptionListElement5 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'or moved off')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Learn locators')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'In your testing')]")));
        var scenarioListElement3 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Determine if other')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Verify Text page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description.Displayed, "Verify Text page is not loaded properly (Description is not visible)");
        Assert.IsTrue(descriptionListElement1.Displayed, "Verify Text page is not loaded properly (Description is not visible)");
        Assert.IsTrue(descriptionListElement2.Displayed, "Verify Text page is not loaded properly (Description is not visible)");
        Assert.IsTrue(descriptionListElement3.Displayed, "Verify Text page is not loaded properly (Description is not visible)");
        Assert.IsTrue(descriptionListElement4.Displayed, "Verify Text page is not loaded properly (Description is not visible)");
        Assert.IsTrue(descriptionListElement5.Displayed, "Verify Text page is not loaded properly (Description is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Verify Text page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Verify Text page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Verify Text page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement3.Displayed, "Verify Text page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(playground.Displayed, "Verify Text page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void VisibilityPageTest01_HideTheButtonClick_RemovedButton()
    {
        _visibilityPage.HideButtonClicker();
        Console.WriteLine(_visibilityPage.IsVisible("RemovedButton"));
        Assert.IsTrue(_visibilityPage.IsVisible("RemovedButton"), "The removed button is still present.");
    }

    [Test]
    public void VisibilityPageTest02_HideTheButtonClick_ZeroWidthButton()
    {
        _visibilityPage.HideButtonClicker();
        
        Assert.IsTrue(_visibilityPage.IsVisible("ZeroWidthButton"), "The zero-width button is visible.");
    }
    
    [Test]
    public void VisibilityPageTest03_HideTheButtonClick_OverlappedButton()
    {
        _visibilityPage.HideButtonClicker();
        
        Assert.IsTrue(_visibilityPage.IsVisible("OverlappedButton"), "The overlapped button is not covered.");
    }
    
    [Test]
    public void VisibilityPageTest04_HideTheButtonClick_Opacity0Button()
    {
        _visibilityPage.HideButtonClicker();
        
        Assert.IsTrue(_visibilityPage.IsVisible("Opacity0Button"), "The button with opacity 0 is visible.");
    }
    
    [Test]
    public void VisibilityPageTest05_HideTheButtonClick_VisibilityHiddenButton()
    {
        _visibilityPage.HideButtonClicker();
        
        Assert.IsTrue(_visibilityPage.IsVisible("VisibilityHiddenButton"), "The button with visibility hidden is visible.");
    }
    
    [Test]
    public void VisibilityPageTest06_HideTheButtonClick_DisplayNoneButton()
    {
        _visibilityPage.HideButtonClicker();
        
        Assert.IsTrue(_visibilityPage.IsVisible("DisplayNoneButton"), "The button with display: none is visible.");
    }
    
    [Test]
    public void VisibilityPageTest07_HideTheButtonClick_OffscreenButton()
    {
        _visibilityPage.HideButtonClicker();
        
        Assert.IsTrue(_visibilityPage.IsVisible("OffscreenButton"), "The offscreen button is visible.");
    }
    
    [Test]
    public void VisibilityPageTest08_HideTheButtonClick_AllButton()
    {
        _visibilityPage.HideButtonClicker();
        Assert.IsTrue(_visibilityPage.IsVisible("RemovedButton"), "The removed button is still present.");
        Assert.IsTrue(_visibilityPage.IsVisible("ZeroWidthButton"), "The zero-width button is visible.");
        Assert.IsTrue(_visibilityPage.IsVisible("OverlappedButton"), "The overlapped button is not covered.");
        Assert.IsTrue(_visibilityPage.IsVisible("Opacity0Button"), "The button with opacity 0 is visible.");
        Assert.IsTrue(_visibilityPage.IsVisible("VisibilityHiddenButton"), "The button with visibility hidden is visible.");
        Assert.IsTrue(_visibilityPage.IsVisible("DisplayNoneButton"), "The button with display: none is visible.");
        Assert.IsTrue(_visibilityPage.IsVisible("OffscreenButton"), "The offscreen button is visible.");
    }

    [Test]
    public void VisibilityPageTest09_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void VisibilityPageTest10_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void VisibilityPageTest11_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void VisibilityPageTest12_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void VisibilityPageTest13_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void VisibilityPageTest14_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void VisibilityPageTest15_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void VisibilityPageTest16_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}