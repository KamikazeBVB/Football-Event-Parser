﻿#pragma checksum "..\..\..\ImageCreator.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "42D5FB6CCE2CB2C9CA58EBFC792E03F4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
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


namespace FootballManagerUI {
    
    
    /// <summary>
    /// ImageCreator
    /// </summary>
    public partial class ImageCreator : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox imageList;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar buildProgress;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock progressText;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stackPanel2;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox drawGraphsBtn;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox parallelsBtn;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox parsePossesionBtn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton firstHalfRBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton secondHalfRBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\ImageCreator.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/FootballManagerUI;component/imagecreator.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ImageCreator.xaml"
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
            this.imageList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.buildProgress = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 3:
            this.progressText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.stackPanel2 = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.drawGraphsBtn = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.parallelsBtn = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.parsePossesionBtn = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.firstHalfRBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 25 "..\..\..\ImageCreator.xaml"
            this.firstHalfRBtn.Checked += new System.Windows.RoutedEventHandler(this.firstHalfRBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.secondHalfRBtn = ((System.Windows.Controls.RadioButton)(target));
            
            #line 26 "..\..\..\ImageCreator.xaml"
            this.secondHalfRBtn.Checked += new System.Windows.RoutedEventHandler(this.firstHalfRBtn_Checked);
            
            #line default
            #line hidden
            return;
            case 10:
            this.createBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\ImageCreator.xaml"
            this.createBtn.Click += new System.Windows.RoutedEventHandler(this.createBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
