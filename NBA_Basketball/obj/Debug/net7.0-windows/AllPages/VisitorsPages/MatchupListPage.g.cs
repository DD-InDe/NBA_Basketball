﻿#pragma checksum "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99148AAC4C7B0116DD1CFC06D0F5156F7D0898C6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NBA_Basketball.AllPages.VisitorsPages;
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


namespace NBA_Basketball.AllPages.VisitorsPages {
    
    
    /// <summary>
    /// MatchupListPage
    /// </summary>
    public partial class MatchupListPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 23 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker MatchDatePicker;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextButton;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel LastMatchStackPanel;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DataTextBlock;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MatchesDataGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/NBA_Basketball;component/allpages/visitorspages/matchuplistpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
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
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MatchDatePicker = ((System.Windows.Controls.DatePicker)(target));
            
            #line 27 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
            this.MatchDatePicker.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.MatchDatePicker_OnSelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.NextButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
            this.NextButton.Click += new System.Windows.RoutedEventHandler(this.NextButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.LastMatchStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.DataTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.MatchesDataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 100 "..\..\..\..\..\AllPages\VisitorsPages\MatchupListPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ViewButton_OnClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

