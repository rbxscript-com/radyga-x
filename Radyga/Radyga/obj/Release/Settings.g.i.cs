﻿#pragma checksum "..\..\Settings.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "15CC29DF2623A33EEE34D93499761233656236C659D4DADB7F0CD0AD2898FC42"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Radyga;
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


namespace Radyga {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 43 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox topmost;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox startanim;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button killrblx;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button multipleRblx;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button flyexec;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btoolsexec;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button speedexec;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox autoinject;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel dragPanel;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button exitBtn;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox puppyMilk;
        
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
            System.Uri resourceLocater = new System.Uri("/Radyga;component/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Settings.xaml"
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
            this.topmost = ((System.Windows.Controls.CheckBox)(target));
            
            #line 43 "..\..\Settings.xaml"
            this.topmost.Checked += new System.Windows.RoutedEventHandler(this.topmost_Checked);
            
            #line default
            #line hidden
            
            #line 43 "..\..\Settings.xaml"
            this.topmost.Unchecked += new System.Windows.RoutedEventHandler(this.topmost_Unchecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.startanim = ((System.Windows.Controls.CheckBox)(target));
            
            #line 44 "..\..\Settings.xaml"
            this.startanim.Checked += new System.Windows.RoutedEventHandler(this.autoattach_Checked);
            
            #line default
            #line hidden
            
            #line 44 "..\..\Settings.xaml"
            this.startanim.Unchecked += new System.Windows.RoutedEventHandler(this.startanim_Unchecked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.killrblx = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\Settings.xaml"
            this.killrblx.Click += new System.Windows.RoutedEventHandler(this.killrblx_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.multipleRblx = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\Settings.xaml"
            this.multipleRblx.Click += new System.Windows.RoutedEventHandler(this.multipleRblx_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.flyexec = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\Settings.xaml"
            this.flyexec.Click += new System.Windows.RoutedEventHandler(this.flyexec_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btoolsexec = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\Settings.xaml"
            this.btoolsexec.Click += new System.Windows.RoutedEventHandler(this.btoolsexec_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.speedexec = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\Settings.xaml"
            this.speedexec.Click += new System.Windows.RoutedEventHandler(this.speedexec_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.autoinject = ((System.Windows.Controls.CheckBox)(target));
            
            #line 51 "..\..\Settings.xaml"
            this.autoinject.Checked += new System.Windows.RoutedEventHandler(this.autoinject_Checked);
            
            #line default
            #line hidden
            
            #line 51 "..\..\Settings.xaml"
            this.autoinject.Unchecked += new System.Windows.RoutedEventHandler(this.autoinject_Unchecked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dragPanel = ((System.Windows.Controls.StackPanel)(target));
            
            #line 52 "..\..\Settings.xaml"
            this.dragPanel.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.dragPanel_MouseDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.exitBtn = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\Settings.xaml"
            this.exitBtn.Click += new System.Windows.RoutedEventHandler(this.exitBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.puppyMilk = ((System.Windows.Controls.CheckBox)(target));
            
            #line 54 "..\..\Settings.xaml"
            this.puppyMilk.Checked += new System.Windows.RoutedEventHandler(this.puppyMilk_Checked);
            
            #line default
            #line hidden
            
            #line 54 "..\..\Settings.xaml"
            this.puppyMilk.Unchecked += new System.Windows.RoutedEventHandler(this.puppyMilk_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

