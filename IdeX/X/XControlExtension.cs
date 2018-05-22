// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.Windows.Forms;

public static class XControlExtension
{
    public static void InvokeAction(this Control target, Action action)
    {
        if (target.InvokeRequired)
        {
            target.Invoke(action);
        }
        else
        {
            action();
        }
    }
}

