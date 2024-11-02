using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ClassAttributePageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private ClassAttributePage _classAttributePage;

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
        _classAttributePage = new ClassAttributePage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenClassAttributePage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void ClassAttributePageTest0_AllTextsAreVisible()
    {
        var Title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Class Attribute')]")));
        var Description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Class attribute of an element')]")));
        var Description2 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'XPath selector relying')]")));
        var Description3 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Correct variant')]")));
        var ScenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var ScenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Record primary (blue)')]")));
        var ScenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your test to make sure')]")));
        var Playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(Title.Displayed, "Class Attribute page is not loaded properly (Title is not visible)");
        Assert.IsTrue(Description1.Displayed, "Class Attribute page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(Description2.Displayed, "Class Attribute page is not loaded properly (Description2 is not visible)");
        Assert.IsTrue(Description3.Displayed, "Class Attribute page is not loaded properly (Description3 is not visible)");
        Assert.IsTrue(ScenarioList.Displayed, "Class Attribute page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(ScenarioListElement1.Displayed, "Class Attribute page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(ScenarioListElement2.Displayed, "Class Attribute page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(Playground.Displayed, "Class Attribute page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void ClassAttributePageTest1_ClickYellowButton()
    {
        _classAttributePage.YellowButtonClicker();
    }
    
    [Test]
    public void ClassAttributePageTest2_ClickGreenButton()
    {
        _classAttributePage.GreenButtonClicker();
    }
    
    [Test]
    public void ClassAttributePageTest3_ClickBlueButton()
    {
        _classAttributePage.BlueButtonClicker();
        _classAttributePage.AlertmessageOKClicker();
        _driver.Navigate().Refresh();
        _classAttributePage.BlueButtonClicker();
        _classAttributePage.AlertmessageOKClicker();
    }
    
    [Test]
    public void ClassAttributePageTest4_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ClassAttributePageTest5_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void ClassAttributePageTest6_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3schoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3schoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void ClassAttributePageTest7_NavbarTest3_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ClassAttributePageTest8_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void ClassAttributePageTest9_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void ClassAttributePageTest10_FooterTest2_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void ClassAttributePageTest11_FooterTest3_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}