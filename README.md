# FilterAsYouTypeDocuments
This repository contains source code for "filter as you type" functionality for documents and files in Sitefinity

### Requirements

Works with all Sitefinity versions above 6.3

### Video demo:

Cick on the image below to watch a demo:
 
[![Revision history settings for pages in Sitefinity](https://www.dropbox.com/s/8xsapepqwzkzajl/documents.png?dl=0)](http://screencast.com/t/Bkvw0I7MqK0)

### License information

This project has been released under the Apache License, version 2.0, the text of which is included in the repository.

### Installation instructions

* Clone the repository to your file system
* Open SitefintiyWebApp in Visual Studio
* Copy the CustomWidgets folder and paste it inside the SitefinityWebApp
* Copy the Installer class and paste it in the SitefinityWebApp
* Open Properties -> AssemblyInfo and put the following line at the end:
 [assembly: PreApplicationStartMethod(typeof(Installer), "PreApplicationStart")]
* Build the solution
* Open the project in browser
* Navigate to Administration -> Settings -> Advanced -> ContentView -> Controls -> FrontendDocuments -> Views and click to Create new View
* Select DownloadListViewMasterElement as a type and add the following values to the fields:
 - ThumbnailType = BigIcons
 - Allow aging = True
 - Allow URL Queries = True
 - Disable sorting = False
 - Filter expression = Visible = true AND Status = Live
 - Items per page = 20
 - Allow users to set number of items per page = True
 - Sort expression = PublicationDate DESC
 - Template evaluation mode = None
 - Parent ID = 00000000-0000-0000-0000-000000000000
 - Render links in Master View = True
 - Enable social sharing = False
 - DisplayMode = Read
 - ResourceClassId = DocumentsResources
 - ViewName = CustomMasterListView
 - ViewType = SitefinityWebApp.CustomWidgets.DownloadList.CustomMasterListView, SitefinityWebApp

* Save changes

### How to test:

* Go to Content -> Documents & Files and make sure to upload several documents 
* Go to Pages and create new Standard page
* From the toolboxes sidebar expand CustomWidgets section
* Drag & Drop the CustomDownloadList Widget on the page
* Publish and view the page

### Additional resources:

For more detailed explanation on the code see:
[My personal blog - Sitefinity tips and tricks](http://www.sitefinitytipsandtricks.net/2015/03/12/form-entry-pdf-export/)

