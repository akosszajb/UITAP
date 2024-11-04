using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class AlertsPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private AlertsPage _alertsPage;

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
        _alertsPage = new AlertsPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenAlertsPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void AlertsPageTest0_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Alerts')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Dealing with standard alerts, ')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(), 'Record clicks on ')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your test to')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Alerts page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Alerts page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Alerts page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Alerts page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Alerts page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Alerts page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void AlertsPageTest1_ClickAlertButtonWithAccept()
    {
       _alertsPage.AlertButtonClicker();
       Console.WriteLine(_alertsPage.GetAlertMsgText());
       Assert.IsTrue(_alertsPage.GetAlertMsgText().Contains("Today is a working day."), "Alert message is wrong!");
       _alertsPage.AlertMessageOKClicker();
    }
    
    [Test]
    public void AlertsPageTest2_ClickConfirmButtonWithAccept()
    {
        _alertsPage.ConfirmButtonClicker();
        Assert.IsTrue(_alertsPage.GetAlertMsgText().Contains("Today is Friday."), "Alert message is wrong!");
        _alertsPage.AlertMessageOKClicker();
        Assert.IsTrue(_alertsPage.GetAlertMsgText() == "Yes", "Alert message is wrong!");
        _alertsPage.AlertMessageOKClicker();
    }
    
    [Test]
    public void AlertsPageTest3_ClickConfirmButtonWithCancel()
    {
       _alertsPage.ConfirmButtonClicker();
       Assert.IsTrue(_alertsPage.GetAlertMsgText().Contains("Today is Friday."), "Alert message is wrong!");
       _alertsPage.AlertMessageCancelClicker();
       Assert.IsTrue(_alertsPage.GetAlertMsgText() == "No", "Alert message is wrong!");
       _alertsPage.AlertMessageOKClicker();
    }
    
    [Test]
    public void AlertsPageTest3_ClickPromptButtonWithAcceptWithoutModification()
    {
       _alertsPage.PromptButtonClicker();
       Assert.IsTrue(_alertsPage.GetAlertMsgText().Contains("Choose"), "Alert message is wrong!");
       _alertsPage.AlertMessageOKClicker();
       Assert.IsTrue(_alertsPage.GetAlertMsgText() == "User value: cats", "With default input, the alert msg is not default!");
       _alertsPage.AlertMessageOKClicker();
    }
    
    [Test]
    public void AlertsPageTest3_ClickPromptButtonWithAcceptWithModification()
    {
       _alertsPage.PromptButtonClicker();
       Assert.IsTrue(_alertsPage.GetAlertMsgText().Contains("Choose"), "Alert message is wrong!");
       _alertsPage.PromptFiller("exampleTestInput");
       _alertsPage.AlertMessageOKClicker();
       Assert.IsTrue(_alertsPage.GetAlertMsgText() == "User value: exampleTestInput", "With new input, the alert msg is not changed properly!");
       _alertsPage.AlertMessageOKClicker();
       
    }
    
    [Test]
    public void AlertsPageTest3_ClickPromptButtonWithCancelWithoutModification()
    {
        _alertsPage.PromptButtonClicker();
        Assert.IsTrue(_alertsPage.GetAlertMsgText().Contains("Choose"), "Alert message is wrong!");
        _alertsPage.AlertMessageCancelClicker();
        Assert.IsTrue(_alertsPage.GetAlertMsgText() == "User value: no answer", "After cancel, the alert msg is not right!");
        _alertsPage.AlertMessageOKClicker();
    }
    
    [Test]
    public void AlertsPageTest3_ClickPromptButtonWithCancelWithModification()
    {
        _alertsPage.PromptButtonClicker();
        Assert.IsTrue(_alertsPage.GetAlertMsgText().Contains("Choose"), "Alert message is wrong!");
        _alertsPage.PromptFiller("exampleTestInput2");
        _alertsPage.AlertMessageCancelClicker();
        _alertsPage.AlertMessageOKClicker();
    }
    
    [Test]
    public void AlertsPageTest4_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void AlertsPageTest5_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void AlertsPageTest6_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void AlertsPageTest7_NavbarTest3_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void AlertsPageTest8_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void AlertsPageTest9_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void AlertsPageTest10_FooterTest2_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void AlertsPageTest11_FooterTest3_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}