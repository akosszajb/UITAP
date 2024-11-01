using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class MainPage
{
    private readonly IWebDriver _driver;
    
    private readonly WebDriverWait _wait;
    
    // Locators
    private IWebElement RubiksCubePictureLink => _driver.FindElement(By.CssSelector("a[href='http://pngimg.com/download/46552']"));
    private IWebElement RubiksCubeLicenseLink => _driver.FindElement(By.CssSelector("a[href='https://creativecommons.org/licenses/by-nc/4.0/']"));
    private IWebElement DynamicIdLink => _driver.FindElement(By.LinkText("Dynamic ID"));
    private IWebElement ClassAttributeLink => _driver.FindElement(By.CssSelector("a[href='/classattr']"));
    private IWebElement HiddenLayersLink => _driver.FindElement(By.CssSelector("a[href='/hiddenlayers']"));
    private IWebElement LoadDelayLink => _driver.FindElement(By.CssSelector("a[href='/loaddelay']")); 
    private IWebElement AJAXDataLink => _driver.FindElement(By.CssSelector("a[href='/ajax']"));
    private IWebElement ClientSideDelayLink => _driver.FindElement(By.CssSelector("a[href='/clientdelay']"));
    private IWebElement ClickLink => _driver.FindElement(By.CssSelector("a[href='/click']"));
    private IWebElement TextInputLink => _driver.FindElement(By.CssSelector("a[href='/textinput']")) ;
    private IWebElement ScrollbarsLink => _driver.FindElement(By.CssSelector("a[href='/scrollbars']"));
    private IWebElement DynamicTableLink => _driver.FindElement(By.CssSelector("a[href='/dynamictable']"));
    private IWebElement VerifyTextLink => _driver.FindElement(By.CssSelector("a[href='/verifytext']"));
    private IWebElement ProgressBarLink => _driver.FindElement(By.CssSelector("a[href='/progressbar']"));
    private IWebElement VisibilityLink => _driver.FindElement(By.CssSelector("a[href='/visibility']"));
    private IWebElement SampleAppLink => _driver.FindElement(By.CssSelector("a[href='/sampleapp']"));
    private IWebElement MouseOverLink => _driver.FindElement(By.CssSelector("a[href='/mouseover']"));
    private IWebElement NonBreakingSpaceLink => _driver.FindElement(By.CssSelector("a[href='/nbsp']"));
    private IWebElement OverlappedElementLink => _driver.FindElement(By.CssSelector("a[href='/overlapped']"));
    private IWebElement ShadowDOMLink => _driver.FindElement(By.CssSelector("a[href='/shadowdom']"));
    private IWebElement AlertsLink => _driver.FindElement(By.CssSelector("a[href='/alerts']"));
    private IWebElement FileUploadLink => _driver.FindElement(By.CssSelector("a[href='/upload']"));
    private IWebElement AnimatedButtonLink => _driver.FindElement(By.CssSelector("a[href='/animation']"));
    private IWebElement DisabledInputLink => _driver.FindElement(By.CssSelector("a[href='/disabledinput']"));
    private IWebElement AutoWaitLink => _driver.FindElement(By.CssSelector("a[href='/autowait']"));
    private IWebElement GithubLink=> _driver.FindElement(By.CssSelector("a[href='https://github.com/inflectra/ui-test-automation-playground']"));
   
    private IWebElement RapiseLink => _driver.FindElement(By.CssSelector("a[href='https://www.inflectra.com/Rapise/']"));
    private IWebElement InflectraCorporationLink => _driver.FindElement(By.CssSelector("a[href='https://www.inflectra.com/']"));
    
    private IWebElement ApacheLicenseLink => _driver.FindElement(By.CssSelector("a[href='https://www.apache.org/licenses/LICENSE-2.0']"));
    
    //Methods
    public MainPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }
    
    public void LoadMainPage()
    {
        _driver.Navigate().GoToUrl("http://localhost:3000/");
    }
    
    public void OpenRubiksCubePNGPage()
    {
        RubiksCubePictureLink.Click();
    }
    
    public void OpenRubiksCubeLicensePage()
    {
        RubiksCubeLicenseLink.Click();
    }
    
    public void OpenDynamicIdPage()
    {
        DynamicIdLink.Click();
    }
    
    
    public void OpenClassAttributePage()
    {
        ClassAttributeLink.Click();
    }
    
    public void OpenHiddenLayersPage()
    {
        HiddenLayersLink.Click();
    }
    
    public void OpenLoadDelayPage()
    {
        LoadDelayLink.Click();
    }
    
    public void OpenAJAXDataPage()
    {
        AJAXDataLink.Click();
    }
    
    public void OpenClientSideDelayPage()
    {
        ClientSideDelayLink.Click();
    }
    
    public void OpenClickPage()
    {
        ClickLink.Click();
    }
    
    public void OpenTextInputPage()
    {
        TextInputLink.Click();
    }
    public void OpenScrollbarsPage()
    {
        ScrollbarsLink.Click();
    }
    
    public void OpenDynamicTablePage()
    {
        DynamicTableLink.Click();
    }

    public void OpenVerifyTextPage()
    {
        VerifyTextLink.Click();
    }

    public void OpenProgressBarPage()
    {
        ProgressBarLink.Click();
    }
    
    public void OpenVisibilityPage()
    {
        VisibilityLink.Click();
    }
    
    public void OpenSampleAppPage()
    {
        SampleAppLink.Click();
    }
    
    public void OpenMouseOverPage()
    {
        MouseOverLink.Click();
    }
    
    public void OpenNonBreakingSpacePage()
    {
        NonBreakingSpaceLink.Click();
    }
    
    public void OpenOverlappedElementPage()
    {
        OverlappedElementLink.Click();
    }
    
    public void OpenShadowDOMPage()
    {
        ShadowDOMLink.Click();
    }
    
    public void OpenAlertsPage()
    {
        AlertsLink.Click();
    }
    
    public void OpenFileUploadPage()
    {
        FileUploadLink.Click();
    }
    
    public void OpenAnimatedButtonPage()
    {
        AnimatedButtonLink.Click();
    }
    
    public void OpenDisabledInputPage()
    {
        DisabledInputLink.Click();
    }
    
    public void OpenAutoWaitPage()
    {
        AutoWaitLink.Click();
    }
    
    public void OpenGithubRepoByLink()
    {
        GithubLink.Click();
    }

    public void OpenRapisePage()
    {
        RapiseLink.Click();
    }

    public void OpenInflectraPage()
    {
        InflectraCorporationLink.Click();
    }

    public void OpenApacheLicense()
    {
        ApacheLicenseLink.Click();
    }
}