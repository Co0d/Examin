﻿#pragma checksum "..\..\..\Windows\AddInsuranceWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "035B05389DE46E1533C0BCC7165816AAF52F91E5435F1E68396AAED727F2E18D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LabApp.Windows;
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


namespace LabApp.Windows {
    
    
    /// <summary>
    /// AddInsuranceWindow
    /// </summary>
    public partial class AddInsuranceWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Windows\AddInsuranceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameTxb;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\AddInsuranceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AddressTxb;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Windows\AddInsuranceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox INNTxb;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Windows\AddInsuranceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox KPPTxb;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\AddInsuranceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BIKTxb;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\AddInsuranceWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/LabApp;component/windows/addinsurancewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddInsuranceWindow.xaml"
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
            this.NameTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.AddressTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.INNTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.KPPTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BIKTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Windows\AddInsuranceWindow.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.Add_Insurance);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

