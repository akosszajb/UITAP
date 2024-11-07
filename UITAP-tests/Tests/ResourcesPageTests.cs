using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ResourcesPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private ResourcesPage _resourcesPage;

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
        _resourcesPage = new ResourcesPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _navbar.ResourcesButtonClick();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void ResourcesPageTest01_W3SchoolsLink()
    {
        _resourcesPage.OpenW3SchoolsLink();
        var logo = _wait.Until(driver => driver.FindElement(By.Id("w3-logo")));
        Assert.IsTrue(logo.Displayed, "W3schools logo is not displayed (W3schools page is not loaded).");
        
    }
    
    [Test]
    public void ResourcesPageTest02_MDNLink()
    {
        _resourcesPage.OpenMDNLink();
        var logo = _wait.Until(driver => driver.FindElement(By.Id("mdn-docs-logo")));
        Assert.IsTrue(logo.Displayed, "MDN logo is not displayed (MDN page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest03_LearnRegexLink()
    {
        _resourcesPage.OpenLearnRegexLink();
        var learnRegexTitle =
            _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/ziishaned/learn-regex']")));
        Assert.IsTrue(learnRegexTitle.Displayed, "Learn Regex Repository title is not displayed (Learn Regex Repository is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest04_DevhintLink()
    {
        _resourcesPage.OpenDevhintsLink();
        var devHintsTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h1[contains(text(), 'Rico')]")));
        Assert.IsTrue(devHintsTitle.Displayed, "Devhints title is not displayed (Devhints.io page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest05_W3CLink()
    {
        _resourcesPage.OpenW3CLink();
        var W3CTitle = _wait.Until(driver => driver.FindElement(By.Id("main")));
        Assert.IsTrue(W3CTitle.Displayed, "W3C title is not displayed (W3C.org page is not loaded).");
        
    }
    
    [Test]
    public void ResourcesPageTest06_TestPyramidLink()
    {
        _resourcesPage.OpenTestPyramidLink();
        var martinFlower = _wait.Until(driver => driver.FindElement(By.Id("banner")));
        Assert.IsTrue(martinFlower.Displayed, "Martin Flower title is not displayed (Test pyramid page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest07_FlankyTestsLink()
    {
        _resourcesPage.OpenFlankyTestsLink();
        var googleTestingBlogTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[@class='title']/a[@href='https://testing.googleblog.com/2017/04/where-do-our-flaky-tests-come-from.html']")));
        Assert.IsTrue(googleTestingBlogTitle.Displayed, "Where do our flaky tests come from? title is not displayed (Flanky tests page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest08_MinistryOfTestingLink()
    {
        _resourcesPage.OpenMinistryOfTestingLink();
        var welcomeTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h1[contains(text(), 'Welcome to the Ministry of Testing')]")));
        Assert.IsTrue(welcomeTitle.Displayed, "Welcome to the Ministry of Testing title is not displayed (Ministry of Testing page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest09_UTestLink()
    {
        _resourcesPage.OpenuTestLink();
        var uTestNavbar = _wait.Until(driver => driver.FindElement(By.ClassName("navbar-default")));
        Assert.IsTrue(uTestNavbar.Displayed, "uTest navbar is not displayed (uTest page is not loaded).");
        
    }
    
    [Test]
    public void ResourcesPageTest10_SoftwareTestingHelpLink()
    {
        _resourcesPage.OpenSTHLink();
       
        // var consentButton = _wait.Until(driver => driver.FindElement(By.XPath("//button[@class='fc-button fc-cta-consent fc-primary-button' and @role='button' and contains(., 'Consent')]")));
        // consentButton.Click();
        var title = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.softwaretestinghelp.com/']")));
        Assert.IsTrue(title.Displayed, "Title is not displayed (Software Testing Help page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest11_DZoneLink()
    {
        _resourcesPage.OpenDZoneLink();
        var DZoneHeader = _wait.Until(driver => driver.FindElement(By.Id("ftl-header")));
        Assert.IsTrue(DZoneHeader.Displayed, "DZone header is not displayed (DZone page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest12_StackOverflowLink()
    {
        _resourcesPage.OpenStackOverflow();
        var stackOverFlowLogo = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://stackoverflow.com']")));
        Assert.IsTrue(stackOverFlowLogo.Displayed, "Stackoverflow logo is not displayed (Stackoverflow page is not loaded).");
    }
    
    [Test]
    public void ResourcesPageTest13_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ResourcesPageTest14_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void ResourcesPageTest15_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void ResourcesPageTest16_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void ResourcesPageTest17_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void ResourcesPageTest18_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void ResourcesPageTest19_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void ResourcesPageTest20_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}