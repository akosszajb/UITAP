using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class NavbarTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private Navbar _navbar;
    private MainPage _mainPage;
    
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--disable-search-engine-choice-screen");
        options.AddArguments("--start-maximized");
        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        _navbar = new Navbar(_driver, _wait);
        _mainPage = new MainPage(_driver, _wait);
        _mainPage.LoadMainPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }

    [Test]
    public void NavbarTest1_UITAPLogoTest()
    {
        _mainPage.OpenDynamicIdPage();
        _navbar.UITAPLogoClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void NavbarTest2_HomeButtonTest()
    {
        _mainPage.OpenDynamicIdPage();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3schoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3schoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void NavbarTest3_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
}