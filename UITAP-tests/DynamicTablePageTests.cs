using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class DynamicTablePageTests
{
     private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private DynamicTablePage _dynamicTablePage;
    
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
        _dynamicTablePage = new DynamicTablePage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenDynamicTablePage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void DynamicTablePageTest0_AllTextsAreVisible()
    {
        // table dipalyed kell még ide
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Dynamic Table')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Below you see a table where columns')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'For Chrome process get')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Compare it with')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
        var table = _wait.Until(driver => driver.FindElement(By.XPath("/html/body/section/div/div")));
    
        Assert.IsTrue(title.Displayed, "DynamicTable page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "DynamicTable page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "DynamicTable page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "DynamicTable page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "DynamicTable page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "DynamicTable page is not loaded properly (Playground is not visible)");
        Assert.IsTrue(table.Displayed, "DynamicTable page is not loaded properly (Table is not visible)");
    }
    
    [Test]
    public void DynamicTablePageTest1_CheckChromeCPUResultValueWithTableChromeCPUValue()
    {
        string chromeResult = _wait.Until(driver => driver.FindElement(By.ClassName("bg-warning"))).Text;
        var headers = _wait.Until(d => d.FindElements(By.XPath("//div[@role='rowgroup']/div[@role='row'][1]/span")));
        int cpuIndex = -1;

        for (int i = 0; i < headers.Count; i++)
        {
            if (headers[i].Text.Trim() == "CPU")
            {
                cpuIndex = i + 1;
                break;
            }
        }
        Assert.IsTrue(cpuIndex != -1, "Nem található a 'CPU' oszlop a táblázatban.");
        var chromeRow = _wait.Until(d => d.FindElement(By.XPath("//div[@role='rowgroup']/div[@role='row'][span[text()='Chrome']]")));
        var cpuCell = chromeRow.FindElement(By.XPath($".//span[{cpuIndex}]"));
        
        string cell = "Chrome CPU: " + cpuCell.Text;
        Console.WriteLine($"Chrome Result: {chromeResult}");
        Console.WriteLine($"Table Cell Value: {cell}");
    
        Assert.IsTrue(chromeResult == cell, "The yellow Chrome result and the result in the table are different.");

    }
    
    [Test]
    public void DynamicTablePageTest2_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void DynamicTablePageTest3_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void DynamicTablePageTest4_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void DynamicTablePageTest5_NavbarTest3_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void DynamicTablePageTest6_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void DynamicTablePageTest7_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void DynamicTablePageTest8_FooterTest2_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void DynamicTablePageTest9_FooterTest3_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}