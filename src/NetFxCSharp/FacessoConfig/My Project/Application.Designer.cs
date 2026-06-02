using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FacessoConfig.My
{
    //NOTE: This file is auto-generated; do not modify it directly.  To make changes,
    // or if you encounter build errors in this file, go to the Project Designer
    // (go to Project Properties or double-click the My Project node in
    // Solution Explorer), and make changes on the Application tab.
    //
    internal partial class MyApplication : global::Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
    {
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public MyApplication() : base(global::Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
        {
            this.Shutdown += MyApplication_Shutdown;
            this.Startup += MyApplication_Startup;
            this.UnhandledException += MyApplication_UnhandledException;
            this.IsSingleInstance = false;
            this.EnableVisualStyles = true;
            this.SaveMySettingsOnExit = true;
            this.ShutdownStyle = global::Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses;
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        protected override void OnCreateMainForm()
        {
            this.MainForm = new global::FacessoConfig.frmMain();
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        protected override bool OnInitialize(System.Collections.ObjectModel.ReadOnlyCollection<string> commandLineArgs)
        {
            this.MinimumSplashScreenDisplayTime = 0;
            return base.OnInitialize(commandLineArgs);
        }
    }
}