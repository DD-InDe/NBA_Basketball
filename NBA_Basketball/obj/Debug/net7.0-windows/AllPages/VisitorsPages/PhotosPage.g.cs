﻿#pragma checksum "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F99D518B8CEFD31B3BCC50ABE81310181AA2CC85"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
    /// PhotosPage
    /// </summary>
    public partial class PhotosPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 34 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ImageListBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock PageInfoTextBlock;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FirstPageButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PreviousPageButton;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CurrentPageTextBox;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NextPageButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LastPageButton;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DownloadAll;
        
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
            System.Uri resourceLocater = new System.Uri("/NBA_Basketball;component/allpages/visitorspages/photospage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
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
            case 2:
            this.ImageListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.PageInfoTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.FirstPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            this.FirstPageButton.Click += new System.Windows.RoutedEventHandler(this.FirstPageButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PreviousPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            this.PreviousPageButton.Click += new System.Windows.RoutedEventHandler(this.PreviousPageButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CurrentPageTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            this.CurrentPageTextBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.CurrentPageTextBox_OnKeyUp);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            this.CurrentPageTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.CurrentPageTextBox_OnPreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NextPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            this.NextPageButton.Click += new System.Windows.RoutedEventHandler(this.NextPageButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 8:
            this.LastPageButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            this.LastPageButton.Click += new System.Windows.RoutedEventHandler(this.LastPageButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.DownloadAll = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            this.DownloadAll.Click += new System.Windows.RoutedEventHandler(this.DownloadAll_OnClick);
            
            #line default
            #line hidden
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
            case 1:
            
            #line 14 "..\..\..\..\..\AllPages\VisitorsPages\PhotosPage.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_OnClick);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}
