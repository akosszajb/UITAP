using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class MainPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--disable-search-engine-choice-screen");
        options.AddArguments("--start-maximized");
        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        _mainPage = new MainPage(_driver, _wait);
        _mainPage.LoadMainPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void MainPageTest0_AllDescriptionIsVisible()
    { 
        ((IJavaScriptExecutor)_driver).ExecuteScript("document.body.style.zoom='30%'");
    var Title = _wait.Until(driver => driver.FindElement(By.Id("title")));
    var QuoteFromAristotle = _wait.Until(driver => driver.FindElement(By.Id("citation")));
    var WarningMessage = _wait.Until(driver=> driver.FindElement(By.ClassName("alert-warning")));
    var Description = _wait.Until(driver => driver.FindElement(By.XPath("//p[text()='Different automation pitfalls appearing in modern web applications are described and emulated below.']")));
    var DynamicIdDescription = _wait.Until(driver => driver.FindElement(By.XPath("//p[text()='Make sure you are not recording dynamic IDs of elements']")));
    var ClassAttributeDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Check that class attribute based XPath is well formed']")));
    var HiddenLayersDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Verify that your test does not interact with elements invisible because of z-order']")));
    var LoadDelayDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Ensure that a test is capable of waiting for a page to load']")));
    var AJAXDataDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Some elements may appear on a page after loading data with AJAX request']")));
    var ClientSideDelayDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Some elements may appear after client-side time consuming JavaScript calculations']")));
    var ClickDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Event based click')]")));
    var TextInputDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Entering text into an edit field may not have effect']")));
    var ScrollbarsDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Scrolling an element into view may be a tricky task']")));
    var DynamicTableDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Verify cell value in a dynamic table')]")));
    var VerifyTextDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Finding an element by displayed text has nuances']")));
    var ProgressBarDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Follow the progress of a lengthy process')]")));
    var VisibilityDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Check if element is visible on screen')]")));
    var SampleAppDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Demo application with dynamically generated element attributes']")));
    var MouseOverDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Placing mouse over an element may change DOM and make the element unavailable']")));
    var NonBreakingSpaceDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[text()='Non-breaking space looks like a normal one on screen. It may lead to confusion when building XPath']")));
    var OverlappedElementDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Make element visible to enter text')]")));
    var ShadowDOMDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Look inside Shadow DOM component')]")));
    var AlertsDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Accept alerts, confirmations and prompts')]")));
    var FileUploadDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Upload files')]")));
    var AnimatedButtonDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Wait for animation to stop before clicking a button')]")));
    var DisabledInputDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Wait for edit field to become enabled')]")));
    var AutoWaitDescription = _wait.Until(driver=> driver.FindElement(By.XPath("//p[contains(text(), 'Wait for an element to become interactable')]")));
    
    Assert.IsTrue(Title.Displayed, "Main Page is not loaded (Title is not visible)");
    Assert.IsTrue(QuoteFromAristotle.Displayed, "Main Page is not loaded (QuoteFromAristotle is not visible)");
    Assert.IsTrue(WarningMessage.Displayed, "Main Page is not loaded (WarningMessage is not visible)");
    Assert.IsTrue(Description.Displayed, "Main Page is not loaded (Description is not visible)");
    Assert.IsTrue(DynamicIdDescription.Displayed, "Main Page is not loaded (DynamicIdDescription is not visible)");
    Assert.IsTrue(ClassAttributeDescription.Displayed, "Main Page is not loaded (ClassAttributeDescription is not visible)");
    Assert.IsTrue(HiddenLayersDescription.Displayed, "Main Page is not loaded (HiddenLayersDescription is not visible)");
    Assert.IsTrue(LoadDelayDescription.Displayed, "Main Page is not loaded (LoadDelayDescription is not visible)");
    Assert.IsTrue(AJAXDataDescription.Displayed, "Main Page is not loaded (AJAXDataDescription is not visible)");
    Assert.IsTrue(ClientSideDelayDescription.Displayed, "Main Page is not loaded (ClientSideDelayDescription is not visible)");
    Assert.IsTrue(ClickDescription.Displayed, "Main Page is not loaded (ClickDescription is not visible)");
    Assert.IsTrue(TextInputDescription.Displayed, "Main Page is not loaded (TextInputDescription is not visible)");
    Assert.IsTrue(ScrollbarsDescription.Displayed, "Main Page is not loaded (ScrollbarsDescription is not visible)");
    Assert.IsTrue(DynamicTableDescription.Displayed, "Main Page is not loaded (DynamicTableDescription is not visible)");
    Assert.IsTrue(VerifyTextDescription.Displayed, "Main Page is not loaded (VerifyTextDescription is not visible)");
    Assert.IsTrue(ProgressBarDescription.Displayed, "Main Page is not loaded (ProgressBarDescription is not visible)");
    Assert.IsTrue(VisibilityDescription.Displayed, "Main Page is not loaded (VisibilityDescription is not visible)");
    Assert.IsTrue(SampleAppDescription.Displayed, "Main Page is not loaded (SampleAppDescription is not visible)");
    Assert.IsTrue(MouseOverDescription.Displayed, "Main Page is not loaded MouseOverDescription is not visible)");
    Assert.IsTrue(NonBreakingSpaceDescription.Displayed, "Main Page is not loaded (NonBreakingSpaceDescription is not visible)");
    Assert.IsTrue(OverlappedElementDescription.Displayed, "Main Page is not loaded (OverlappedElementDescription is not visible)");
    Assert.IsTrue(ShadowDOMDescription.Displayed, "Main Page is not loaded (ShadowDOMDescription is not visible)");
    Assert.IsTrue(AlertsDescription.Displayed, "Main Page is not loaded (AlertsDescription is not visible)");
    Assert.IsTrue(FileUploadDescription.Displayed, "Main Page is not loaded (FileUploadDescription is not visible)");
    Assert.IsTrue(AnimatedButtonDescription.Displayed, "Main Page is not loaded (AnimatedButtonDescription is not visible)");
    Assert.IsTrue(DisabledInputDescription.Displayed, "Main Page is not loaded (DisabledInputDescription is not visible)");
    Assert.IsTrue(AutoWaitDescription.Displayed, "Main Page is not loaded (AutoWaitDescription - title is not visible)");
    }

    [Test]
    public void MainPageTest1_RubiksCubePNGLink()
    {
        _mainPage.OpenRubiksCubePNGPage();
        var pngimgPageTitle = _wait.Until(driver => driver.FindElement(By.ClassName("logo")));
        Assert.IsTrue(pngimgPageTitle.Displayed, "pngimg page is not loaded (pngimg.com - title is not visible)");
    }
    
    [Test]
    public void MainPageTest2_RubiksCubeLicenseLink()
    {
        _mainPage.OpenRubiksCubeLicensePage();
        Thread.Sleep(3000);
        var creativeCommonsLogo = _wait.Until(driver => driver.FindElement(By.ClassName("identity-logo")));
        Assert.IsTrue(creativeCommonsLogo.Displayed, "Creative Commons Page is not loaded (Creative Commons Logo is not visible)");
    }
    
    [Test]
    public void MainPageTest3_DynamicIdLink()
    {
        _mainPage.OpenDynamicIdPage();
        var dynamicidTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Dynamic ID')]")));
        Assert.IsTrue(dynamicidTitle.Displayed, "Dynamic ID page is not loaded (Dynamic ID - title is not visible)");
    }
    
    [Test]
    public void MainPageTest4_ClassAttributeLink()
    {
        _mainPage.OpenClassAttributePage();
        var classAttributeTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Class Attribute')]")));
        Assert.IsTrue(classAttributeTitle.Displayed, "Class Attribute page is not loaded (Class Attribute - title is not visible)");
    }
    
    [Test]
    public void MainPageTest5_HiddenLayersLink()
    {
        _mainPage.OpenHiddenLayersPage();
        var hiddenLayersTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Hidden Layers')]")));
        Assert.IsTrue(hiddenLayersTitle.Displayed, "Hidden Layers page is not loaded (Hidden Layers - title is not visible)");
    }
    
    [Test]
    public void MainPageTest6_LoadDelayLink()
    {
        _mainPage.OpenLoadDelayPage();
        var loadDelaysTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Load Delays')]")));
        Assert.IsTrue(loadDelaysTitle.Displayed, "Load Delays page is not loaded (Load Delays - title is not visible)");
    }
    
    [Test]
    public void MainPageTest7_AJAXDataLink()
    {
        _mainPage.OpenAJAXDataPage();
        var AJAXDataTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'AJAX Data')]")));
        Assert.IsTrue(AJAXDataTitle.Displayed, "AJAX Data page is not loaded (AJAX Data - title is not visible)");
    }
    
    [Test]
    public void MainPageTest8_ClientSideDelayLink()
    {
        _mainPage.OpenClientSideDelayPage();
        var clientSideDelayTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Client Side Delay')]")));
        Assert.IsTrue(clientSideDelayTitle.Displayed, "Client Side Delay page is not loaded (Client Side Delay - title is not visible)");
    }
    
    [Test]
    public void MainPageTest9_ClickLink()
    {
        _mainPage.OpenClickPage();
        var clickTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Click')]")));
        Assert.IsTrue(clickTitle.Displayed, "Click page is not loaded (Click - title is not visible)");
    }
    
    [Test]
    public void MainPageTest10_TextInputLink()
    {
        _mainPage.OpenTextInputPage();
        var textInputTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Text Input')]")));
        Assert.IsTrue(textInputTitle.Displayed, "Text Input page is not loaded (Text Input - title is not visible)");
    }
    
    [Test]
    public void MainPageTest11_ScrollbarsLink()
    {
        _mainPage.OpenScrollbarsPage();
        var scrollbarsTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Scrollbars')]")));
        Assert.IsTrue(scrollbarsTitle.Displayed, "Scrollbars page is not loaded (Scrollbars - title is not visible)");
    }
    
    [Test]
    public void MainPageTest12_DynamicTableLink()
    {
        _mainPage.OpenDynamicTablePage();
        var dynamicTableTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Dynamic Table')]")));
        Assert.IsTrue(dynamicTableTitle.Displayed, "Dynamic Table page is not loaded (Dynamic Table - title is not visible)");
    }
    
    [Test]
    public void MainPageTest13_VerifyTextLink()
    {
        _mainPage.OpenVerifyTextPage();
        var verifyTextTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Verify Text')]")));
        Assert.IsTrue(verifyTextTitle.Displayed, "Verify Text page is not loaded (Verify Text - title is not visible)");
    }
    
    [Test]
    public void MainPageTest14_ProgressBarLink()
    {
        _mainPage.OpenProgressBarPage();
        var progressBarTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Progress Bar')]")));
        Assert.IsTrue(progressBarTitle.Displayed, "Progress Bar page is not loaded (Progress Bar - title is not visible)");
    }
    
    [Test]
    public void MainPageTest15_VisibilityLink()
    {
        _mainPage.OpenVisibilityPage();
        var visibilityTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Visibility')]")));
        Assert.IsTrue(visibilityTitle.Displayed, "Visibility page is not loaded (Visibility - title is not visible)");
    }
    
    [Test]
    public void MainPageTest16_SampleAppLink()
    {
        _mainPage.OpenSampleAppPage();
        var sampleAppTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Sample App')]")));
        Assert.IsTrue(sampleAppTitle.Displayed, "Sample App page is not loaded (Sample App - title is not visible)");
    }
    
    [Test]
    public void MainPageTest17_MouseOverLink()
    {
        _mainPage.OpenMouseOverPage();
        var mouseOverTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Mouse Over')]")));
        Assert.IsTrue(mouseOverTitle.Displayed, "Mouse Over page is not loaded (Mouse Over - title is not visible)");
    }
    
    [Test]
    public void MainPageTest18_NonBreakingSpaceLink()
    {
         _mainPage.OpenNonBreakingSpacePage();    
         var nbsTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Non-Breaking Space')]")));
         Assert.IsTrue(nbsTitle.Displayed, "Non-Breaking Space page is not loaded (Non-Breaking Space - title is not visible)");
    }
    
    [Test]
    public void MainPageTest19_OverlappedElementLink()
    {
        _mainPage.OpenOverlappedElementPage();
        var overlappedElementTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Overlapped Element')]")));
        Assert.IsTrue(overlappedElementTitle.Displayed, "Overlapped Element page is not loaded (Overlapped Element - title is not visible)");
    }
    
    [Test]
    public void MainPageTest20_ShadowDOMLink()
    {
       _mainPage.OpenShadowDOMPage(); 
       var shadowDOMTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Shadow DOM')]")));
       Assert.IsTrue(shadowDOMTitle.Displayed, "Shadow DOM page is not loaded (Shadow DOM - title is not visible)");
    }
    
    [Test]
    public void MainPageTest21_AlertsLink()
    {
        _mainPage.OpenAlertsPage();
        var alertsTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Alerts')]")));
        Assert.IsTrue(alertsTitle.Displayed, "Alerts page is not loaded (Alerts - title is not visible)");
    }
    
    [Test]
    public void MainPageTest22_FileUploadLink()
    {
        _mainPage.OpenFileUploadPage();
        var fileUploadTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'File Upload')]")));
        Assert.IsTrue(fileUploadTitle.Displayed, "File Upload page is not loaded (File Upload - title is not visible)");
    }
    
    [Test]
    public void MainPageTest23_AnimatedButtonLink()
    {
        _mainPage.OpenAnimatedButtonPage();
        var animatedButtonTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Animated Button')]")));
        Assert.IsTrue(animatedButtonTitle.Displayed, "Animated Button page is not loaded (Animated Button - title is not visible)");
    }
    
    [Test]
    public void MainPageTest24_DisabledInputLink()
    {
        _mainPage.OpenDisabledInputPage();
        var disabledInputTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Disabled Input')]")));
        Assert.IsTrue(disabledInputTitle.Displayed, "Disabled Input page is not loaded (Disabled Input - title is not visible)");
    }
    
    [Test]
    public void MainPageTest25_AutoWaitLink()
    {
        _mainPage.OpenAutoWaitPage();
        var autowaitTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Auto Wait')]")));
        Assert.IsTrue(autowaitTitle.Displayed, "Auto Wait page is not loaded (Auto Wait - title is not visible)");
    }
    
    
    [Test]
    public void MainPageTest26_GithubLink()
    {
        _mainPage.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void MainPageTest27_RapiseLink()
    {
        _mainPage.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void MainPageTest28_InflectraCorporationLink()
    {
        _mainPage.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void MainPageTest29_ApacheLicenseLink()
    {
        _mainPage.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
    
}