﻿#pragma checksum "..\..\..\..\Views\EditCreateView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "AB9395B2A5C2DFF86E48430861C9AE9766652CD7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Quiz.ViewModels;
using Quiz.Views;
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


namespace Quiz.Views {
    
    
    /// <summary>
    /// CreateView
    /// </summary>
    public partial class CreateView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateSubmitBtn;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuizTitleTextblock;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox QuizTitleTb;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StatementTb;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Answer1Tb;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Answer2Tb;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Answer3Tb;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\..\..\Views\EditCreateView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CorrectAnswerTb;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Quiz;component/views/editcreateview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\EditCreateView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.CreateSubmitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Views\EditCreateView.xaml"
            this.CreateSubmitBtn.Click += new System.Windows.RoutedEventHandler(this.CreateSubmitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.QuizTitleTextblock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.QuizTitleTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.StatementTb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Answer1Tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Answer2Tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Answer3Tb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CorrectAnswerTb = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
