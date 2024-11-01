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

    [Test]
    public void NavbarTest1_UITAPLogoTest()
    {
        _mainPage.OpenDynamicIDPage();
        _navbar.UITAPLogoClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground");
    }
    
    [Test]
    public void NavbarTest2_HomeButtonTest()
    {
        _mainPage.OpenDynamicIDPage();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground");
    }

    [Test]
    public void NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3schoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3schoolsLink.Displayed, "w3schools.com");
    }

    [Test]
    public void NavbarTest3_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        _mainPage.OpenDynamicIDPage();
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground");
    }

    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
}