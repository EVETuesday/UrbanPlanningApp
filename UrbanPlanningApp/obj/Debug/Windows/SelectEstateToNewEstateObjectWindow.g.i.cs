﻿#pragma checksum "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DA128ADA69E48B07D10335A5EFF8BA4A84832123506E0716847CE867E64A186E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using UrbanPlanningApp.Windows;


namespace UrbanPlanningApp.Windows {
    
    
    /// <summary>
    /// SelectEstateToNewEstateObjectWindow
    /// </summary>
    public partial class SelectEstateToNewEstateObjectWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbHeaderUser;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LvEstateList;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnInfo;
        
        #line default
        #line hidden
        
        
        #line 220 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/UrbanPlanningApp;component/windows/selectestatetonewestateobjectwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
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
            this.tbHeaderUser = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.LvEstateList = ((System.Windows.Controls.ListView)(target));
            
            #line 38 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
            this.LvEstateList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LvEstateList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnInfo = ((System.Windows.Controls.Button)(target));
            
            #line 217 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
            this.btnInfo.Click += new System.Windows.RoutedEventHandler(this.btnInfo_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 229 "..\..\..\Windows\SelectEstateToNewEstateObjectWindow.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

