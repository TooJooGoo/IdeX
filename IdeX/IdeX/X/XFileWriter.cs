// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.IO;

public partial class XFileWriter : IDisposable
{
    private FileStream FileStream;
    private StreamWriter StreamWriter;

    private XFileWriter(FileStream stream)
    {
        FileStream = stream;
        StreamWriter = new StreamWriter(stream);
    }

    /// <summary>
    /// Creates (or overwrites) a file for writing.
    /// </summary>
    public static XFileWriter Open(string path)
    {
        var stream = new FileStream(path, FileMode.Create, FileAccess.Write);
        return new XFileWriter(stream);
    }

    /// <summary>
    /// Creates a new FileWriter based on the given stream.
    /// </summary>
    public static XFileWriter Open(FileStream stream)
    {
        return new XFileWriter(stream);
    }

    /// <summary>
    /// Flushs all data and closes the FileWriter.
    /// </summary>
    public static void Close(ref XFileWriter writer)
    {
        if (writer != null)
        {
            writer.Flush();
            writer.Close();
            writer = null;
        }
    }

    /// <summary>
    /// Flushs all objects.
    /// </summary>
    public void Flush()
    {
        if (StreamWriter != null)
        {
            StreamWriter.Flush();
        }

        if (FileStream != null)
        {
            FileStream.Flush();
        }
    }

    /// <summary>
    /// Closes all objects.
    /// </summary>
    public void Close()
    {
        if (StreamWriter != null)
        {
            StreamWriter.Close();
            StreamWriter = null;
        }

        if (FileStream != null)
        {
            FileStream.Close();
            FileStream = null;
        }
    }

    /// <summary>
    /// Writes the given string to the stream.
    /// </summary>
    public void Write(string content)
    {
        StreamWriter.Write(content);
    }

    #region IDisposable
    private bool disposedValue = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                ((IDisposable)FileStream).Dispose();
                ((IDisposable)StreamWriter).Dispose();
            }
            disposedValue = true;
        }
    }
    public void Dispose()
    {
        Dispose(true);
    }
    #endregion
}
