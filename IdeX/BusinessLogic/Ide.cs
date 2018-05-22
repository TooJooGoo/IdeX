// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio;
using System;
using System.Linq;

public static class Ide
{
    public static DTE2 Dte;
    public static ServerWindow ServerWindow;

    public static void Init(VsPackage vsPackage)
    {
        var serviceProvider = (IServiceProvider)vsPackage;
        Dte = (DTE2)serviceProvider.GetService(typeof(DTE));
    }
    public static string TryGetOp(string right)
    {
        try
        {
            return GetOp(right) as string;
        }
        catch
        {
            return "";
        }
    }
    public static object GetOp(string right)
    {
        if (XString.Eq(right
            , "NL"
            , "NewLine"
            ))
        {
            var result = "\r\n";
            return result;
        }
        else if (XString.Eq(right
            , "CR"
            , "CarriageReturn"
            ))
        {
            var result = "\r";
            return result;
        }
        else if (XString.Eq(right
            , "LF"
            , "LineFeed"
            ))
        {
            var result = "\n";
            return result;
        }
        else if (XString.Eq(right
            , "HT"
            , "Tab"
            ))
        {
            var result = "\t";
            return result;
        }
        else if (XString.Eq(right
            , "SP"
            , "Space"
            ))
        {
            var result = " ";
            return result;
        }
        else if (XString.Eq(right
            , "CO"
            , "Comma"
            ))
        {
            var result = ",";
            return result;
        }
        else if (XString.Eq(right
            , "SC"
            , "SemiColon"
            ))
        {
            var result = ";";
            return result;
        }
        else if (XString.Eq(right
            , "FS"
            , "FullStop"
            ))
        {
            var result = ".";
            return result;
        }
        else if (XString.Eq(right
            , "SO"
            , "Solidus"
            ))
        {
            var result = "/";
            return result;
        }
        else if (XString.Eq(right
            , "RS"
            , "ReverseSolidus"
            ))
        {
            var result = "\\";
            return result;
        }
        else if (XString.Eq(right
            , "a.text"
            , "ActiveDocument.Selection.Text"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.Text;
        }
        else if (XString.Eq(right
            , "a.line"
            , "ActiveDocument.Selection.CurrentLine"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.CurrentLine.ToString();
        }
        else if (XString.Eq(right
            , "a.col"
            , "ActiveDocument.Selection.CurrentColumn"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.CurrentColumn.ToString();
        }
        else if (XString.Eq(right
            , "a.topline"
            , "ActiveDocument.Selection.TopLine"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.TopLine.ToString();
        }
        else if (XString.Eq(right
            , "a.bottomline"
            , "ActiveDocument.Selection.BottomLine"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.BottomLine.ToString();
        }
        else if (XString.Eq(right
            , "a.rangecount"
            , "ActiveDocument.Selection.TextRangesCount"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.TextRanges.Count.ToString();
        }
        else if (XString.Eq(right
            , "a.topchar"
            , "ActiveDocument.Selection.TopCharOffset"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.TopPoint.AbsoluteCharOffset.ToString();
        }
        else if (XString.Eq(right
            , "a.bottomchar"
            , "ActiveDocument.Selection.BottomCharOffset"
            ))
        {
            var selection = ActiveDocument_GetSelection();
            return selection.BottomPoint.AbsoluteCharOffset.ToString();
        }

        //else if (XString.Eq(right
        //, "test"
        //, "Line_GetLineIndexByCharIndex"
        //))
        //{
        //    var tdoc2 = Dte.ActiveDocument.Object("TextDocument") as TextDocument;
        //    var ep2 = tdoc2.CreateEditPoint();
        //    ep2.MoveToAbsoluteOffset(1);
        //    var line = ep2.Line;
        //}

        else if (XString.Eq(right
            , "s.items"
            , "SolutionExplorer.Selection.Items"
            ))
        {
            var result = Ide.SolutionExplorer_GetItems();
            return result;
        }
        else if (XString.Eq(right
            , "s.itemcount"
            , "SolutionExplorer.Selection.ItemCount"
            ))
        {
            var result = Ide.SolutionExplorer_GetItemCount();
            return result;
        }
        else if (XString.Eq(right
            , "docs"
            , "Editor.OpenDocuments"))
        {
            var result = OpenDocuments_Get();
            return result;
        }
        else if (XString.Eq(right
            , "doccount"
            , "Editor.OpenDocumentCount"))
        {
            var result = OpenDocumentCount_Get();
            return result;
        }
        else if (XString.Eq(right
            , "Server.Id"
            ))
        {
            return ServerWindow.Text;
        }
        else if (XString.Eq(right
            , "Server.State"
            ))
        {
            var result = ServerManager.ServerState.ToString();
            return result;
        }
        else if (XString.Eq(right
            , "Server.Handle"
            ))
        {
            var result = ServerWindow.Handle.ToString();
            return result;
        }
        else if (XString.Eq(right
            , "Server.Class"
            ))
        {
            var result = ServerWindow.GetWindowClassName();
            return result;
        }
        else if (XString.Eq(right
            , "Server.LogEnabled"
            ))
        {
            var result = XLog.Enabled ? "1" : "0";
            return result;
        }
        else if (XString.Eq(right
            , "Server.LogfileExists"
            ))
        {
            var result = XLog.Exists ? "1" : "0";
            return result;
        }
        else if (XString.Eq(right
            , "Server.LogFile"
            ))
        {
            var result = XLog.LogFile.ToString();
            return result;
        }
        else if (XString.Eq(right
            , "Server.Marker"
            ))
        {
            var result = Persistence.Marker.ToString();
            return result;
        }
        else if (XString.Eq(right
            , "Server.Version"
            ))
        {
            var result = Persistence.Version.ToString();
            return result;
        }
        else if (XString.Eq(right
            , "Server.SupportGetOps"
            ))
        {
            var result = Persistence.SupportGetOps ? "1" : "0";
            return result;
        }
        else if (XString.Eq(right
            , "Server.SupportSetOps"
            ))
        {
            var result = Persistence.SupportSetOps ? "1" : "0";
            return result;
        }
        else if (XString.Eq(right
            , "Server.RequestEncoding"
            ))
        {
            var result = Persistence.RequestEncoding.ToString();
            return result;
        }
        else if (XString.Eq(right
            , "Server.ResponseEncoding"
            ))
        {
            var result = Persistence.ResponseEncoding.ToString();
            return result;
        }
        else if (XString.Eq(right
            , "Server.ClaimMarkerInRequest"
            ))
        {
            var result = Persistence.ClaimMarkerInRequest ? "1" : "0";
            return result;
        }
        else if (XString.Eq(right
            , "Server.IncludeMarkerInResponse"
            ))
        {
            var result = Persistence.IncludeMarkerInResponse ? "1" : "0";
            return result;
        }
        return "";
    }

    private static string OpenDocumentCount_Get()
    {
        var documents = Dte.Documents;
        var docs = documents.OfType<Document>();
        var count = docs.Count().ToString();
        return count;
    }

    public static string TrySetOp(string left, string right)
    {
        try
        {
            return SetOp(left, right);
        }
        catch
        {
            return "";
        }
    }
    public static string SetOp(string left, string right)
    {
        if (XString.Eq(left
            , "Server.Id"
            ))
        {
            ServerWindow.Text = right;
        }
        else if (XString.Eq(left, "Logfile"))
        {
            if (XString.Eq(right, "Delete"))
            {
                XLog.DeleteLogfile();
            }
        }

        //else if (XString.Eq(left
        //    , "test"
        //    ))
        //{
        //    var doc = Dte.ActiveDocument as Document;
        //    var selection = doc.Selection as TextSelection;
        //    selection.MoveToAbsoluteOffset(1, false);
        //    selection.MoveToAbsoluteOffset(5, true);
        //}



        return "";
    }

    public static void Document_SetSelectedRange(int startIndex, int endIndex)
    {
        var doc = Dte.ActiveDocument as Document;
        var selection = doc.Selection as TextSelection;
        selection.MoveToAbsoluteOffset(startIndex, false);
        selection.MoveToAbsoluteOffset(endIndex, true);
    }
    public static void Document_ReplaceSelectedText()
    {
        var doc = Dte.ActiveDocument as Document;
        var selection = doc.Selection as TextSelection;
        selection.Paste();
    }
    public static void Document_DeleteSelectedText()
    {
        var doc = Dte.ActiveDocument as Document;
        var selection = doc.Selection as TextSelection;
        selection.Delete();
    }

    public static int Document_GetLineIndexByChar(int charIndex)
    {
        var tdoc = Dte.ActiveDocument.Object("TextDocument") as TextDocument;
        var point = tdoc.CreateEditPoint();
        point.MoveToAbsoluteOffset(charIndex);
        var line = point.Line;
        //var lineContent = point.GetLines(line, line + 1);
        return line;
    }

    public static string Document_GetLine(int lineIndex)
    {
        var tdoc = Dte.ActiveDocument.Object("TextDocument") as TextDocument;
        var point = tdoc.CreateEditPoint();
        point.MoveToLineAndOffset(lineIndex, 1);

        var line = point.Line;
        var lineContent = point.GetLines(line, line + 1);
        return lineContent;
    }

    public static void Document_SelectLine(int lineIndex)
    {
        var tdoc = Dte.ActiveDocument.Object("TextDocument") as TextDocument;

        var selection = tdoc.Selection as TextSelection;
        selection.MoveToLineAndOffset(lineIndex, 1, false);
        selection.EndOfLine(true);
    }

    public static int Document_GetLineLength(int charIndex)
    {
        var tdoc = Dte.ActiveDocument.Object("TextDocument") as TextDocument;
        var point = tdoc.CreateEditPoint();
        point.MoveToAbsoluteOffset(charIndex);
        int lineLength = point.LineLength;
        return lineLength;
    }

    public static int Document_GetCharIndexByLine(int lineIndex)
    {
        var tdoc = Dte.ActiveDocument.Object("TextDocument") as TextDocument;
        var point = tdoc.CreateEditPoint();
        point.MoveToLineAndOffset(lineIndex, 1);
        int charIndex = point.AbsoluteCharOffset;
        return charIndex;
    }

    public static int Document_GetTextLength()
    {
        var tdoc = Dte.ActiveDocument.Object("TextDocument") as TextDocument;
        return tdoc.EndPoint.AbsoluteCharOffset - 1;
    }

    public static string Document_GetText()
    {
        var tdoc = Dte.ActiveDocument.Object("TextDocument") as TextDocument;
        var point = tdoc.StartPoint.CreateEditPoint();
        return point.GetText(tdoc.EndPoint);
    }

    public static void Document_ScrollToEnd()
    {
        var doc = Dte.ActiveDocument as Document;
        var selection = doc.Selection as TextSelection;

        selection.EndOfDocument(false);
        selection.EndOfDocument(true);
    }

    public static void Document_GetSelectedRange(out int startIndex, out int endIndex)
    {
        var selection = ActiveDocument_GetSelection();
        startIndex = selection.TopPoint.AbsoluteCharOffset;
        endIndex = selection.BottomPoint.AbsoluteCharOffset;
    }

    public static string SolutionExplorer_GetItems()
    {
        int index = 0;
        var info = "";
        var array = (Array)Dte.ToolWindows.SolutionExplorer.SelectedItems;
        if(array != null && array.Length > 0)
        {
            var items = array.Cast<UIHierarchyItem>();
            info += "ObjectProperties = Type,Kind,Name,Path\r\n";
            var solutions = items.Select(x => x.Object).OfType<Solution>();
            foreach (var solution in solutions)
            {
                info += index + "\r\n";
                info += "Type = " + typeof(Solution).Name + "\r\n";
                info += "Kind = Solution\r\n";
                info += "Name = " + Solution_GetName(solution) + "\r\n";
                info += "Path = " + solution.FullName + "\r\n";
                index++;
            }

            var projects = items.Select(x => x.Object).OfType<Project>();
            foreach(var project in projects)
            {
                info += index + "\r\n";
                info += "Type = " + typeof(Project).Name + "\r\n";
                info += "Kind = ";
                var kind = project.Kind;
                if (Guid.Parse(kind) == XConstants.ProjectKind.SolutionFolder_Guid)
                {
                    info += "SolutionFolder";
                }
                else if (Guid.Parse(kind) == XConstants.ProjectKind.CSharp_Guid)
                {
                    info += "CSharp";
                }
                else if (Guid.Parse(kind) == XConstants.ProjectKind.Cpp_Guid)
                {
                    info += "Cpp";
                }
                else if (Guid.Parse(kind) == XConstants.ProjectKind.VisualBasic_Guid)
                {
                    info += "VisualBasic";
                }
                else if (Guid.Parse(kind) == XConstants.ProjectKind.Web_Guid)
                {
                    info += "Web";
                }
                else
                {
                    info += kind;
                }
                info += "\r\n";
                info += "Name = " + project.Name + "\r\n";
                var path = Project_GetPath(project);
                info += "Path = " + path + "\r\n";
                index++;
            }

            var projectItems = items.Select(x => x.Object).OfType<ProjectItem>();
            foreach(var projectItem in projectItems)
            {
                info += index + "\r\n";
                info += "Type = " + typeof(ProjectItem).Name + "\r\n";
                info += "Kind = ";
                var kind = projectItem.Kind;
                if (Guid.Parse(kind) == VSConstants.GUID_ItemType_PhysicalFile)
                {
                    info += "PhysicalFile";
                }
                else if (Guid.Parse(kind) == VSConstants.GUID_ItemType_PhysicalFolder)
                {
                    info += "PhysicalFolder";
                }
                else if (Guid.Parse(kind) == VSConstants.GUID_ItemType_SubProject)
                {
                    info += "SubProject";
                }
                else if (Guid.Parse(kind) == VSConstants.GUID_ItemType_VirtualFolder)
                {
                    info += "VirtualFolder";
                }
                else
                {
                    info += kind;
                }
                info += "\r\n";
                info += "Name = " + projectItem.Name + "\r\n";
                var path = ProjectItem_GetPath(projectItem);
                info += "Path = " + path + "\r\n";
                index++;
            }
            info = "ObjectCount = " + index + "\r\n" + info;
        }
        return info;
    }
    public static string SolutionExplorer_GetItemCount()
    {
        int count = 0;
        var array = (Array)Dte.ToolWindows.SolutionExplorer.SelectedItems;
        if (array != null && array.Length > 0)
        {
            var items = array.Cast<UIHierarchyItem>();
            var solutions = items.Select(x => x.Object).OfType<Solution>();
            count += solutions.Count();
            var projects = items.Select(x => x.Object).OfType<Project>();
            count += projects.Count();
            var projectItems = items.Select(x => x.Object).OfType<ProjectItem>();
            count += projectItems.Count();
        }
        return count.ToString();
    }
    public static string Solution_GetName(Solution solution)
    {
        var value = "";
        if (solution.Properties != null)
        {
            var p = solution.Properties.Item("Name");
            if (p != null)
            {
                var v = p.Value;
                if (v != null)
                {
                    value = v.ToString();
                }
            }
        }
        return value;
    }
    public static string Project_GetPath(Project project)
    {
        var path = "";
        if (project.Properties != null)
        {
            var p = project.Properties.Item("FullPath");
            if (p != null)
            {
                var v = p.Value;
                if (v != null)
                {
                    path = v.ToString();
                }
            }
        }
        return path;
    }
    public static string ProjectItem_GetPath(ProjectItem projectItem)
    {
        var path = "";
        if (projectItem.Properties != null)
        {
            var p = projectItem.Properties.Item("FullPath");
            if (p != null)
            {
                var v = p.Value;
                if (v != null)
                {
                    path = v.ToString();
                }
            }
        }
        return path;
    }
    public static string OpenDocuments_Get()
    {
        string info = "";
        int index = 0;
        info += "ObjectProperties = Kind,Name,Path\r\n";
        var documents = Dte.Documents;
        var docs = documents.OfType<Document>();
        foreach (var doc in docs)
        {
            //info += "Type = " + typeof(Document).Name + "\r\n";
            info += index + "\r\n";
            info += "Kind = ";
            var kind = doc.Kind;
            if (Guid.Parse(kind) == Guid.Parse(Constants.vsDocumentKindBinary))
            {
                info += "Binary";
            }
            else if (Guid.Parse(kind) == Guid.Parse(Constants.vsDocumentKindHTML))
            {
                info += "Html";
            }
            else if (Guid.Parse(kind) == Guid.Parse(Constants.vsDocumentKindResource))
            {
                info += "Resource";
            }
            else if (Guid.Parse(kind) == Guid.Parse(Constants.vsDocumentKindText))
            {
                info += "Text";
            }
            info += "\r\n";
            info += "Name = " + doc.Name + "\r\n";
            info += "Path = " + doc.FullName + "\r\n";
            index++;
        }
        info = "ObjectCount = " + index + "\r\n" + info;
        return info;
    }
    public static TextSelection ActiveDocument_GetSelection()
    {
        var doc = Dte.ActiveDocument as Document;
        var selection = doc.Selection as TextSelection;
        return selection;

        //var docObject = doc.Object("TextDocument");
        //var tdoc = docObject as TextDocument;
        //var d = doc as Document;
        //var sel = d.Selection;
        //var sel1 = sel as EnvDTE.SelectionContainer;
        //var sel2 = sel as TextSelection;
        //var tsel = tdoc.Selection;
        //return tsel;
    }
    public static void StatusBar_Set(string text, string prefix = Vsix.Name)
    {
        if(Dte != null)
        {
            Dte.StatusBar.Text = prefix + ": " + text;
        }
    }
}
