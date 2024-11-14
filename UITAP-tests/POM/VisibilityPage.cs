using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class VisibilityPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;

    private IWebElement HideButton => _driver.FindElement(By.Id("hideButton"));
    private IWebElement RemovedButton => _driver.FindElement(By.Id("removedButton"));
    private IWebElement ZeroWidthButton => _driver.FindElement(By.Id("zeroWidthButton"));
    private IWebElement OverlappedButton => _driver.FindElement(By.Id("overlappedButton"));
    private IWebElement Opacity0Button => _driver.FindElement(By.Id("transparentButton"));
    private IWebElement VisibilityHiddenButton => _driver.FindElement(By.Id("invisibleButton"));
    private IWebElement DisplayNoneButton => _driver.FindElement(By.Id("notdisplayedButton"));
    private IWebElement OffscreenButton => _driver.FindElement(By.Id("offscreenButton"));
    
    public VisibilityPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void HideButtonClicker()
    {
        HideButton.Click();
    }

    public bool IsVisible(string buttonName)
    {
        switch (buttonName)
        {
            case "RemovedButton":
                return !_driver.FindElements(By.Id("removedButton")).Any();
            case "ZeroWidthButton":
               return ZeroWidthButton.Size.Width == 0 || ZeroWidthButton.Size.Height == 0;
            case "OverlappedButton":
                var hidingLayer = _driver.FindElement(By.Id("hidingLayer"));
                return hidingLayer.Displayed && hidingLayer.Location == OverlappedButton.Location;
            case "Opacity0Button":
                return Opacity0Button.GetCssValue("opacity") == "0";
            case "VisibilityHiddenButton":
                return VisibilityHiddenButton.GetCssValue("visibility") == "hidden";
            case "DisplayNoneButton":
                return !DisplayNoneButton.Displayed;
            case "OffscreenButton":
                return OffscreenButton.Location.Y < 0 || OffscreenButton.Location.X < 0 ||OffscreenButton.Location.Y > _driver.Manage().Window.Size.Height ||
                       OffscreenButton.Location.X > _driver.Manage().Window.Size.Width;
        }

        return true;
    }



}