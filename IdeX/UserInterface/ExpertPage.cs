// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

/// <summary>
/// https://msdn.microsoft.com/en-us/library/bb166195.aspx
/// </summary>
public class ExpertPage : DialogPage
{
    private bool claimMarkerInRequest = false;
    [Category("Protocol")]
    [DisplayName("Claim Marker in Request")]
    [Description("Whether the server claims the Marker to be present in the request. If FALSE, the server handles every request. If TRUE, the server handles only marked requests.")]
    public bool ClaimMarkerInRequest
    {
        get { return claimMarkerInRequest; }
        set { claimMarkerInRequest = value; }
    }

    private bool includeMarkerInResponse = false;
    [Category("Protocol")]
    [DisplayName("Include Marker in Response")]
    [Description("Whether the server includes the Marker in the response.")]
    public bool IncludeMarkerInResponse
    {
        get { return includeMarkerInResponse; }
        set { includeMarkerInResponse = value; }
    }

    private IdexEncoding requestEncoding = IdexEncoding.Unicode;
    [Category("Protocol")]
    [DisplayName("Request Encoding")]
    [Description("How the server expects the request to be encoded.")]
    public IdexEncoding RequestEncoding
    {
        get { return requestEncoding; }
        set { requestEncoding = value; }
    }

    private IdexEncoding responseEncoding = IdexEncoding.Unicode;
    [Category("Protocol")]
    [DisplayName("Response Encoding")]
    [Description("How the server encodes the response.")]
    public IdexEncoding ResponseEncoding
    {
        get { return responseEncoding; }
        set { responseEncoding = value; }
    }

    private bool supportGetOps = true;
    [Category("Support")]
    [DisplayName("Support Get operations")]
    [Description("Whether Get operations are supported.")]
    public bool SupportGetOps
    {
        get { return supportGetOps; }
        set { supportGetOps = value; }
    }

    private bool supportSetOps = true;
    [Category("Support")]
    [DisplayName("Support Set operations")]
    [Description("Whether Set operations are supported.")]
    public bool SupportSetOps
    {
        get { return supportSetOps; }
        set { supportSetOps = value; }
    }
}