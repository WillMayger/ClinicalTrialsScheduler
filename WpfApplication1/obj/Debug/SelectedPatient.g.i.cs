﻿#pragma checksum "..\..\SelectedPatient.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "18EE8F71C2DA6FF8D86FD39507BBB2D4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using NHSApplication;
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


namespace NHSApplication {
    
    
    /// <summary>
    /// SelectedPatient
    /// </summary>
    public partial class SelectedPatient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\SelectedPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock clinicalTrialsScheduler;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\SelectedPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock patientName;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\SelectedPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button saveNotesBtn;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\SelectedPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNotes;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\SelectedPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\SelectedPatient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editPatientBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/NHSApplication;component/selectedpatient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SelectedPatient.xaml"
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
            this.clinicalTrialsScheduler = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.patientName = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.saveNotesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\SelectedPatient.xaml"
            this.saveNotesBtn.Click += new System.Windows.RoutedEventHandler(this.OnSave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBoxNotes = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.exitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\SelectedPatient.xaml"
            this.exitBtn.Click += new System.Windows.RoutedEventHandler(this.exitOnClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.editPatientBtn = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\SelectedPatient.xaml"
            this.editPatientBtn.Click += new System.Windows.RoutedEventHandler(this.editPatientOnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

