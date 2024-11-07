using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ProgressBarPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private ProgressBarPage _progressBarPage;

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
        _progressBarPage = new ProgressBarPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenProgressBarPage();   
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void ProgressBarPageTest0_AllTextsAreVisible()
    { 
    var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Progress Bar')]")));
    var description = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'A web application may use a progress bar ')]")));
    var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
    var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Create a test that clicks Start')]")));
    var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
    Assert.IsTrue(title.Displayed, "Progress Bar is not loaded properly (Title is not visible)");
    Assert.IsTrue(description.Displayed, "Progress Bar is not loaded properly (Description is not visible)");
    Assert.IsTrue(scenarioList.Displayed, "Progress Bar is not loaded properly (ScenarioList is not visible)");
    Assert.IsTrue(scenarioListElement1.Displayed, "Progress Bar is not loaded properly (ScenarioListElement1 is not visible)");
    Assert.IsTrue(playground.Displayed, "Progress Bar is not loaded properly (Playground is not visible)");
    }
    
  
    [Test]
    public void ProgressBarPageTest1_ButtonBehavior()
    {
        string startingResultText = _wait.Until(driver => driver.FindElement(By.Id("result"))).Text;
        _progressBarPage.StartProgressBar();
        _progressBarPage.StopProgressBar();
        string endResultText = _wait.Until(driver => driver.FindElement(By.Id("result"))).Text;
        
        Assert.IsFalse(startingResultText == endResultText, "Result text is not changed after progress start-stop.");
      
    }
    
    [Test]
    public void ProgressBarPageTest2_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ProgressBarPageTest3_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void ProgressBarPageTest4_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void ProgressBarPageTest5_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ProgressBarPageTest6_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void ProgressBarPageTest7_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void ProgressBarPageTest8_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void ProgressBarPageTest9_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}