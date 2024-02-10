﻿#pragma checksum "..\..\..\Frames\OrdersPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C969A2631A7F356B47E6ACE95D66EA600C915915AFEF706035C22CD60C544730"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using LabApp.Frames;
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


namespace LabApp.Frames {
    
    
    /// <summary>
    /// OrdersPage
    /// </summary>
    public partial class OrdersPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\Frames\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button InsuranceBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Frames\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PatientBtn;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Frames\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ServiceBtn;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Frames\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UserBtn;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Frames\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBtn;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Frames\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DellBtn;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Frames\OrdersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/LabApp;component/frames/orderspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Frames\OrdersPage.xaml"
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
            this.InsuranceBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\Frames\OrdersPage.xaml"
            this.InsuranceBtn.Click += new System.Windows.RoutedEventHandler(this.GoToIncurance);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PatientBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\Frames\OrdersPage.xaml"
            this.PatientBtn.Click += new System.Windows.RoutedEventHandler(this.GoToPatient);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ServiceBtn = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Frames\OrdersPage.xaml"
            this.ServiceBtn.Click += new System.Windows.RoutedEventHandler(this.GoToService);
            
            #line default
            #line hidden
            return;
            case 4:
            this.UserBtn = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Frames\OrdersPage.xaml"
            this.UserBtn.Click += new System.Windows.RoutedEventHandler(this.GoToUser);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AddBtn = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Frames\OrdersPage.xaml"
            this.AddBtn.Click += new System.Windows.RoutedEventHandler(this.AddOrder);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DellBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\Frames\OrdersPage.xaml"
            this.DellBtn.Click += new System.Windows.RoutedEventHandler(this.DellOrder);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
