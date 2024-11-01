using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class Navbar
{
    private readonly IWebDriver _driver;
    
    private readonly WebDriverWait _wait;

    private IWebElement UITAPLogo => _driver.FindElement(By.CssSelector("a.nav-link[href='/']"));

    private IWebElement HomeButton => _driver.FindElement(By.CssSelector("a.nav-link"));
    
    private IWebElement ResourcesButton =>  _driver.FindElement(By.CssSelector("a.nav-link[href='/resources']"));

    private IWebElement NavbarToggler => _driver.FindElement(By.ClassName("navbar-toggler-icon"));
    
    public Navbar(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void UITAPLogoClick()
    {
        UITAPLogo.Click();
    }

    public void HomeButtonClick()
    {
        HomeButton.Click();
    }

    public void ResourcesButtonClick()
    {
        ResourcesButton.Click();
    }
    
    public void OpenNavbarWithNavbarToggler()
    {
        NavbarToggler.Click();
    }

}