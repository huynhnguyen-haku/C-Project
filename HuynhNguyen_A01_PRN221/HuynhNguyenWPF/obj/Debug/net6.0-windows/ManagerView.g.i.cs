﻿#pragma checksum "..\..\..\ManagerView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FA4006BC56FD97D66BFC10CAE8864BC5573C92B0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HuynhNguyenWPF;
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


namespace HuynhNguyenWPF {
    
    
    /// <summary>
    /// ManagerView
    /// </summary>
    public partial class ManagerView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserDisplayName;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CarBtn;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OrderBtn;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ReportBtn;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LogoutBtn;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border CarManagement;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchValueCar;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CarSearchType;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView CarView;
        
        #line default
        #line hidden
        
        
        #line 247 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border OrderManagement;
        
        #line default
        #line hidden
        
        
        #line 363 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView OrderView;
        
        #line default
        #line hidden
        
        
        #line 390 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView OrderDetailView;
        
        #line default
        #line hidden
        
        
        #line 407 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ReportManagement;
        
        #line default
        #line hidden
        
        
        #line 411 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ReportStart;
        
        #line default
        #line hidden
        
        
        #line 442 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker ReportEnd;
        
        #line default
        #line hidden
        
        
        #line 470 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ReportView;
        
        #line default
        #line hidden
        
        
        #line 493 "..\..\..\ManagerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalProfit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HuynhNguyenWPF;component/managerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ManagerView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\ManagerView.xaml"
            ((HuynhNguyenWPF.ManagerView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Awake);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserDisplayName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.CarBtn = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\ManagerView.xaml"
            this.CarBtn.Click += new System.Windows.RoutedEventHandler(this.OnClickCar);
            
            #line default
            #line hidden
            return;
            case 4:
            this.OrderBtn = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\ManagerView.xaml"
            this.OrderBtn.Click += new System.Windows.RoutedEventHandler(this.OnClickOrder);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ReportBtn = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\ManagerView.xaml"
            this.ReportBtn.Click += new System.Windows.RoutedEventHandler(this.OnClickReport);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LogoutBtn = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\ManagerView.xaml"
            this.LogoutBtn.Click += new System.Windows.RoutedEventHandler(this.OnClickLogout);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CarManagement = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            
            #line 72 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickSearchCar);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SearchValueCar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.CarSearchType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            
            #line 111 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickShowAllCar);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 138 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickDeleteCar);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 165 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickUpdateCar);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 192 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickAddNewCar);
            
            #line default
            #line hidden
            return;
            case 15:
            this.CarView = ((System.Windows.Controls.ListView)(target));
            
            #line 221 "..\..\..\ManagerView.xaml"
            this.CarView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnSelectionChangedCar);
            
            #line default
            #line hidden
            return;
            case 16:
            this.OrderManagement = ((System.Windows.Controls.Border)(target));
            return;
            case 17:
            
            #line 251 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickShowAllOrder);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 278 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickDeleteOrder);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 305 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickUpdateOrder);
            
            #line default
            #line hidden
            return;
            case 20:
            
            #line 332 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickAddNewOrder);
            
            #line default
            #line hidden
            return;
            case 21:
            this.OrderView = ((System.Windows.Controls.ListView)(target));
            
            #line 364 "..\..\..\ManagerView.xaml"
            this.OrderView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnChangeSelectedOrder);
            
            #line default
            #line hidden
            return;
            case 22:
            this.OrderDetailView = ((System.Windows.Controls.ListView)(target));
            return;
            case 23:
            this.ReportManagement = ((System.Windows.Controls.Border)(target));
            return;
            case 24:
            this.ReportStart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 25:
            
            #line 413 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickSearchReport);
            
            #line default
            #line hidden
            return;
            case 26:
            this.ReportEnd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 27:
            
            #line 444 "..\..\..\ManagerView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OnClickSortReport);
            
            #line default
            #line hidden
            return;
            case 28:
            this.ReportView = ((System.Windows.Controls.ListView)(target));
            
            #line 471 "..\..\..\ManagerView.xaml"
            this.ReportView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnChangeSelectedOrder);
            
            #line default
            #line hidden
            return;
            case 29:
            this.TotalProfit = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

