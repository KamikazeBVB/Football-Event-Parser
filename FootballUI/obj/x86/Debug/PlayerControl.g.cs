﻿#pragma checksum "..\..\..\PlayerControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CC5285C5078BA074152BEABC130249B5"
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


namespace FootballUI {
    
    
    /// <summary>
    /// PlayerControl
    /// </summary>
    public partial class PlayerControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border playerBorder;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock playerID;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem passesTo;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem passesToPlayer;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem passesToSAR;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem passesLength;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem assignRoleMenu;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem attackRole;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem defenderRole;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem goalKeeperRole;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\PlayerControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem midfilderRole;
        
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
            System.Uri resourceLocater = new System.Uri("/FootballUI;component/playercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PlayerControl.xaml"
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
            this.playerBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.playerID = ((System.Windows.Controls.TextBlock)(target));
            
            #line 13 "..\..\..\PlayerControl.xaml"
            this.playerID.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.playerID_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\PlayerControl.xaml"
            this.playerID.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.playerBorder_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passesTo = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 4:
            this.passesToPlayer = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\PlayerControl.xaml"
            this.passesToPlayer.Click += new System.Windows.RoutedEventHandler(this.passesToPlayer_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.passesToSAR = ((System.Windows.Controls.MenuItem)(target));
            
            #line 18 "..\..\..\PlayerControl.xaml"
            this.passesToSAR.Click += new System.Windows.RoutedEventHandler(this.passesToSAR_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.passesLength = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\..\PlayerControl.xaml"
            this.passesLength.Click += new System.Windows.RoutedEventHandler(this.passesLength_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.assignRoleMenu = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 8:
            this.attackRole = ((System.Windows.Controls.MenuItem)(target));
            
            #line 21 "..\..\..\PlayerControl.xaml"
            this.attackRole.Click += new System.Windows.RoutedEventHandler(this.changeRole_OnClick);
            
            #line default
            #line hidden
            return;
            case 9:
            this.defenderRole = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\..\PlayerControl.xaml"
            this.defenderRole.Click += new System.Windows.RoutedEventHandler(this.changeRole_OnClick);
            
            #line default
            #line hidden
            return;
            case 10:
            this.goalKeeperRole = ((System.Windows.Controls.MenuItem)(target));
            
            #line 23 "..\..\..\PlayerControl.xaml"
            this.goalKeeperRole.Click += new System.Windows.RoutedEventHandler(this.changeRole_OnClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.midfilderRole = ((System.Windows.Controls.MenuItem)(target));
            
            #line 24 "..\..\..\PlayerControl.xaml"
            this.midfilderRole.Click += new System.Windows.RoutedEventHandler(this.changeRole_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

