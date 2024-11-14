## Describe the bug
2024-11-14
### Defect number (ID)
3
### Title
Clicking on the Apply 3-5-10s buttons, the button element is having zero size
### Summary
Without interaction (default) with checkboxes (specially Non Zero Size), and clicking on the Apply - "3s" or "5s" or "10s" button, the button element is having zero size when it is expected to be non-zero-sized .
### Test
AutoWaitPageTest04_DefaultApply3sButtonClick
AutoWaitPageTest05_DefaultApply5sButtonClick
AutoWaitPageTest06_DefaultApply10sButtonClick

### Environment
Operating System: Windows 10 Pro, 64-bit, 10.0.19045
Browser: Google Chrome, version 131.0.6778.70 (Official Build) (64-bit)
Programming Language: C#
Development Environment: JetBrains Rider 2024.1.1
NUnit: 3.13.3
Microsoft.NET.Test.Sdk: 17.1.0
Selenium.Webdriver.ChromeDriver: 131.0.6778.6900
Selenium Support: 4.26.1
Selenium.Webdriver: 4.26.1
SeleniumExtras.WaitHelpers: 1.0.2

### Steps to reproduce
Open the Auto Wait page (/autowait).
Click on the "Apply3s" or "Apply5s" or "Apply10s" button (checkboxes untouched, all checked by default).
The target button's size is zero.
Reproducible: Yes.
### Expected Result
The target element should have a non-zero size after the "Apply 3s" or "Apply 5s" or "Apply 10s" button is clicked, ensuring it is visible and occupying space on the page.
### Actual Result
The target element has a size of zero (both width and height), causing the test to fail.
### Severity/Priority
High
### Status
Open
### Additional context
-


