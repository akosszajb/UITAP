using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class DisabledInputPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private DisabledInputPage _disabledInputPage;
    
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
        _disabledInputPage = new DisabledInputPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenDisabledInputPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void DisabledInputPageTest0_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Disabled Input')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Sometimes elements become')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Record button click.')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Make a test that enters')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Disabled Input page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Disabled Input page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Disabled Input page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Disabled Input page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Disabled Input page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Disabled Input page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void DisabledInputPageTest1_CheckInputBar()
    {
        _disabledInputPage.FillChangeMeInputBar("exampleText");
        Assert.AreEqual(_disabledInputPage.GetChangeMeInputBarValue(), "exampleText", "Change me... input bar is not working!");
    }
    
    [Test]
    public void DisabledInputPageTest2_CheckEnableEditButtonByOpstatus()
    {
      _disabledInputPage.EnableEditButtonClicker();
      Assert.AreEqual(_disabledInputPage.GetOpStatusText(), "Input Disabled...", "Enable Edit Field button is not working!");
    }
    
    [Test]
    public void DisabledInputPageTest3_CheckEnableEditButtonByInputBar()
    {
        _disabledInputPage.EnableEditButtonClicker();
        try
        {
            _disabledInputPage.FillChangeMeInputBar("exampleText");
            Assert.Fail("Expected ElementNotInteractableException, but interaction succeeded.");
        }
        catch (OpenQA.Selenium.ElementNotInteractableException)
        {
            Assert.Pass("Element is not interactable as expected.");
        }
    }
    
    [Test]
    public void DisabledInputPageTest4_CheckInputBarAfterDelay()
    {
        _disabledInputPage.EnableEditButtonClicker();
        Thread.Sleep(5000);
        _disabledInputPage.FillChangeMeInputBar("exampleText");
        Assert.AreEqual(_disabledInputPage.GetChangeMeInputBarValue(), "exampleText", "Change me... input bar is not working after delay!");
    }
    
    [Test]
    public void DisabledInputPageTest5_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void DisabledInputPageTest6_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void DisabledInputPageTest7_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void DisabledInputPageTest8_NavbarTest3_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void DisabledInputPageTest9_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void DisabledInputPageTest10_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void DisabledInputPageTest11_FooterTest2_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void DisabledInputPageTest12_FooterTest3_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}