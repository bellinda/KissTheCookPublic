﻿

#pragma checksum "E:\Visual Studio Projects\KissTheCookCustomEdition\KissTheCookCustomEdition\KissTheCookCustomEdition.Windows\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "02A809D8AE66522BA42B7B92693DB868"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KissTheCookCustomEdition
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 90 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.aboutButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 78 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.myRecepiesButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 66 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.favouriteRecepiesButton_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 54 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.allRecepiesButton_Click;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 45 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.timeButton_Click;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 28 "..\..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.TextBlock)(target)).SelectionChanged += this.pageTitle_SelectionChanged;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


