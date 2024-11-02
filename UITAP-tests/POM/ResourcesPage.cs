using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class ResourcesPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private IWebElement W3SchoolsLink => _driver.FindElement(By.XPath("//li/a[@href='https://www.w3schools.com']"));
    private IWebElement MDNLink =>
        _driver.FindElement(By.XPath("//li/a[@href='https://developer.mozilla.org/en-US/']"));
    private IWebElement LearnRegexLink => _driver.FindElement(By.XPath("//li/a[@href='https://github.com/zeeshanu/learn-regex']"));
    private IWebElement DevhintLink => _driver.FindElement(By.XPath("//li/a[@href='https://devhints.io/']"));
    private IWebElement W3CLink => _driver.FindElement(By.XPath("//li/a[@href='https://www.w3.org/']"));
    private IWebElement TestPyramidLink => _driver.FindElement(By.XPath("//li/a[@href='https://martinfowler.com/bliki/TestPyramid.html']"));
    private IWebElement FlankyTestsLink =>
        _driver.FindElement(By.XPath("//li/a[@href='https://testing.googleblog.com/2017/04/where-do-our-flaky-tests-come-from.html']"));
        
    private IWebElement MinistryOfTestingLink =>
        _driver.FindElement(By.XPath("//li/a[@href='https://ministryoftesting.com/']"));
    private IWebElement UTestLink => _driver.FindElement(By.XPath("//li/a[@href='https://www.utest.com']"));
    private IWebElement SoftwareTestingHelpLink =>
        _driver.FindElement(By.XPath("//li/a[@href='https://www.softwaretestinghelp.com']"));
    private IWebElement DZoneLink => _driver.FindElement(By.XPath("//li/a[@href='https://dzone.com/']"));
    private IWebElement StackOverflowLink => _driver.FindElement(By.XPath("//li/a[@href='https://stackoverflow.com/']"));
    
    public ResourcesPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }
    
    public void OpenW3schoolsLink()
    {
        W3SchoolsLink.Click();
    }

    public void OpenMDNLink()
    {
        MDNLink.Click();
    }

    public void OpenLearnRegexLink()
    {
        LearnRegexLink.Click();
    }

    public void OpenDevhintsLink()
    {
        DevhintLink.Click();
    }

    public void OpenW3CLink()
    {
        W3CLink.Click();
    }

    public void OpenTestPyramidLink()
    {
        TestPyramidLink.Click();
    }

    public void OpenFlankyTestsLink()
    {
        FlankyTestsLink.Click();
    }

    public void OpenMinistryOfTestingLink()
    {
        MinistryOfTestingLink.Click();
    }

    public void OpenuTestLink()
    {
        UTestLink.Click();
    }

    public void OpenSTHLink()
    {
        SoftwareTestingHelpLink.Click();
    }

    public void OpenDZoneLink()
    {
        DZoneLink.Click();
    }

    public void OpenStackOverflow()
    {
        StackOverflowLink.Click();
    }

}