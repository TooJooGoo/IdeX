// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System.Windows.Forms;


public partial class XMB
{
    public static void Info(string text)
    {
        var result = MessageBox.Show(Form.ActiveForm
        , text
        , Vsix.Name
        , MessageBoxButtons.OK
        , MessageBoxIcon.Information);
    }

    public static DialogResult Question(string text)
    {
        var result = MessageBox.Show(Form.ActiveForm
        , text
        , Vsix.Name
        , MessageBoxButtons.YesNo
        , MessageBoxIcon.Question);
        return result;

    }

}

