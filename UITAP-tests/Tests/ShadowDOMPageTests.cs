using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TextCopy;

namespace UITAP_tests;

public class ShadowDOMPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private ShadowDOMPage _shadowDOMPage;
    
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
        _shadowDOMPage = new ShadowDOMPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenShadowDOMPage();
        Thread.Sleep(5000);
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void ShadowDOMPageTest00_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Shadow DOM')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'This is a page with a Shadow DOM')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Create a test that clicks on')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Add an assertion step to your test to compare')]")));
        var scenarioListElement3 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute the test to make sure')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Shadow DOM page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Shadow DOM page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Shadow DOM page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Shadow DOM page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Shadow DOM page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(scenarioListElement3.Displayed, "Shadow DOM page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Shadow DOM page is not loaded properly (Playground is not visible)");
    }
    
   
    [Test]
    public void ShadowDOMPageTest01_GenerateGuid()
    {
        _shadowDOMPage.GenerateGuid();
        Assert.NotNull(_shadowDOMPage.GetGeneratedGuidText(), "Guid generator button is not working!");
    }
    
    [Test]
    public void ShadowDOMPageTest02_GenerateGuidAndCopyToClipboard()
    {
        _shadowDOMPage.GenerateGuid();
        _shadowDOMPage.CopyGeneratedGuid();
        string generated = _shadowDOMPage.GetGeneratedGuidText();
        string copied = ClipboardService.GetText();
        Assert.AreEqual(generated, copied, "Error with the copy button, the clipboard text is not matching!");
    }
    
    [Test]
    public void ShadowDOMPageTest03_GenerateGuidAndCopyToClipboardThenGenerateAgain()
    {
        _shadowDOMPage.GenerateGuid();
        _shadowDOMPage.CopyGeneratedGuid();
        _shadowDOMPage.GenerateGuid();
        string generated = _shadowDOMPage.GetGeneratedGuidText();
        string copied = ClipboardService.GetText();
        Assert.AreNotEqual(generated, copied, "Error with the copy button, the new guid text is matching!");
    }
    
    [Test]
    public void ShadowDOMPageTest04_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ShadowDOMPageTest05_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void ShadowDOMPageTest06_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void ShadowDOMPageTest07_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ShadowDOMPageTest08_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void ShadowDOMPageTest09_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void ShadowDOMPageTest10_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void ShadowDOMPageTest11_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}