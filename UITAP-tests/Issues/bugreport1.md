## Describe the bug
2024-11-14
### Defect number (ID)
1
### Title
Invalid File Upload Accepted without error message
### Summary
The system currently allows unsupported file types to be uploaded without proper validation. The test revealed that the site allows the uploading, and the UI displays a success message even after an unsupported file type (e.g., a large PDF or a JPG file) is uploaded.
### Test
FileUploadPageTest03_UploadInvalidFiles_SingleWrongFile (parameterized)
testCase1: test6_20mb.pdf
testCase2: test7.jpg
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
Open the file upload page (/upload).
Click on the "Drag and drop your files here" area.
Attempt to upload an unsupported file, such as too big (test6_20mb.pdf) or not supported (test7.jpg) file.
Observe the message after upload.
Reproducible: Yes, with the specified unsupported file types.
### Expected Result
The UI should display an error indicating that the file type is not supported, and the file should not be processed.
### Actual Result
The UI shows a success message stating the file has been selected, which implies the file was uploaded.
### Severity/Priority
High
### Status
Open
### Additional context
Screenshot

<div align="center">
  <a>
    <img src="./bugreport1.PNG" alt="bugreport1" width="1100" height="500">
  </a>
</div>


