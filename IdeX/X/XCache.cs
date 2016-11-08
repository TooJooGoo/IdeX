// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System.Threading;
using System.Windows.Forms;

public class XCache
{
    public static void SetText(object obj)
    {
        var saved = false;
        if (obj != null)
        {
            if (obj is string)
            {
                var str = (string)obj;
                if (str.Length > 0)
                {
                    Clipboard.SetText(str);
                    saved = true;
                }
            }
        }
        if (!saved)
        {
            Clipboard.Clear();
        }
    }
    public static void SetTextSafe(string stringToCopy)
    {
        var clipboardThread = new Thread(SetText);
        clipboardThread.SetApartmentState(ApartmentState.STA);
        clipboardThread.IsBackground = false;
        clipboardThread.Start(stringToCopy);
    }
}
