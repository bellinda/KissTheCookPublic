﻿

#pragma checksum "E:\Visual Studio Projects\KissTheCookCustomEdition\KissTheCookCustomEdition\KissTheCookCustomEdition.WindowsPhone\Pages\RecipeDetailsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4838F5EC9FE27EAC12500D8A780C6E10"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KissTheCookCustomEdition.Pages
{
    partial class RecipeDetailsPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 42 "..\..\..\Pages\RecipeDetailsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.startSessionButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 57 "..\..\..\Pages\RecipeDetailsPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Holding += this.takePictureButton_Holding;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 59 "..\..\..\Pages\RecipeDetailsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.shareOnFacebook_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 48 "..\..\..\Pages\RecipeDetailsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.readyButton_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 49 "..\..\..\Pages\RecipeDetailsPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.giveUpButton_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


