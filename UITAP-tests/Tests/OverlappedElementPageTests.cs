using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class OverlappedElementPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private OverlappedElementPage _overlappedElementPage;
    
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
        _overlappedElementPage = new OverlappedElementPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenOverlappedElementPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void OverlappedElementPageTest00_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Overlapped Element')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Entering text to a partially')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Record setting text into')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your test to make sure')]")));
    
        Assert.IsTrue(title.Displayed, "Overlapped Element page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Overlapped Element page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Overlapped Element page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Overlapped Element page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Overlapped Element page is not loaded properly (ScenarioListElement2 is not visible)");
    }
    
    [Test]
    public void OverlappedElementPageTest01_ScrollToAndFillIdForm()
    {
        _overlappedElementPage.IdFormFiller("exampleId");
        
        var idInputBar = _wait.Until(driver=> driver.FindElement(By.Id("id")));
        var scrollArea = _wait.Until(driver=>driver.FindElement(By.CssSelector("div[style*='overflow-y: scroll']")));
        var idInputBarLocation = idInputBar.Location;
        var scrollAreaLocation = scrollArea.Location;
        var scrollAreaSize = scrollArea.Size;
        
        Assert.IsTrue(idInputBarLocation.Y < scrollAreaLocation.Y + scrollAreaSize.Height, "The form is not displayed after scrolling.");
        Assert.IsTrue(_overlappedElementPage.GetIdFormText() == "exampleId", "The text in the id form is missing!");
        
    }
    
    [Test]
    public void OverlappedElementPageTest02_ScrollToAndFillNameForm()
    {
        _overlappedElementPage.NameFormFiller("exampleName");
        
        var nameInputBar = _wait.Until(driver=> driver.FindElement(By.Id("name")));
        var scrollArea = _wait.Until(driver=>driver.FindElement(By.CssSelector("div[style*='overflow-y: scroll']")));
        var nameInputBarLocation = nameInputBar.Location;
        var scrollAreaLocation = scrollArea.Location;
        var scrollAreaSize = scrollArea.Size;
        
        Assert.IsTrue(nameInputBarLocation.Y < scrollAreaLocation.Y + scrollAreaSize.Height, "The form is not displayed after scrolling.");
        Assert.IsTrue(_overlappedElementPage.GetNameFormText() == "exampleName", "The text in the id form is missing!");
    }
    
    [Test]
    public void OverlappedElementPageTest03_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void OverlappedElementPageTest04_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void OverlappedElementPageTest05_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void OverlappedElementPageTest06_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void OverlappedElementPageTest07_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void OverlappedElementPageTest08_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void OverlappedElementPageTest09_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void OverlappedElementPageTest10_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}