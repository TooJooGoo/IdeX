// ----------------------------------------------------
// COPYRIGHT (C) <TJG> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System.Resources;


public class XRes
{
    public static ResourceManager ResourceManager = null;

    public static T GetMainObject<T>(string name)
    {
        return (T)IdeX.MainResource.ResourceManager.GetObject(name);
    }

    public static T GetObject<T>(string name)
    {
        return (T)IdeX.MainResource.ResourceManager.GetObject(name);
    }
}