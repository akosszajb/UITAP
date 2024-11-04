using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class SampleAppPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    private IWebElement LoginStatus => _driver.FindElement(By.Id("loginstatus"));
    private IWebElement UsernameInput => _driver.FindElement(By.Name("UserName"));
    private IWebElement PasswordInput => _driver.FindElement(By.Name("Password"));
    private IWebElement LogInButton => _driver.FindElement(By.XPath("//button[text()='Log In']"));
    private IWebElement LogOutButton => _driver.FindElement(By.XPath("//button[text()='Log Out']"));
    
    public SampleAppPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void LoginWithFormFill(string testDataPath, int serialNumberOfTestData)
    {
        string filePath = Path.Combine(testDataPath);
        string[] lines = File.ReadAllLines(filePath);
        string[] data = lines[serialNumberOfTestData].Split(",").ToArray();
        
        UsernameInput.Clear();
        PasswordInput.Clear();
        UsernameInput.SendKeys(data[1]);
        PasswordInput.SendKeys(data[2]);
        LogInButton.Click();
    }

    public string GetLoginStatus()
    {
        return LoginStatus.Text;
    }

    public void LogOutButtonClick()
    {
        LogOutButton.Click();
    }
    
}