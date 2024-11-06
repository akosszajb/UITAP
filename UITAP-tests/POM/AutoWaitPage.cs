
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class AutoWaitPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement ElementSelector => _driver.FindElement(By.Id("element-type"));
    private IWebElement Apply3sButton => _driver.FindElement(By.Id("applyButton3"));
    private IWebElement Apply5sButton => _driver.FindElement(By.Id("applyButton5"));
    private IWebElement Apply10sButton => _driver.FindElement(By.Id("applyButton10"));
    private IWebElement CheckboxVisible => _driver.FindElement(By.Id("visible"));
    private IWebElement CheckboxEnabled => _driver.FindElement(By.Id("enabled"));
    private IWebElement CheckboxEditable => _driver.FindElement(By.Id("editable"));
    private IWebElement CheckboxOnTop => _driver.FindElement(By.Id("ontop"));
    private IWebElement CheckboxNonZeroSize => _driver.FindElement(By.Id("nonzero"));
    private IWebElement Target => _driver.FindElement(By.Id("target"));
    private IWebElement Overlay => _driver.FindElement(By.Id("overlay"));
    
    private IWebElement OpStatusInfo => _driver.FindElement(By.Id("opstatus"));
   
    public AutoWaitPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void Apply3sButtonClicker()
    {
        Apply3sButton.Click();
    }
    
    public void Apply5sButtonClicker()
    {
        Apply5sButton.Click();
    }
    
    public void Apply10sButtonClicker()
    {
        Apply10sButton.Click();
    }

    public bool ButtonsAreDisplayed()
    {
        return Apply3sButton.Displayed && Apply5sButton.Displayed && Apply10sButton.Displayed;
    }

    public string GetOpStatusText()
    {
        return OpStatusInfo.Text;
    }

    public void SelectTargetElement(string elementType)
    {
        SelectElement dropDown = new SelectElement(ElementSelector);
        dropDown.SelectByValue(elementType.ToLower());
    }
    
    public void VisibleSettingPicker()
    {
        CheckboxVisible.Click();
    }
    
    public void EnabledSettingPicker()
    {
        CheckboxEnabled.Click();
    }
    
    public void EditableSettingPicker()
    {
            CheckboxEditable.Click();
    }
    
    public void OnTopSettingPicker()
    {
        CheckboxOnTop.Click();
    }
    
    public void NonZeroSizeSettingPicker()
    {
        CheckboxNonZeroSize.Click();
        
    }

    public void ClearSettingCheckboxes()
    {
        if (CheckboxVisible.Selected)
        {
            CheckboxVisible.Click();
        }
        
        if (CheckboxEnabled.Selected)
        {
            CheckboxEnabled.Click();
        }
        
        if (CheckboxEditable.Selected)
        {
            CheckboxEditable.Click();
        }
        
        if (CheckboxOnTop.Selected)
        {
            CheckboxOnTop.Click();
        }
        
        if (CheckboxNonZeroSize.Selected)
        {
            CheckboxNonZeroSize.Click();
        }
    }
    
    public bool IsVisibleCheckboxSelected()
    {
        return CheckboxVisible.Selected;
    }
    
    public bool IsEnableCheckboxSelected()
    {
        return CheckboxEnabled.Selected;
    }
    
    public bool IsEditableCheckboxSelected()
    {
        return CheckboxEditable.Selected;
    }
    
    public bool IsOnTopCheckboxSelected()
    {
        return CheckboxOnTop.Selected;
    }
    
    public bool IsNonZeroSizeCheckboxSelected()
    {
        return CheckboxNonZeroSize.Selected;
    }

    public bool IsTargetButton()
    {
        return Target.TagName == "button";
    }
    
    public bool IsTargetInput()
    {
        return Target.TagName.ToLower() == "input";
    }
    
    public bool IsTargetTextarea()
    {
        return Target.TagName.ToLower() == "textarea";
    }
    
    public bool IsTargetSelect()
    {
        return Target.TagName.ToLower() == "select";
    }
    
    public bool IsTargetLabel()
    {
        return Target.TagName.ToLower() == "label";
    }
    
    public bool IsTargetVisible()
    {
        if (Target.GetCssValue("visibility") == "visible")
        {
            return true;
        }

        if (Target.GetCssValue("visibility") != "visible" || Target.GetCssValue("visibility") == "hidden")
        {
            return false;
        }

        return false;
    }
    
    public bool IsTargetEnabled()
    {
        return Target.Enabled;
    }
    
    public bool IsTargetEditable()
    {
        string readonlyAttribute = Target.GetAttribute("readonly");
        return null == readonlyAttribute;
    }
    
    public bool IsTargetOnTop()
    {
        try
        {
            var overlay = _wait.Until(driver => driver.FindElement(By.Id("overlay")));
            if (overlay.Displayed)
            {
                return false;
            }
        }
        catch (NoSuchElementException)
        {
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return true;
        }
        return true;
    }
    
    public bool IsTargetNonZeroSize()
    {
        if (Target.Size.Width == 0 && Target.Size.Height == 0)
        {
            return false;
        }
        return true;
    }
    
    public string GetTargetButtonText()
    {
        return Target.Text;
    }
    
    public string GetTargetInputValue()
    {
        return Target.GetAttribute("value");
    }
    
    public string GetTargetTextareaValue()
    {
        return Target.GetAttribute("value");
    }
    
    public string GetTargetSelectValue()
    {
        return Target.GetAttribute("value");
    }
    
    public string GetTargetLabelText()
    {
        return Target.Text;
    }

    public void TargetButtonClicker()
    {
        Target.Click();
    }
    
    public void TargetInputFiller(string text)
    {
        Target.SendKeys(text);
    }
    
    public void TargetTextareaFiller(string text)
    {
        Target.SendKeys(text);
    }
    
    public void TargetSelectPicker(string select)
    {
        SelectElement dropDown = new SelectElement(Target);
        dropDown.SelectByValue(select);
    }
    
    public void TargetLabelClicker()
    {
        Target.Click();
    }
}