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
[![Build status](https://ci.appveyor.com/api/projects/status/4m76qv4u4t6pc1yg?svg=true)](https://ci.appveyor.com/project/TooJooGoo/idex)

The latest version is available at the Visual Studio gallery.
- [Download IdeX](https://visualstudiogallery.msdn.microsoft.com/a53074bd-cf8d-4be7-8eb6-2b768a45b96b)

## Getting Started
This chapter explains how easy it is to setup IdeX and how you can plug it into your application.

### Start the server
In Visual Studio click menu item "Tools/IdeX/Enable".
The IdeX server is now enabled.

### Start the client
In Visual Studio click the menu item "Tools/IdeX/Lab"
The IdeX laboratory is started.

![Idex laboratory](Art/IdexLab.png "The IdeX laboratory")

The IdeX Lab is a standalone process simulating an IdeX client. The IdeX Lab is an environment for testing new requests against the IdeX server.
When you are done with a request, you can copy it to your application.

### Sample Usage
The following sample shows how to write a request which gets all items currently selected in the solution explorer.

Open an arbitrary Visual Studio project and select some items in the solution explorer.
The example below shows the solution explorer with three selected items.

![Alt](Art/SolutionExplorerSelection.png "Solution explorer with some selected items")

Go to the IdeX Lab and enter the following code into the request window at the top:

	g SolutionExplorer.Selection.ItemCount

The prefix "g" indicates a "get" operation. The string "SolutionExplorer.Selection.ItemCount" is the object to operate on. Press button "Send Request" or type "ALT+Enter" to send the request.
The response window at the bottom should yield the following text:

	3
We just asked Visual Studio how many items are selected in the solution explorer.

Now enter the following request and send it:

	g SolutionExplorer.Selection.Items

The response window should yield a text similar to this:

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

To use IdeX within your project, just include 
the [IdexPipe](IdexPipe.md) class.

Use the IdexPipe class to send a request programmatically:
```csharp
// Tell which encoding you want to use.
IdexPipe.Encoding = IdexPipe.Unicode;
// Build the request string.
string request = "g SolutionExplorer.Selection.Items";
// Send the request.
// The Send method is executed synchronously.
// The response string holds the selected items 
// as shown above.
string response = IdexPipe.Send(request);
```

Learn more about IdeX here: [IdeX syntax](IdexSyntax.txt)

## Features
The most popular features are:
- Get selected items
  - Gets the items currently selected in the solution explorer.
- Get selected text
  - Gets the current selected text of the active document.
- Get open documents
  - Gets the documents currently opened in the editor window.

## Change log
See the change log here: [Change log](CHANGELOG.md)

## Contribute
See the contribution guidelines here: [Contribution guidelines](CONTRIBUTING.md)

## License
See the license file here: [License](LICENSE)
