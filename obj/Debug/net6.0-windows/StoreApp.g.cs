﻿#pragma checksum "..\..\..\StoreApp.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53BE22AAF73CD588CFF23DDCCA53C8B0952425BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using programowanieIVprojekt;


namespace programowanieIVprojekt {
    
    
    /// <summary>
    /// StoreApp
    /// </summary>
    public partial class StoreApp : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\StoreApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox search;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\StoreApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid data_products;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\StoreApp.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button admin_panel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/programowanieIVprojekt;component/storeapp.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StoreApp.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\StoreApp.xaml"
            ((programowanieIVprojekt.StoreApp)(target)).Closed += new System.EventHandler(this.storeApp_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.search = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\..\StoreApp.xaml"
            this.search.GotFocus += new System.Windows.RoutedEventHandler(this.search_GotFocus);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\StoreApp.xaml"
            this.search.KeyDown += new System.Windows.Input.KeyEventHandler(this.search_Handler);
            
            #line default
            #line hidden
            return;
            case 3:
            this.data_products = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 21 "..\..\..\StoreApp.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.logout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.admin_panel = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\StoreApp.xaml"
            this.admin_panel.Click += new System.Windows.RoutedEventHandler(this.button_AdminPanel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

