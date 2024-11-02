using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class Footer
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private IWebElement GithubLink=> _driver.FindElement(By.CssSelector("a[href='https://github.com/inflectra/ui-test-automation-playground']"));
   
    private IWebElement RapiseLink => _driver.FindElement(By.CssSelector("a[href='https://www.inflectra.com/Rapise/']"));
    private IWebElement InflectraCorporationLink => _driver.FindElement(By.CssSelector("a[href='https://www.inflectra.com/']"));
    
    private IWebElement ApacheLicenseLink => _driver.FindElement(By.CssSelector("a[href='https://www.apache.org/licenses/LICENSE-2.0']"));

    public Footer(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
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