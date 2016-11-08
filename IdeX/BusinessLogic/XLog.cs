// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.IO;

public class XLog
{
    public static bool Enabled = false;
    public static readonly string DirName = Vsix.Name;
    public static readonly string LogfileName = Vsix.Name + ".txt";
    public const long ByteLimit = 16 * 1024;

    public static void Init()
    {
        Persistence.LoggingEnabled += Persistence_LoggingEnabled;
        Persistence.LoggingDisabled += Persistence_LoggingDisabled;
    }
    public static void Log(string msg)
    {
        if (Enabled)
        {
            if (!Directory.Exists(LogDir))
            {
                Directory.CreateDirectory(LogDir);
            }
            using (var stream = new StreamWriter(
                new FileStream(LogFile, FileMode.Append, FileAccess.Write)))
            {
                stream.WriteLine(DateTime.Now + "\t" + msg);
            }
        }
    }
    public static void DeleteLogfile()
    {
        if (File.Exists(LogFile))
        {
            File.Delete(LogFile);
        }
    }
    public static void DeleteLogfileIfTooLarge()
    {
        try
        {
            var f = new FileInfo(LogFile);
            if (f.Length > ByteLimit)
            {
                DeleteLogfile();
            }
        }
        catch { }
    }
    public static string LogDir
    {
        get
        {
            var temp = Path.GetTempPath();
            if(!temp.EndsWith("\\"))
            {
                temp += "\\";
            }
            return temp + DirName;
        }
    }
    public static string LogFile
    {
        get
        {
            return LogDir + "\\" + LogfileName;
        }
    }

    public static bool Exists
    {
        get
        {
            return File.Exists(LogFile);
        }
    }

    public static void Persistence_LoggingEnabled(object sender, EventArgs eventArgs)
    {
        Enabled = true;
    }
    public static void Persistence_LoggingDisabled(object sender, EventArgs eventArgs)
    {
        Enabled = false;
    }

}
