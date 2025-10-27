Public Class frmInfo

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub frmInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        'Copyright info
        Copyright.Text = My.Application.Info.Copyright
        lblSerial.Text = FacessoGeneric.SerialNumber
        Dim locExpires As String
        If FacessoGeneric.FacessoLicenseInfo.LicenseInfo.MonthsLimited = 0 Then
            locExpires = "Lizensiert für unbegrenzte Dauer"
        Else
            locExpires = FacessoGeneric.FacessoLicenseInfo.BestBefore.AddMonths(FacessoGeneric.FacessoLicenseInfo.LicenseInfo.MonthsLimited).ToLongDateString
        End If
        lblExpiresOn.Text = locExpires
        lblVersion.Text = FacessoGeneric.FacessoLicenseInfo.VersionPermissionInfo.FacessoVersion.ToString
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class
