﻿#pragma checksum "..\..\..\Views\UserTakeBookUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "228407327D3BBF30FB6ED8677A870ACFB88958FFAB43CE66EED46926F0D49CA0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using BookLibrary.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace BookLibrary.Views {
    
    
    /// <summary>
    /// UserTakeBookUC
    /// </summary>
    public partial class UserTakeBookUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\Views\UserTakeBookUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox bookIdTxtb;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Views\UserTakeBookUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label bookIdLbl;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\UserTakeBookUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox dayTxtb;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Views\UserTakeBookUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dayLbl;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Views\UserTakeBookUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stdIdTxtb;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Views\UserTakeBookUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label stdIdLbl;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Views\UserTakeBookUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label priceLbl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/BookLibrary;component/views/usertakebookuc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\UserTakeBookUC.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.bookIdTxtb = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\Views\UserTakeBookUC.xaml"
            this.bookIdTxtb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bookIdLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.dayTxtb = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\..\Views\UserTakeBookUC.xaml"
            this.dayTxtb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.dayTxtb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dayLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.stdIdTxtb = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\Views\UserTakeBookUC.xaml"
            this.stdIdTxtb.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.stdIdTxtb_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.stdIdLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.priceLbl = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

