# IdeX

**IdeX allows your application to communicate with Visual Studio across process boundaries.**

IdeX is the acronym for Integrated Development Environment Extension. It uses IPC (Inter Process Communication) to shift data between Visual Studio and an external process for example your application. The IdeX server integrates into Visual Studio and the IdeX client integrates into the external process. The external process sends a request to the server. Based on the request, the server collects data and sends a response back to the client. Both request and response strings adhere to the IdeX protocol syntax.

IdeX ...
* is robust and very fast
* is easy to use
* seamlessly integrates into the Visual Studio UI
* has no performance impact on Visual Studio

Your application can use IdeX for example to access the current text selection or the current selected items inside the Visual Studio. Learn more about the capabilities of the IdeX protocol syntax on our [Website](https://github.com/TooJooGoo/IdeX).

## Download

The [latest stable version](https://visualstudiogallery.msdn.microsoft.com/a53074bd-cf8d-4be7-8eb6-2b768a45b96b) is available at the Visual Studio gallery.

The [most recent version](http://vsixgallery.com/extension/8F047980-8107-4E48-B836-571A2AAAFA3C)  can be found at the VSIX gallery. Please check the build status before you download the most recent version. 

[![Build status](https://ci.appveyor.com/api/projects/status/4m76qv4u4t6pc1yg?svg=true)](https://ci.appveyor.com/project/TooJooGoo/idex)


## Getting Started
This chapter explains how to setup IdeX for your own business. First of all you have to download IdeX and install to Visual Studio. Use the download links above or click "Tools/Extensions and Updates.." in Visual Studio and browse online for "IdeX".

### Start the server
In Visual Studio click menu item "Tools/IdeX/Enable". The IdeX server is now enabled, ready for processing client requests.

### Start the client
In Visual Studio click the menu item "Tools/IdeX/Lab". The IdeX laboratory is started in a separate window.

![Idex laboratory](Art/IdexLab.png "The IdeX laboratory")

The IdeX Lab is used to simulate and test requests against IdeX server.

The request strings can be used inside your application to communicate with Visual Studio.

### Sample Usage
The following sample shows how you can get all items currently selected in the solution explorer.

Open any Visual Studio project and select some items in the solution explorer as shown below.

![Alt](Art/SolutionExplorerSelection.png "Solution explorer with some selected items")

Go to the IdeX Lab and enter the following code into the request window:

	SolutionExplorer.GetSelectedItemCount()

Press button "Send Request" or type "ALT+Enter" to send the request. The response window should yield the following string:

	3

We just asked Visual Studio how many items are selected in the solution explorer. Now enter the following request and send it:

	SolutionExplorer.GetSelectedItems()

The response window should yield a string similar to this:

	ObjectCount = 3
	ObjectProperties = Type,Kind,Name,Path
	0
	Type = Solution
	Kind = Solution
	Name = My Solution
	Path = E:\Vs\CopyData\My Solution.sln
	1
	Type = Project
	Kind = CSharp
	Name = My Project
	Path = E:\Vs\CopyData\CopyData\
	2
	Type = ProjectItem
	Kind = PhysicalFile
	Name = Program.cs
	Path = E:\Vs\CopyData\CopyData\Program.cs

We just asked Visual Studio what kind of items are selected in the solution explorer.

There are many other IPC functions available, for example you can query the currently selected text from the active document. Learn more about the [IdeX protocol syntax](IdexSyntax.txt).

To use IdeX within your project, just include the [IdexPipe](IdexPipe.md) class. Then use the IdexPipe class to send a request programmatically:

```csharp
// Tell which encoding you want to use.
IdexPipe.Encoding = IdexPipe.Unicode;
// Build the request string.
string request = "SolutionExplorer.GetSelectedItems()";
// Send the request.
// The Send method is executed synchronously.
// The response string holds the selected items 
// as shown above.
string response = IdexPipe.Send(request);
```

### Stop the server
In Visual Studio click menu item "Tools/IdeX/Disable". The IdeX server is now disabled, further client requests won't be processed.

## Features
See the list of most popular features.

- **Document.GetSelectedText()** 
Gets the current selected text of the active document.
	
- **Document.GetCaretLineIndex()** 
Gets the line index of the caret.
	
- **Document.GetCaretColumnIndex()** 
Gets the column index of the caret.
	
- **Document.GetSelectedStartLineIndex()** 
Gets the line index where the current text selection starts.
	
- **Document.GetSelectedEndLineIndex()** 
Gets the line index where the current text selection ends.
	
- **Document.GetSelectedRangeCount()** 
Gets the count of selected text ranges.
	
- **Document.GetSelectedStartCharIndex()** 
Gets the char index where the current text selection starts.
	
- **Document.GetSelectedEndCharIndex()** 
Gets the char index where the current text selection ends.
	
- **Document.GetOpenDocuments()** 
Gets the documents currently opened in the editor window.

- **SolutionExplorer.GetSelectedItems()** 
Gets the items currently selected in the solution explorer.
	
- **SolutionExplorer.GetSelectedItemCount()** 
Gets the count of items currently selected in the solution explorer.

## Changelog
See the [change log](CHANGELOG.md).

## Contribution
See the [contribution guidelines](CONTRIBUTING.md).

## License
See the [license](LICENSE).
