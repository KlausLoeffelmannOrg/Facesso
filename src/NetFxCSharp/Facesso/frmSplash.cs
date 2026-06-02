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

namespace Facesso
{
    public partial class frmSplash
    {
        //TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
        //  of the Project Designer ("Properties" under the "Project" menu).
        private void frmSplash_Load(object sender, System.EventArgs e)
        {
            //Set up the dialog text at runtime according to the application's assembly information.
            //Format the version information using the text set into the Version control at design time as the
            //  formatting string.  This allows for effective localization if desired.
            //  Build and revision information could be included by using the following code and changing the
            //  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
            //  String.Format() in Help for more information.
            //
            Version.Text = System.String.Format(Version.Text, Facesso.My.MyProject.Application.Info.Version.Major, Facesso.My.MyProject.Application.Info.Version.Minor, Facesso.My.MyProject.Application.Info.Version.Build, Facesso.My.MyProject.Application.Info.Version.Revision);
            //Copyright info
            Copyright.Text = Facesso.My.MyProject.Application.Info.Copyright;
        }

        public frmSplash()
        {
            this.Load += frmSplash_Load;
            InitializeComponent();
        }
    }
}