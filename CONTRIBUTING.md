## Contributing
These are the contribution guidelines of the IdeX project, separated into the following topics.
- [Bug reports](#bug-reports)
- [Feature requests](#feature-requests)
- [Code guidelines](#code-guidelines)
- [Pull requests](#pull-requests)

### Bug reports

Bug reports are very helpful, if following guidelines are respected.

Before reporting a bug, please
- check if the bug has already been reported. Use the "Git issue search" therefor.
- check if the bug occurs on the latest main branch in the repository.
- check if the bug is caused by the code in this repository.

When writing a bug report, please
- use the git issue tracker
- keep the report as compact and completive as possible.
- adhere to the given bug report template.

### Bug report template

A bug report should contain a ReportTile, the author's Environment, the reproduction Steps, the observed Issue, the author's Expectation and optionally Attachments and Hints. Please use this bug template:

	ReportTitle
	  Conains a very brief report title.
	Environment
	  Includes the involved software and version.
	Steps
	  Includes the steps that lead to the bug.
	Issue
	  Describes what the software does wrong at this point.
	Expectation
	  Describes what the author expects the software to do at this point.
	Attachments
	  Includes additional data or information to reproduce the bug.
	Hints
	  Any info, insights or even suspicions the author thinks might help to solve the bug.

A real bug report could look like this:

	ReportTile
	  Failed to start server
	Environment
	  Microsoft Visual Studio Community 2015
	  Version 14.0.25431.01 Update 3
	Steps
      1. Goto "Tools/IdeX/Options"
      2. Click button "Enable"
	Issue
	  A window "Enable failed" pops up which shows the call stack.
	Expection
	  No window. Instad the server should be enabled.
	Attachments
	  File "callstack.txt".
	Hints
	  The issue does not occur if textbox "Marker" is focused before.

### Feature requests
Before writing a feature request, please
- check if your feature is already on the road map.

When writing a feature request, please
- use the git issue tracker
- outline the benefits of the requested feature.
- tell how you would support us to realize the feature .

### Code guidelines

- Always use the Visual Studio default code indentation. Use "Control+K+D" to format a document before checking in.
- Please eliminate all warnings before checking in.
- Do not use prefixes on variables such as "m_Name", "s_Name", "_Name". Just use "Name" instead.
- Use camel casing on variables. For example avoid names like "Servermanager" or "server_manager". Instead use "ServerManager".

### Pull requests
Before requesting for pull, please 
 - ask us first.
 - tell us your aim. For example do you want to deliver a patch, an improvement, a refactoring or a porting to another language.
 - use the git issue tracker

When your aim is cleared and agreed, please
 - adhere to the [code guidelines](#code-guidelines)
 - adhere to the pull request recommendation.

### Pull request recommendation
To get your work included in the project, please adhere to this recommendation.

1. [Fork](http://help.github.com/fork-a-repo/) the project, clone your fork, and configure the remotes:

   ```bash
   # Clone your fork of the repo into the current directory
   git clone https://github.com/<your-username>/<this-repro-name>.git
   # Navigate to the newly cloned directory
   cd <folder-name>
   # Assign the original repo to a remote called "upstream"
   git remote add upstream https://github.com/madskristensen/<this-repro-name>.git
   ```

2. If you cloned a while ago, get the latest changes from upstream:

   ```bash
   git checkout master
   git pull upstream master
   ```

3. Create a new topic branch off the main branch to contain your work:

   ```bash
   git checkout -b <topic-branch-name>
   ```

4. Commit your changes in logical chunks. Please adhere to the [git commit
   message guidelines](http://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html). Use Git's
   [interactive rebase](https://help.github.com/articles/interactive-rebase)
   feature to tidy up your commits. Prepend the name of the feature to the commit message.

5. Locally merge or rebase the upstream development branch into your topic branch:

   ```bash
   git pull [--rebase] upstream master
   ```

6. Push your topic branch up to your fork:

   ```bash
   git push origin <topic-branch-name>
   ```

7. [Open a Pull Request](https://help.github.com/articles/using-pull-requests/)
    with a clear title and description against the master branch.