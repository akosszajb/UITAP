using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class FileUploadPage
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    
    private IWebElement FileInput => _driver.FindElement(By.CssSelector("input[type=file]"));
    private IWebElement SuccessMessage => _driver.FindElement(By.ClassName("success-file"));
    
    public FileUploadPage(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver;
        _wait = wait;
    }

    public void SwitchToIframe()
    {
        var iframe = _wait.Until(driver => driver.FindElement(By.CssSelector("iframe[src='/static/upload.html']")));
        _driver.SwitchTo().Frame(iframe);
    }
    
    public void SwitchBack()
    {
        _driver.SwitchTo().DefaultContent();
    }
    
    public void FileUpload(string testFilePath)
    { 
        SwitchToIframe();
        FileInput.SendKeys(Path.Combine(testFilePath));
    }
    
    public void MultipleFileUpload(string testFile1Path, string testFile2Path)
    {
        SwitchToIframe();
        FileInput.SendKeys(Path.Combine(testFile1Path) + '\n' + Path.Combine(testFile2Path));
    }
    
   public bool IsUploaded(string fileName)
    {
        var uploadedElement = _wait.Until(driver => driver.FindElement(By.XPath($"//p[contains(text(), '{fileName}')]")));
         
        return uploadedElement.Displayed;
    }

    public void RemoveUploadedFileByFileName(string fileName)
    {
        // var fileToRemove = _wait.Until(driver => 
        //     driver.FindElement(By.XPath($"//div[contains(@class, 'file-item') and .//p[text()='{fileName}']]"))
        // );
        
        var deleteButton = _wait.Until(driver =>
            driver.FindElement(By.CssSelector("#root .section .drag-drop .document-uploader.upload-box.active .file-list .file-list__container .file-item .file-actions > svg:nth-of-type(1) > path:nth-of-type(2)")));
        Actions actions = new Actions(_driver);
        actions.Click(deleteButton);
    }

    public string GetSuccessMessage()
    { 
        SwitchToIframe();
        return SuccessMessage.Text;
    }
    
    public string GetSuccessMessageWithoutSwitch()
    { 
        return SuccessMessage.Text;
    }

}