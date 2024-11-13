using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class TextInputPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private TextInputPage _textInputPage;
    
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
        _textInputPage = new TextInputPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenTextInputPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void TextInputPageTest00_AllTextsAreVisible()
    {
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Text Input')]")));
        var description1 = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Entering text with physical key')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Record setting text ')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then execute your ')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
    
        Assert.IsTrue(title.Displayed, "Text Input page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description1.Displayed, "Text Input page is not loaded properly (Description1 is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "Text Input page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "Text Input page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "Text Input page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "Text Input page is not loaded properly (Playground is not visible)");
    }
    
    [Test]
    public void TextInputPageTest01_CheckButtonNameWithoutInputBarFilling()
    {
        var button = _wait.Until(driver=>driver.FindElement(By.ClassName("btn-primary")));
        string buttonText = button.Text;
        _textInputPage.ButtonClicker();
        string buttonTextAfterClicking = button.Text;
        Assert.IsTrue(buttonText == buttonTextAfterClicking, "The text of the button changed without write the input for new button name.");
    }
    
    [Test]
    public void TextInputPageTest02_CheckNewButtonNameAfterFillingInputBarWithText_English()
    {
        var button = _wait.Until(driver=>driver.FindElement(By.ClassName("btn-primary")));
        string buttonText = button.Text;
        string english = "example";
        _textInputPage.InputbarFiller(english);
        _textInputPage.ButtonClicker();
        string buttonTextAfterClicking = button.Text;
        Assert.IsTrue(buttonText != buttonTextAfterClicking, "The text of the button not changed after the fill the input and clicked on the button");
        Assert.IsTrue(buttonTextAfterClicking == english, "The text of the button not changed after the fill the input and clicked on the button (english).");
    }
    
    [Test]
    public void TextInputPageTest03_CheckNewButtonNameAfterFillingInputBarWithText_PunctuationMarks()
    {
        var button = _wait.Until(driver=>driver.FindElement(By.ClassName("btn-primary")));
        string buttonText = button.Text;
        string puncs = ".,!;:()][-_{}?";
        _textInputPage.InputbarFiller(puncs);
        _textInputPage.ButtonClicker();
        string buttonTextAfterClicking = button.Text;
        Assert.IsTrue(buttonText != buttonTextAfterClicking, "The text of the button not changed after the fill the input and clicked on the button");
        Assert.IsTrue(buttonTextAfterClicking == puncs, "The text of the button not changed after the fill the input and clicked on the button (puncs).");
    }
    
    [Test]
    public void TextInputPageTest04_CheckNewButtonNameAfterFillingInputBarWithText_Chinese()
    {
        var button = _wait.Until(driver=>driver.FindElement(By.ClassName("btn-primary")));
        string buttonText = button.Text;
        string chinese = "我們來試試吧";
        _textInputPage.InputbarFiller(chinese);
        _textInputPage.ButtonClicker();
        string buttonTextAfterClicking = button.Text;
        Assert.IsTrue(buttonText != buttonTextAfterClicking, "The text of the button not changed after the fill the input and clicked on the button");
        Assert.IsTrue(buttonTextAfterClicking == chinese, "The text of the button not changed after the fill the input and clicked on the button (chinese).");
    }
    
    [Test]
    public void TextInputPageTest05_CheckNewButtonNameAfterFillingInputBarWithText_Arabic()
    {
        var button = _wait.Until(driver=>driver.FindElement(By.ClassName("btn-primary")));
        string buttonText = button.Text;
        string arabic = "我們來試試吧";
        _textInputPage.InputbarFiller(arabic);
        _textInputPage.ButtonClicker();
        string buttonTextAfterClicking = button.Text;
        Assert.IsTrue(buttonText != buttonTextAfterClicking, "The text of the button not changed after the fill the input and clicked on the button");
        Assert.IsTrue(buttonTextAfterClicking == arabic, "The text of the button not changed after the fill the input and clicked on the button (arabic).");
    }
    
    [Test]
    public void TextInputPageTest06_CheckNewButtonNameAfterFillingInputBarWithNumbers()
    {
        var button = _wait.Until(driver=>driver.FindElement(By.ClassName("btn-primary")));
        string buttonText = button.Text;
        int number = 1111;
        _textInputPage.InputbarFillerWithNumbers(number);
        _textInputPage.ButtonClicker();
        string buttonTextAfterClicking = button.Text;
        Assert.IsTrue(buttonText != buttonTextAfterClicking, "The text of the button not changed after the fill the input and clicked on the button");
        Assert.IsTrue(buttonTextAfterClicking == number.ToString(), "The text of the button not changed after the fill the input and clicked on the button (number).");
        
    }
    
    [Test]
    public void TextInputPageTest07_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void TextInputPageTest08_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void TextInputPageTest09_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void TextInputPageTest10_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void TextInputPageTest11_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void TextInputPageTest12_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void TextInputPageTest13_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void TextInputPageTest14_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}