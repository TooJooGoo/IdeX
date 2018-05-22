// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;

public sealed class XConstants
{
    public static class ProjectKind
    {
        public const string SolutionFolder_String = "{66A26720-8FB5-11D2-AA7E-00C04F688DDE}";
        public static readonly Guid SolutionFolder_Guid = new Guid(SolutionFolder_String);

        public const string VisualBasic_String = "{F184B08F-C81C-45F6-A57F-5ABD9991F28F}";
        public static readonly Guid VisualBasic_Guid = new Guid(VisualBasic_String);

        public const string CSharp_String = "{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}";
        public static readonly Guid CSharp_Guid = new Guid(CSharp_String);

        public const string Cpp_String = "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}";
        public static readonly Guid Cpp_Guid = new Guid(Cpp_String);

        public const string Web_String = "{E24C65DC-7377-472B-9ABA-BC803B73C61A}";
        public static readonly Guid Web_Guid = new Guid(Web_String);
    }

}
