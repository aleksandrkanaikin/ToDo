﻿#pragma checksum "..\..\CreateTaskWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A62544B705B40E8FFBB62EC97EF3464BA66DF4CEFE670F2DCBBB320DBF131F86"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Desktop;
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


namespace Desktop {
    
    
    /// <summary>
    /// CreateTaskWindow
    /// </summary>
    public partial class CreateTaskWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\CreateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskNameTxb;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\CreateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskCategoryTxb;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\CreateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TaskDescriptionTxb;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\CreateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CreateTaskBtn;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\CreateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker TaskDate;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\CreateTaskWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Desktop;component/createtaskwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateTaskWindow.xaml"
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
            this.TaskNameTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TaskCategoryTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TaskDescriptionTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CreateTaskBtn = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\CreateTaskWindow.xaml"
            this.CreateTaskBtn.Click += new System.Windows.RoutedEventHandler(this.CreateTaskBtn_OnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TaskDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\CreateTaskWindow.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_OnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

