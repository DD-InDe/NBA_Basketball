﻿#pragma checksum "..\..\..\..\..\AllPages\TechAdminPages\AdminMenuPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B478DAA4A2E9F5442E6F6AFA19EB5EBE3B2B0991"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NBA_Basketball.AllPages.TechAdminPages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace NBA_Basketball.AllPages.TechAdminPages {
    
    
    /// <summary>
    /// AdminMenuPage
    /// </summary>
    public partial class AdminMenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\AllPages\TechAdminPages\AdminMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExecutionsButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\..\..\AllPages\TechAdminPages\AdminMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TeamReport;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NBA_Basketball;component/allpages/techadminpages/adminmenupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\AllPages\TechAdminPages\AdminMenuPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ExecutionsButton = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\..\AllPages\TechAdminPages\AdminMenuPage.xaml"
            this.ExecutionsButton.Click += new System.Windows.RoutedEventHandler(this.ExecutionsButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TeamReport = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\..\..\AllPages\TechAdminPages\AdminMenuPage.xaml"
            this.TeamReport.Click += new System.Windows.RoutedEventHandler(this.TeamReport_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

