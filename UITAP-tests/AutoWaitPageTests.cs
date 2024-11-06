using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP_tests;

public class AutoWaitPageTests
{
    private IWebDriver _driver;
    private WebDriverWait _defaultWait;
    private WebDriverWait _wait3Sec;
    private WebDriverWait _wait5Sec;
    private WebDriverWait _wait10Sec;
    private MainPage _mainPage;
    private Navbar _navbar;
    private Footer _footer;
    private AutoWaitPage _autoWaitPageWithDefaultWait;
    private AutoWaitPage _autoWaitPageWith3SecWait;
    private AutoWaitPage _autoWaitPageWith5SecWait;
    private AutoWaitPage _autoWaitPageWith10SecWait;
    
    [SetUp]
    public void Setup()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArguments("--disable-search-engine-choice-screen");
        options.AddArguments("--start-maximized");
        _driver = new ChromeDriver(options);
        _defaultWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        _wait3Sec = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        _wait5Sec = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        _wait10Sec = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        _mainPage = new MainPage(_driver, _defaultWait);
        _navbar = new Navbar(_driver, _defaultWait);
        _footer = new Footer(_driver, _defaultWait);
        _autoWaitPageWithDefaultWait = new AutoWaitPage(_driver, _defaultWait);
        _autoWaitPageWith3SecWait = new AutoWaitPage(_driver, _wait3Sec);
        _autoWaitPageWith5SecWait = new AutoWaitPage(_driver, _wait5Sec);
        _autoWaitPageWith10SecWait = new AutoWaitPage(_driver, _wait10Sec);
        _mainPage.LoadMainPage();
        _mainPage.OpenAutoWaitPage();
    }
    
    [TearDown]
    public void Teardown()
    {
        _driver.Quit();
    }
    
    [Test]
    public void AutoWaitPageTest00_AllTextsAreVisible()
    {
        var title = _defaultWait.Until(driver => driver.FindElement(By.XPath("//h3[contains(text(),'Auto Wait')]")));
        var description1 = _defaultWait.Until(driver => driver.FindElement(By.XPath("//p[contains(text(),'Before clicking an element or entering text')]")));
        var scenarioList = _defaultWait.Until(driver=> driver.FindElement(By.XPath("//h4[contains(text(),'Scenario')]")));
        var scenarioListElement1 = _defaultWait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Choose an element')]")));
        var scenarioListElement2 = _defaultWait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Check the checkboxes')]")));
        var scenarioListElement3 = _defaultWait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Then click one of the Apply')]")));
        var scenarioListElement4 = _defaultWait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Interact with the element')]")));
        var scenarioListElement5 = _defaultWait.Until(driver => driver.FindElement(By.XPath("//li[contains(text(),'Observe the status')]")));
        var playground = _defaultWait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Playground')]")));
        var settings = _defaultWait.Until(driver => driver.FindElement(By.XPath("//h4[contains(text(),'Settings')]")));
        
        Assert.IsTrue(title.Displayed, "Auto Wait page is not loaded properly (Title is not visible).");
        Assert.IsTrue(description1.Displayed, "Auto Wait page is not loaded properly (Description1 is not visible).");
        Assert.IsTrue(scenarioList.Displayed, "Auto Wait page is not loaded properly (ScenarioList is not visible).");
        Assert.IsTrue(scenarioListElement1.Displayed, "Auto Wait page is not loaded properly (ScenarioListElement1 is not visible).");
        Assert.IsTrue(scenarioListElement2.Displayed, "Auto Wait page is not loaded properly (ScenarioListElement2 is not visible).");
        Assert.IsTrue(scenarioListElement3.Displayed, "Auto Wait page is not loaded properly (ScenarioListElement3 is not visible).");
        Assert.IsTrue(scenarioListElement4.Displayed, "Auto Wait page is not loaded properly (ScenarioListElement4 is not visible).");
        Assert.IsTrue(scenarioListElement5.Displayed, "Auto Wait page is not loaded properly (ScenarioListElement5 is not visible).");
        Assert.IsTrue(playground.Displayed, "Auto Wait page is not loaded properly (Playground is not visible).");
        Assert.IsTrue(settings.Displayed, "Auto Wait page is not loaded properly (Settings is not visible).");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.GetOpStatusText() == "---",
            "Auto Wait page is not loaded properly (Op status is wrong.");
    }
    
    // Default page behavior tests
    [Test]
    public void AutoWaitPageTest01_CheckboxesByDefault()
    {
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsVisibleCheckboxSelected(), "Auto Wait page is not loaded properly (Visible checkbox is not selected by default)!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsEnableCheckboxSelected(), "Auto Wait page is not loaded properly (Enabled checkbox is not selected by default)!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsEditableCheckboxSelected(), "Auto Wait page is not loaded properly (Editable checkbox is not selected by default)!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsOnTopCheckboxSelected(), "Auto Wait page is not loaded properly (On Top checkbox is not selected by default)!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsNonZeroSizeCheckboxSelected(), "Auto Wait page is not loaded properly (Non Zero Size checkbox is not selected by default)!");
    }
    
    [Test]
    public void AutoWaitPageTest02_ElementTypeSelectAndTargetByDefault()
    {
        Assert.IsTrue(_autoWaitPageWithDefaultWait.GetTargetButtonText() == "Button",
            "Auto Wait page is not loaded properly (Target Button is not displayed by default)!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsVisibleCheckboxSelected(), "Auto Wait page is not loaded properly (Visible checkbox is not selected by default)!");
    }
    
    [Test]
    public void AutoWaitPageTest03_ButtonsDisplayedByDefault()
    {
        Assert.IsTrue(_autoWaitPageWithDefaultWait.ButtonsAreDisplayed(),
            "Auto Wait page is not loaded properly (Apply buttons are not displayed by default)!");
    }
    
    // Found defect
    [Test]
    public void AutoWaitPageTest04_DefaultApply3sButtonClick()
    { 
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetVisible(), "Default: After Apply3s button click, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetEnabled(), "Default: After Apply3s button click, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetEditable(), "Default: After Apply3s button click, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetOnTop(), "Default: After Apply3s button click, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetNonZeroSize(), "Default: After Apply3s button click, the Target is not 'non zero sized'!");
    }
    
    // Found defect
    [Test]
    public void AutoWaitPageTest05_DefaultApply5sButtonClick()
    { 
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetVisible(), "Default: After Apply5s button click, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetEnabled(), "Default: After Apply5s button click, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetEditable(), "Default: After Apply5s button click, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetOnTop(), "Default: After Apply5s button click, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetNonZeroSize(), "Default: After Apply5s button click, the Target is not 'non zero sized'!");
    }
    
    // Found defect
    [Test]
    public void AutoWaitPageTest06_DefaultApply10sButtonClick()
    { 
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply10s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetVisible(), "Default: After Apply10s button click, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetEnabled(), "Default: After Apply10s button click, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetEditable(), "Default: After Apply10s button click, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetOnTop(), "Default: After Apply10s button click, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWithDefaultWait.IsTargetNonZeroSize(), "Default: After Apply10s button click, the Target is not 'non zero sized'!");
    }

    [Test]
    public void AutoWaitPageTest07_RestoredMessageAfterDefaultApply3sButtonClick()
    {
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Thread.Sleep(4000);
        Assert.IsTrue(_autoWaitPageWith3SecWait.GetOpStatusText() == "Target element state restored.", "After the delay the op status message is not refreshed");
    }
    
    [Test]
    public void AutoWaitPageTest08_RestoredMessageAfterDefaultApply5sButtonClick()
    {
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Thread.Sleep(6000);
        Assert.IsTrue(_autoWaitPageWith5SecWait.GetOpStatusText() == "Target element state restored.", "After the delay the op status message is not refreshed");
    }
    
    [Test]
    public void AutoWaitPageTest09_RestoredMessageAfterDefaultApply10sButtonClick()
    {
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Thread.Sleep(11000);
        Assert.IsTrue(_autoWaitPageWith10SecWait.GetOpStatusText() == "Target element state restored.", "After the delay the op status message is not refreshed");
    }

    [Test]
    public void AutoWaitPageTest10_CheckboxUncheckTesting_Visible()
    {
        _autoWaitPageWithDefaultWait.VisibleSettingPicker();
        Assert.False(_autoWaitPageWithDefaultWait.IsVisibleCheckboxSelected(), "After unchecking the visibility checkbox, the checkbox is still selected!");
    }
    
    [Test]
    public void AutoWaitPageTest11_CheckboxUncheckTesting_Enabled()
    {
        _autoWaitPageWithDefaultWait.EnabledSettingPicker();
        Assert.False(_autoWaitPageWithDefaultWait.IsEnableCheckboxSelected(), "After unchecking the enable checkbox, the checkbox is still selected!");
    }
    
    [Test]
    public void AutoWaitPageTest12_CheckboxUncheckTesting_Editable()
    {
        _autoWaitPageWithDefaultWait.EditableSettingPicker();
        Assert.False(_autoWaitPageWithDefaultWait.IsEditableCheckboxSelected(), "After unchecking the editable checkbox, the checkbox is still selected!");
    }
    
    [Test]
    public void AutoWaitPageTest13_CheckboxUncheckTesting_OnTop()
    {
        _autoWaitPageWithDefaultWait.OnTopSettingPicker();
        Assert.False(_autoWaitPageWithDefaultWait.IsOnTopCheckboxSelected(), "After unchecking the on top checkbox, the checkbox is still selected!");
    }
    
    [Test]
    public void AutoWaitPageTest14_CheckboxUncheckTesting_NonZeroSize()
    {
        _autoWaitPageWithDefaultWait.NonZeroSizeSettingPicker();
        Assert.False(_autoWaitPageWithDefaultWait.IsNonZeroSizeCheckboxSelected(), "After unchecking the non zero size checkbox, the checkbox is still selected!");
    }
    
    // Select type, without checkbox modification, Apply3s button tests
    [Test]
    public void AutoWaitPageTest15_SelectElementTypeButton_CheckboxesUntouched_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Button");
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetButton(), "After button is selected and Apply3s button clicked, the target is not button!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetVisible(), "After button is selected and Apply3s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After button is selected and Apply3s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEditable(), "After button is selected and Apply3s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After button is selected and Apply3s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After button is selected and Apply3s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest16_SelectElementTypeInput_CheckboxesUntouched_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Input");
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetInput(), "After input is selected and Apply3s button clicked, the target is not input!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetVisible(), "After input is selected and Apply3s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After input is selected and Apply3s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEditable(), "After input is selected and Apply3s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After input is selected and Apply3s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After input is selected and Apply3s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest17_SelectElementTypeTextarea_CheckboxesUntouched_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Textarea");
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetTextarea(), "After textarea is selected and Apply3s button clicked, the target is not textarea!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetVisible(), "After textarea is selected and Apply3s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After textarea is selected and Apply3s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEditable(), "After textarea is selected and Apply3s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After textarea is selected and Apply3s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After textarea is selected and Apply3s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest18_SelectElementTypeSelect_CheckboxesUntouched_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Select");
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetSelect(), "After select is selected and Apply3s button clicked, the target is not select!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetVisible(), "DAfter select is selected and Apply3s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After select is selected and Apply3s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEditable(), "After select is selected and Apply3s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After select is selected and Apply3s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After select is selected and Apply3s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest19_SelectElementTypeLabel_CheckboxesUntouched_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Label");
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetLabel(), "After label is selected and Apply3s button clicked, the target is not label!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetVisible(), "After label is selected and Apply3s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After label is selected and Apply3s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetEditable(), "After label is selected and Apply3s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After label is selected and Apply3s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After label is selected and Apply3s button clicked, the Target is not non zero sized!");
    }
    
    // Select type, without checkbox modification, Apply5s button tests
    [Test]
    public void AutoWaitPageTest20_SelectElementTypeButton_CheckboxesUntouched_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Button");
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetButton(), "After button is selected and Apply5s button clicked, the target is not button!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetVisible(), "After button is selected and Apply5s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After button is selected and Apply5s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEditable(), "After button is selected and Apply5s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After button is selected and Apply5s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After button is selected and Apply5s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest21_SelectElementTypeInput_CheckboxesUntouched_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Input");
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetInput(), "After input is selected and Apply5s button clicked, the target is not input!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetVisible(), "After input is selected and Apply5s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After input is selected and Apply5s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEditable(), "After input is selected and Apply5s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After input is selected and Apply5s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After input is selected and Apply5s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest22_SelectElementTypeTextarea_CheckboxesUntouched_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Textarea");
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetTextarea(), "After textarea is selected and Apply5s button clicked, the target is not textarea!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetVisible(), "After textarea is selected and Apply5s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After textarea is selected and Apply5s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEditable(), "After textarea is selected and Apply5s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After textarea is selected and Apply5s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After textarea is selected and Apply5s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest23_SelectElementTypeSelect_CheckboxesUntouched_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Select");
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetSelect(), "After select is selected and Apply5s button clicked, the target is not select!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetVisible(), "DAfter select is selected and Apply5s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After select is selected and Apply5s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEditable(), "After select is selected and Apply5s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After select is selected and Apply5s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After select is selected and Apply5s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest24_SelectElementTypeLabel_CheckboxesUntouched_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Label");
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetLabel(), "After label is selected and Apply5s button clicked, the target is not label!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetVisible(), "After label is selected and Apply5s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After label is selected and Apply5s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetEditable(), "After label is selected and Apply5s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After label is selected and Apply5s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After label is selected and Apply5s button clicked, the Target is not non zero sized!");
    }
    
    // Select type, without checkbox modification, Apply10s button tests
    [Test]
    public void AutoWaitPageTest25_SelectElementTypeButton_CheckboxesUntouched_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Button");
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply10s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetButton(), "After button is selected and Apply10s button clicked, the target is not button!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetVisible(), "After button is selected and Apply10s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After button is selected and Apply10s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEditable(), "After button is selected and Apply10s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After button is selected and Apply10s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After button is selected and Apply10s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest26_SelectElementTypeInput_CheckboxesUntouched_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Input");
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply10s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetInput(), "After input is selected and Apply10s button clicked, the target is not input!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetVisible(), "After input is selected and Apply10s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After input is selected and Apply10s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEditable(), "After input is selected and Apply10s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After input is selected and Apply10s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After input is selected and Apply10s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest27_SelectElementTypeTextarea_CheckboxesUntouched_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Textarea");
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply10s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetTextarea(), "After textarea is selected and Apply10s button clicked, the target is not textarea!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetVisible(), "After textarea is selected and Apply10s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After textarea is selected and Apply10s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEditable(), "After textarea is selected and Apply10s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After textarea is selected and Apply10s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After textarea is selected and Apply10s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest28_SelectElementTypeSelect_CheckboxesUntouched_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Select");
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply10s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetSelect(), "After select is selected and Apply10s button clicked, the target is not select!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetVisible(), "DAfter select is selected and Apply10s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After select is selected and Apply10s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEditable(), "After select is selected and Apply10s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After select is selected and Apply10s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After select is selected and Apply10s button clicked, the Target is not non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest29_SelectElementTypeLabel_CheckboxesUntouched_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Label");
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply10s button click, the OpStatus is not changed!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetLabel(), "After label is selected and Apply10s button clicked, the target is not label!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetVisible(), "After label is selected and Apply10s button clicked, the Target is not visible!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After label is selected and Apply10s button clicked, the Target is not enabled!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetEditable(), "After label is selected and Apply10s button clicked, the Target is not editable!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After label is selected and Apply10s button clicked, the Target is not on top!");
        Assert.IsTrue(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After label is selected and Apply10s button clicked, the Target is not non zero sized!");
    }
    
   // Select type, all checkbox unchecked, Apply3s button tests
    [Test]
    public void AutoWaitPageTest30_SelectElementTypeButton_AllCheckboxesEmpty_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Button");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith3SecWait.IsTargetButton(), "After button is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetVisible(), "After button is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After button is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After button is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After button is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest31_SelectElementTypeInput_AllCheckboxesEmpty_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Input");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith3SecWait.IsTargetInput(), "After input is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetVisible(), "After input is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After input is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetEditable(), "After input is selected, editable checkbox is empty and Apply3s button clicked, the Target is editable!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After input is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After input is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest32_SelectElementTypeTextarea_AllCheckboxesEmpty_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Textarea");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith3SecWait.IsTargetTextarea(), "After textarea is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetVisible(), "After textarea is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After textarea is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetEditable(), "After textarea is selected, editable checkbox is empty and Apply3s button clicked, the Target is editable!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After textarea is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After textarea is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest33_SelectElementTypeSelect_AllCheckboxesEmpty_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Select");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith3SecWait.IsTargetSelect(), "After select is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetVisible(), "After select is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetEnabled(), "After select is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After select is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After select is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest34_SelectElementTypeLabel_AllCheckboxesEmpty_Then3SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Label");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply3sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith3SecWait.GetOpStatusText(), "Target element settings applied for 3 seconds.", "After Apply3s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith3SecWait.IsTargetLabel(), "After label is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetVisible(), "After label is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetOnTop(), "After label is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith3SecWait.IsTargetNonZeroSize(), "After label is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    // Select type, all checkbox unchecked, Apply5s button tests
    [Test]
    public void AutoWaitPageTest35_SelectElementTypeButton_AllCheckboxesEmpty_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Button");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith5SecWait.IsTargetButton(), "After button is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetVisible(), "After button is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After button is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After button is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After button is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest36_SelectElementTypeInput_AllCheckboxesEmpty_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Input");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith5SecWait.IsTargetInput(), "After input is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetVisible(), "After input is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After input is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetEditable(), "After input is selected, editable checkbox is empty and Apply3s button clicked, the Target is editable!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After input is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After input is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest37_SelectElementTypeTextarea_AllCheckboxesEmpty_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Textarea");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith5SecWait.IsTargetTextarea(), "After textarea is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetVisible(), "After textarea is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After textarea is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetEditable(), "After textarea is selected, editable checkbox is empty and Apply3s button clicked, the Target is editable!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After textarea is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After textarea is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest38_SelectElementTypeSelect_AllCheckboxesEmpty_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Select");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith5SecWait.IsTargetSelect(), "After select is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetVisible(), "After select is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetEnabled(), "After select is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After select is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After select is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest39_SelectElementTypeLabel_AllCheckboxesEmpty_Then5SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Label");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply5sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith5SecWait.GetOpStatusText(), "Target element settings applied for 5 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith5SecWait.IsTargetLabel(), "After label is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetVisible(), "After label is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetOnTop(), "After label is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith5SecWait.IsTargetNonZeroSize(), "After label is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    // Select type, all checkbox unchecked, Apply10s button tests
    [Test]
    public void AutoWaitPageTest40_SelectElementTypeButton_AllCheckboxesEmpty_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Button");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith10SecWait.IsTargetButton(), "After button is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetVisible(), "After button is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After button is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After button is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After button is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest41_SelectElementTypeInput_AllCheckboxesEmpty_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Input");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith10SecWait.IsTargetInput(), "After input is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetVisible(), "After input is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After input is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetEditable(), "After input is selected, editable checkbox is empty and Apply3s button clicked, the Target is editable!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After input is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After input is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest42_SelectElementTypeTextarea_AllCheckboxesEmpty_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Textarea");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith10SecWait.IsTargetTextarea(), "After textarea is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetVisible(), "After textarea is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After textarea is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetEditable(), "After textarea is selected, editable checkbox is empty and Apply3s button clicked, the Target is editable!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After textarea is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After textarea is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest43_SelectElementTypeSelect_AllCheckboxesEmpty_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Select");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith10SecWait.IsTargetSelect(), "After select is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetVisible(), "After select is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetEnabled(), "After select is selected, enabled checkbox is empty and Apply3s button clicked, the Target is enabled!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After select is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After select is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }
    
    [Test]
    public void AutoWaitPageTest44_SelectElementTypeLabel_AllCheckboxesEmpty_Then10SecApply()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Label");
        _autoWaitPageWithDefaultWait.ClearSettingCheckboxes();
        _autoWaitPageWithDefaultWait.Apply10sButtonClicker();
        Assert.AreEqual(_autoWaitPageWith10SecWait.GetOpStatusText(), "Target element settings applied for 10 seconds.", "After Apply5s button click, the OpStatus is not changed!");
        Assert.True(_autoWaitPageWith10SecWait.IsTargetLabel(), "After label is selected and Apply3s button clicked, the target is not button!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetVisible(), "After label is selected, visible checkbox is empty and Apply3s button clicked, the Target is visible!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetOnTop(), "After label is selected, on top checkbox is empty and Apply3s button clicked, the Target is on top!");
        Assert.False(_autoWaitPageWith10SecWait.IsTargetNonZeroSize(), "After label is non zero side, visible checkbox is empty and Apply3s button clicked, the Target is non zero sized!");
    }

    // Element type specific tests
    [Test]
    public void AutoWaitPageTest45_SelectElementTypeButton_CheckboxesUntouched_ThenClickTargetButton()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Button");
        _autoWaitPageWithDefaultWait.TargetButtonClicker();
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetOpStatusText(), "Target clicked.", "The target button click is not working.");
    }
    
    [Test]
    public void AutoWaitPageTest46_SelectElementTypeInput_CheckboxesUntouched_ThenInputText()
    {
        string test = "testText";
        _autoWaitPageWithDefaultWait.SelectTargetElement("Input");
        _autoWaitPageWithDefaultWait.TargetInputFiller(test);
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetTargetInputValue(), test, "The actual text is different from the input.");
    }
    
    [Test]
    public void AutoWaitPageTest47_SelectElementTypeTextarea_CheckboxesUntouched_ThenInputText()
    {
        string test = "testText";
        _autoWaitPageWithDefaultWait.SelectTargetElement("Textarea");
        _autoWaitPageWithDefaultWait.TargetTextareaFiller(test);
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetTargetTextareaValue(), test, "The actual text is different from the input.");
    }
    
    [Test]
    public void AutoWaitPageTest48_SelectElementTypeSelect_CheckboxesUntouched_ThenSelectAValue()
    {
        string test = "Item 2";
        _autoWaitPageWithDefaultWait.SelectTargetElement("Select");
        _autoWaitPageWithDefaultWait.TargetSelectPicker(test);
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetTargetSelectValue(), test, "The selected is different from the select-input.");
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetOpStatusText(), "Target clicked.", "The op status text is different from the select-input.");
    }
    
    [Test]
    public void AutoWaitPageTest49_SelectElementTypeLabel_CheckboxesUntouched_ThenGetLabelText()
    {
        _autoWaitPageWithDefaultWait.SelectTargetElement("Label");
        _autoWaitPageWithDefaultWait.TargetLabelClicker();
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetTargetLabelText(), "This is a Label", "The label text is wrong!");
        Assert.AreEqual(_autoWaitPageWithDefaultWait.GetOpStatusText(), "Target clicked.", "The click label text is wrong!");
    }
    
    //Navbar tests
    [Test]
    public void AutoWaitPageTest50_NavbarTest1_UITAPLogoTest()
    {
        _navbar.UITAPLogoClick();
        var title = _defaultWait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    [Test]
    public void AutoWaitPageTest51_NavbarTest2_HomeButtonTest()
    {
        _navbar.HomeButtonClick();
        var title = _defaultWait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }

    [Test]
    public void AutoWaitPageTest52_NavbarTest3_ResourcesButtonTest()
    {
        _navbar.ResourcesButtonClick();
        var w3SchoolsLink = _defaultWait.Until(driver => driver.FindElement(By.CssSelector("a[href='https://www.w3schools.com']")));
        Assert.IsTrue(w3SchoolsLink.Displayed, "w3schools.com link is not displayed");
    }

    [Test]
    public void AutoWaitPageTest53_NavbarTest4_TogglerTestInSmallerScreen()
    {
        _driver.Manage().Window.Size = new System.Drawing.Size(800, 600);
        Thread.Sleep(3000);
        _navbar.OpenNavbarWithNavbarToggler();
        _navbar.HomeButtonClick();
        
        var title = _defaultWait.Until(driver => driver.FindElement(By.Id("title")));
        Assert.IsTrue(title.Displayed, "UI Test Automation Playground title is not displayed");
    }
    
    // Footer tests
    [Test]
    public void AutoWaitPageTest54_FooterTest1_GithubLink()
    {
        _footer.OpenGithubRepoByLink();
        var githubRepository = _defaultWait.Until(driver => driver.FindElement(By.CssSelector("a[href='/Inflectra/ui-test-automation-playground']")));
        Assert.IsTrue(githubRepository.Displayed, "Github Repository is not loaded");
    }
    
    [Test]
    public void AutoWaitPageTest55_FooterTest2_RapiseLink()
    {
        _footer.OpenRapisePage();
        var rapiseTitle = _defaultWait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Rapise')]")));
        Assert.IsTrue(rapiseTitle.Displayed, "Rapise product page is not loaded (Rapise - title is not visible)");
    }
    
    [Test]
    public void AutoWaitPageTest56_FooterTest3_InflectraCorporationLink()
    {
        _footer.OpenInflectraPage();
        var inflectraTitle = _defaultWait.Until(driver => driver.FindElement(By.XPath("//h2[contains(text(),'Quality At Its Core:')]")));
        Assert.IsTrue(inflectraTitle.Displayed, "Inflectra page is not loaded (Inflectra - title is not visible)");
    }
    
    [Test]
    public void AutoWaitPageTest57_FooterTest4_ApacheLicenseLink()
    {
        _footer.OpenApacheLicense();
        var apacheTitle = _defaultWait.Until(driver => driver.FindElement(By.Id("apache-license-version-20")));
        Assert.IsTrue(apacheTitle.Displayed, "Apache license page is not loaded (Apache license - title is not visible)");
    }
}