using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class AnimatedButtonPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private AnimatedButtonPage _animatedButtonPage;

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
        _animatedButtonPage = new AnimatedButtonPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenAnimatedButtonPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void AnimatedButtonTest0_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Animated Button')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Before clicking a button we')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(), 'Record `Start Animation` button click.')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your test to make sure')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Animated Button page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Animated Button page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Animated Button page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Animated Button page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Animated Button page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Animated Button page is not loaded properly (Playground is not visible)");
        Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "---", "Animated Button page is not loaded properly (OpStatus Text is not visible)");
    }
    
    [Test]
    public void AnimatedButtonPageTest1_ClickStartAnimationButtonWithoutMovingTargetButtonClick()
    {
         _animatedButtonPage.StartAnimationButtonClicker();
         var movingButton = _wait.Until(driver => driver.FindElement(By.CssSelector(".btn.btn-primary.spin")));
         Assert.AreNotEqual(_animatedButtonPage.GetOpStatusText(), "---", "OpStatus Text is not changed after Start Animation button click!");
         Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Animating the button...", "OpStatus Text is not changed after Star Animation button click!");
         Assert.IsTrue(movingButton.Displayed, "The Moving Target button is not moving after Start Animation button click.");
         Thread.Sleep(5000);
         Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Animation done", "OpStatus Text is not changed after animation!");
    }
    
    [Test]
    public void AnimatedButtonPageTest2_ClickMovingTargetButtonWithoutStartAnimationButtonClick()
    {
        _animatedButtonPage.MovingTargetButtonClickerNotInAction();
        Assert.AreNotEqual(_animatedButtonPage.GetOpStatusText(), "---", "OpStatus Text is not changed after Moving Target button click!");
        Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Moving Target clicked. It's class name is 'btn btn-primary'", "OpStatus Text is not changed after Moving Target button click!");
    }
    
    [Test]
    public void AnimatedButtonPageTest3_ClickStartAnimationButtonAndThenMovingTargetButtonClick()
    {
        _animatedButtonPage.StartAnimationButtonClicker();
        var movingButton = _wait.Until(driver => driver.FindElement(By.CssSelector(".btn.btn-primary.spin")));
        Assert.AreNotEqual(_animatedButtonPage.GetOpStatusText(), "---", "OpStatus Text is not changed after Start Animation button click!");
        Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Animating the button...", "OpStatus Text is not changed after Star Animation button click!");
        Assert.IsTrue(movingButton.Displayed, "The Moving Target button is not moving after Start Animation button click.");
        _animatedButtonPage.MovingTargetButtonClickerInAction();
        Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Moving Target clicked. It's class name is 'btn btn-primary spin'", "OpStatus Text is not changed after Moving Target button click!");
        Thread.Sleep(5000);
        Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Animation done", "OpStatus Text is not changed after animation!");
    }
    
    [Test]
    public void AnimatedButtonPageTest4_ClickMovingTargetButtonAndThenStartAnimationButtonClick()
    {
        _animatedButtonPage.MovingTargetButtonClickerNotInAction();
        Assert.AreNotEqual(_animatedButtonPage.GetOpStatusText(), "---", "OpStatus Text is not changed after Moving Target button click!");
        Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Moving Target clicked. It's class name is 'btn btn-primary'", "OpStatus Text is not changed after Moving Target button click!");
        _animatedButtonPage.StartAnimationButtonClicker();
        var movingButton = _wait.Until(driver => driver.FindElement(By.CssSelector(".btn.btn-primary.spin")));
        Assert.AreNotEqual(_animatedButtonPage.GetOpStatusText(), "---", "OpStatus Text is not changed after Start Animation button click!");
        Assert.AreEqual(_animatedButtonPage.GetOpStatusText(), "Animating the button...", "OpStatus Text is not changed after Star Animation button click!");
        Assert.IsTrue(movingButton.Displayed, "The Moving Target button is not moving after Start Animation button click.");
    }
    
    [Test]
    public void AnimatedButtonPageTest5_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void AnimatedButtonPageTest6_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void AnimatedButtonPageTest7_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void AnimatedButtonPageTest8_NavbarTest3_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void AnimatedButtonPageTest9_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void AnimatedButtonPageTest10_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void AnimatedButtonPageTest11_FooterTest2_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void AnimatedButtonPageTest12_FooterTest3_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}