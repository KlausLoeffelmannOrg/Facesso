using System;
using System.Security.Cryptography;
using System.Windows.Forms;
using ActiveDev;

namespace ActiveDev
{
    public partial class frmMain : Form
    {
        private byte[] myLicenseInfo;
        private byte[] mySerialPart;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnQuitProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cmbProgramID.Items.Add(new ProgramIDItem("Facesso Standard V1.0", 1));
            cmbProgramID.Items.Add(new ProgramIDItem("Facesso Professional V1.0", 2));
            cmbProgramID.Items.Add(new ProgramIDItem("Facesso Enterprise V1.0", 3));
            cmbProgramID.Items.Add(new ProgramIDItem("Facesso Standard V2.0", 4));
            cmbProgramID.Items.Add(new ProgramIDItem("Facesso Professional V2.0", 5));
            cmbProgramID.Items.Add(new ProgramIDItem("Facesso Enterprise V2.0", 6));
            cmbProgramID.SelectedIndex = 0;
            mtbLimit1.Text = "10";
            mtbLimit2.Text = "10";
            mtbLimit3.Text = "50";
            mtbLimit4.Text = "255";
            mtbBestBefore.Text = "0";
            cmbProgramID.SelectedIndex = 5;
        }

        private void btnCalcSerial_Click(object sender, EventArgs e)
        {
            var locLicenseInfo = new ADLicenseInfo(
                ((ProgramIDItem)cmbProgramID.SelectedItem).ID,
                byte.Parse(mtbBestBefore.Text),
                byte.Parse(mtbLimit1.Text),
                byte.Parse(mtbLimit2.Text),
                ushort.Parse(mtbLimit3.Text),
                ushort.Parse(mtbLimit4.Text));

            ulong locULongLI = locLicenseInfo.CompleteStructure;
            System.Diagnostics.Debug.Print(locULongLI.ToString());
            myLicenseInfo = BitConverter.GetBytes(locULongLI);

            string locKeyString = (new ADNumberSystems(locULongLI, 20)).ToString(16) + DateTime.Now.ToString("ddMMyyyy");
            var locMACTripleDES = new MACTripleDES(ADCryptography.ToByteArray(locKeyString));
            string locPreSerial = mtbPreSerial.Text;
            mySerialPart = locMACTripleDES.ComputeHash(ADCryptography.ToByteArray(locPreSerial));

            string locComSerial = (new ADNumberSystems(BitConverter.ToUInt64(mySerialPart, 0), 20)).ToString(15);
            locULongLI = locULongLI ^ 0xFFEEDDCCBBAA9988UL;
            locComSerial += new ADNumberSystems(locULongLI, 20).ToString(15);
            string locFormattedSerial = "";
            int locCount = 0;
            foreach (char locChar in locComSerial)
            {
                if (locCount == 5)
                {
                    locCount = 0;
                    locFormattedSerial += " - ";
                }
                locFormattedSerial += locChar.ToString();
                locCount++;
            }

            txtSerialNumber.Text = locFormattedSerial;
            System.Windows.Forms.Clipboard.SetText(locFormattedSerial);
        }
    }

    internal class ProgramIDItem
    {
        private string myEntryText;
        private byte myID;

        public ProgramIDItem(string entryText, byte id)
        {
            myID = id;
            myEntryText = entryText;
        }

        public byte ID => myID;

        public override string ToString()
        {
            return string.Format("{0}: {1}", myID, myEntryText);
        }
    }
}
