﻿#pragma checksum "..\..\SurveyManager.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5803278CAAC0FC677E7D9F8490B61D32"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HololensPrototype;
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


namespace HololensPrototype {
    
    
    /// <summary>
    /// SurveyManager
    /// </summary>
    public partial class SurveyManager : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\SurveyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HololensPrototype.SurveyManager SurveyWindow;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\SurveyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadSurvery;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\SurveyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid SurveyGrid;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\SurveyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteSurveyFiles;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\SurveyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SendSurvey;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\SurveyManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MainMenu;
        
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
            System.Uri resourceLocater = new System.Uri("/HololensPrototype;component/surveymanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SurveyManager.xaml"
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
            this.SurveyWindow = ((HololensPrototype.SurveyManager)(target));
            
            #line 8 "..\..\SurveyManager.xaml"
            this.SurveyWindow.Loaded += new System.Windows.RoutedEventHandler(this.windowLoaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UploadSurvery = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\SurveyManager.xaml"
            this.UploadSurvery.Click += new System.Windows.RoutedEventHandler(this.UploadSurvery_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SurveyGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.DeleteSurveyFiles = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\SurveyManager.xaml"
            this.DeleteSurveyFiles.Click += new System.Windows.RoutedEventHandler(this.DeleteSurveyFiles_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SendSurvey = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\SurveyManager.xaml"
            this.SendSurvey.Click += new System.Windows.RoutedEventHandler(this.SendSurvey_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MainMenu = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\SurveyManager.xaml"
            this.MainMenu.Click += new System.Windows.RoutedEventHandler(this.MainMenu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

