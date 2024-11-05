using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class AnimatedButtonPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement StartAnimationButton => _driver.FindElement(By.ClassName("btn-secondary"));
    private IWebElement MovingTargetButton => _driver.FindElement(By.ClassName("btn-primary"));
    private IWebElement MovingTargetButtonInAction => _wait.Until(driver => driver.FindElement(By.CssSelector(".btn.btn-primary.spin")));
    private IWebElement OpStatus => _driver.FindElement(By.Id("opstatus"));
   
    public AnimatedButtonPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void StartAnimationButtonClicker()
    {
        StartAnimationButton.Click();
    }
    
    public void MovingTargetButtonClickerNotInAction()
    {
        MovingTargetButton.Click();
    }
    
    public void MovingTargetButtonClickerInAction()
    {
        MovingTargetButtonInAction.Click();
    }

    public string GetOpStatusText()
    {
        return OpStatus.Text;
    }
}