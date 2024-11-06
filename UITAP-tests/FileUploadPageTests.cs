using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class FileUploadPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _wait;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private FileUploadPage _fileUploadPage;
    private string _testFilePath;

    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--disable-search-engine-choice-screen");
        options.AddArguments("--start-maximized");
        _driver = new ChromeDriver(options);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        _mainPage = new MainPage(_driver, _wait);
        _navbar = new Navbar(_driver, _wait);
        _footer = new Footer(_driver, _wait);
        _fileUploadPage = new FileUploadPage(_driver, _wait);
        _mainPage.LoadMainPage();
        _mainPage.OpenFileUploadPage();   
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void FileUploadPageTest00_AllTextsAreVisible()
    { 
        var title = _wait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'File Upload')]")));
        var description = _wait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Modern web applications often include file upload')]")));
        var scenarioList = _wait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Attach a file v')]")));
        var scenarioListElement2 = _wait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Attach a file using')]")));
        var playground = _wait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
        
        Assert.IsTrue(title.Displayed, "File Upload page is not loaded properly (Title is not visible)");
        Assert.IsTrue(description.Displayed, "File Upload page is not loaded properly (Description is not visible)");
        Assert.IsTrue(scenarioList.Displayed, "File Upload page is not loaded properly (ScenarioList is not visible)");
        Assert.IsTrue(scenarioListElement1.Displayed, "File Upload page is not loaded properly (ScenarioListElement1 is not visible)");
        Assert.IsTrue(scenarioListElement2.Displayed, "File Upload page is not loaded properly (ScenarioListElement2 is not visible)");
        Assert.IsTrue(playground.Displayed, "File Upload page is not loaded properly (Playground is not visible)");
        
        var iframe = _wait.Until(driver => driver.FindElement(By.CssSelector("iframe[src='/static/upload.html']")));
        _driver.SwitchTo().Frame(iframe);
        var dragAndDrop = _wait.Until(driver => driver.FindElement(By.CssSelector(".drag-drop")));
        Assert.IsTrue(dragAndDrop.Displayed, "File Upload page is not loaded properly (DragAndDrop is not visible)");
    }
    
    [TestCase("test1.txt")]
    [TestCase("test2.xlsx")]
    [TestCase("test3.docx")]
    [TestCase("test4.pdf")]
    [TestCase("test5.pptx")]
    public void FileUploadPageTest01_UploadValidFiles_SingleFile(string testFileName)
    {
        _testFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"TestData","ValidFilesToTestUpload", testFileName);
        _fileUploadPage.FileUpload(_testFilePath);
        _fileUploadPage.SwitchBack();
        Assert.AreEqual(_fileUploadPage.GetSuccessMessage(), "1 file(s) selected", "After successful upload the message is not right!");
        Assert.IsTrue(_fileUploadPage.IsUploaded(testFileName), "After successful upload the message is not right!");
    }
   
    [Test]
    public void FileUploadPageTest02_UploadValidFiles_MultipleFiles()
    {
        var firstItemPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"TestData","ValidFilesToTestUpload", "test1.txt");
        var secondItemPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"TestData","ValidFilesToTestUpload", "test2.xlsx");
        _fileUploadPage.MultipleFileUpload(firstItemPath,secondItemPath);
        _fileUploadPage.SwitchBack();
        Assert.AreEqual(_fileUploadPage.GetSuccessMessage(), "2 file(s) selected", "After successful uploads the message is not right!");
    }
    
    [TestCase("test6_20mb.pdf")]
    [TestCase("test7.jpg")]
    public void FileUploadPageTest03_UploadInvalidFiles_SingleWrongFile(string testFileName)
    {
        _testFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"TestData","InvalidFilesToUpload", testFileName);
        _fileUploadPage.FileUpload(_testFilePath);
        _fileUploadPage.SwitchBack();
        Assert.AreNotEqual(_fileUploadPage.GetSuccessMessage(), "1 file(s) selected", "This file is not supported (by label) but the upload was successful!");
        Assert.IsFalse(_fileUploadPage.IsUploaded(testFileName), "This file is not supported (by label) but the upload was successful!");
    }


    [Test]
    public void FileUploadPageTest04_UploadInvalidFiles_MultipleWrongFiles()
    {
        var firstItemPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "InvalidFilesToUpload",
            "test6_20mb.pdf");
        var secondItemPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "InvalidFilesToUpload",
            "test7.jpg");
        _fileUploadPage.MultipleFileUpload(firstItemPath, secondItemPath);
        _fileUploadPage.SwitchBack();
        Assert.AreNotEqual(_fileUploadPage.GetSuccessMessage(), "2 file(s) selected",
            "These files are not supported (by label) but the upload was successful!");
    }

    [Test]
    public void FileUploadPageTest05_OneUploadAndRemoveUploadedFile()
    {
        _testFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"TestData","ValidFilesToTestUpload", "test1.txt");
        _fileUploadPage.FileUpload(_testFilePath);
        _fileUploadPage.SwitchBack();
        _fileUploadPage.SwitchToIframe();
        _fileUploadPage.RemoveUploadedFileByFileName("test1.txt");
       
        Assert.AreEqual(_fileUploadPage.GetSuccessMessageWithoutSwitch(), "1 file(s) selected", "After successful upload the message is not right!");
        Assert.IsTrue(_fileUploadPage.IsUploaded("test1.txt"), "After successful upload the message is not right!");
    }

    [Test]
    public void FileUploadPageTest06_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void FileUploadPageTest07_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void FileUploadPageTest08_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        
        var w3SchoolsLink = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void FileUploadPageTest09_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _wait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void FileUploadBarPageTest10_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _wait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void FileUploadPageTest11_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void FileUploadPageTest12_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _wait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void FileUploadPageTest13_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _wait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}