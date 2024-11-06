using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class LoadDelaysTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private LoadDelayPage _loadDelayPage;
    

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
        _loadDelayPage = new LoadDelayPage(_driver, _wait);
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void LoadDelayPageTest00_AllTextsAreVisible()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Load Delays')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Server response may often')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Navigate to Home page')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then play the test. It')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Load Delay page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Load Delay page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Load Delay page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Load Delay page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Load Delay page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Load Delay page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void LoadDelayPageTest01_OpenThePageAndClickTheButtonWith5SecondWait()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _loadDelayPage.ButtonClicker();
    }
    
    
    [Test]
    public void LoadDelayPageTest02_OpenThePageAndClickTheButtonWith1SecondWait()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        bool isElementVisible = _loadDelayPage.TryFindElement(By.ClassName("btn-primary"), 1000);
        Assert.IsFalse(isElementVisible, "The Load Delay Page loading time is bigger than 1 sec, but smaller than 5 sec.");
    
    }
    
    [Test]
    public void LoadDelayPageTest03_NavbarTest1_UITAPLogoTest()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void LoadDelayPageTest04_NavbarTest2_HomeButtonTest()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void LoadDelayPageTest05_NavbarTest3_ResourcesButtonTest()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void LoadDelayPageTest06_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void LoadDelayPageTest07_FooterTest1_GithubLink()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void LoadDelayPageTest08_FooterTest2_RapiseLink()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void LoadDelayPageTest09_FooterTest3_InflectraCorporationLink()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void LoadDelayPageTest10_FooterTest4_ApacheLicenseLink()
    {
        _mainPage.LoadMainPage();
        _mainPage.OpenLoadDelayPage();
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}