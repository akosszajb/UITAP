using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ScrollbarsPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private ScrollbarsPage _scrollbarsPage;
    
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
        _scrollbarsPage = new ScrollbarsPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenScrollbarsPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void ScrollbarsPageTest00_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Scrollbars')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'An application may use native or custom')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Find a button in the scroll')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Update your test to automatically')]")));
        var scenarioListElement3 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your test to')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Scrollbars page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Scrollbars page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Scrollbars page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Scrollbars page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Scrollbars page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(scenarioListElement3.Displayed, "Scrollbars page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Scrollbars page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void ScrollbarsPageTest01_ScrollToFindTheHiddenButtonAndClickOnIt()
    {
        _scrollbarsPage.ButtonClickerWithScrolling();
        var button = _wait.Until(driver=> driver.FindElement(By.ClassName("btn-primary")));
        var scrollArea = _wait.Until(driver=>driver.FindElement(By.CssSelector("div[style*='overflow-y: scroll']")));
        var buttonLocation = button.Location;
        var scrollAreaLocation = scrollArea.Location;
        var scrollAreaSize = scrollArea.Size;
        Assert.IsTrue(buttonLocation.Y < scrollAreaLocation.Y + scrollAreaSize.Height, "The button is not displayed after scrolling.");
    }
    
    [Test]
    public void ScrollbarsPageTest02_ClickOnTheHiddenButtonWithoutScollingToIt()
    {
        var button = _wait.Until(driver=> driver.FindElement(By.ClassName("btn-primary")));
        var scrollArea = _wait.Until(driver=>driver.FindElement(By.CssSelector("div[style*='overflow-y: scroll']")));
        var buttonLocation = button.Location;
        var scrollAreaLocation = scrollArea.Location;
        var scrollAreaSize = scrollArea.Size;
        Assert.IsTrue(buttonLocation.Y > scrollAreaLocation.Y + scrollAreaSize.Height, "The button is displayed without scrolling.");
    }
    
    [Test]
    public void ScrollbarsPageTest03_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ScrollbarsPageTest04_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void ScrollbarsPageTest05_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void ScrollbarsPageTest06_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ScrollbarsPageTest07_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void ScrollbarsPageTest08_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void ScrollbarsPageTest09_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void ScrollbarsPageTest10_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}