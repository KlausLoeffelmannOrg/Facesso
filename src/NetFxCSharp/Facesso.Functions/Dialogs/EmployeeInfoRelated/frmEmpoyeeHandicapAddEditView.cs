using ActiveDev;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    public partial class frmEmpoyeeHandicapAddEditView
    {
        // TODO: Code zum Durchführen der benutzerdefinierten Authentifizierung mithilfe des angegebenen Benutzernamens und des Kennworts hinzufügen
        // (Siehe http://go.microsoft.com/fwlink/?LinkId=35339).
        // Der benutzerdefinierte Prinzipal kann anschließend wie folgt an den Prinzipal des aktuellen Threads angefügt werden:
        //     My.User.CurrentPrincipal = CustomPrincipal
        // wobei CustomPrincipal die IPrincipal-Implementierung ist, die für die Durchführung der Authentifizierung verwendet wird.
        // Anschließend gibt My.User Identitätsinformationen zurück, die in das CustomPrincipal-Objekt gekapselt sind,
        // z.B. den Benutzernamen, den Anzeigenamen usw.
        private void OK_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ValidateForm();
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message, "Hinweis");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
                return;
            }

            myRow2Edit["ValidFrom"] = dtpValidFrom.Value;
            // Double - Parsen : Das geht ohne TryParse, da der Wert bereits in ValidateFrom geprüft wurde
            myRow2Edit["Handicap"] = double.Parse(tbHandicap.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private System.DateTime? GetDateFromRow(DataRow row, string column)
        {
            if (row[column].GetType() == typeof(DBNull))
            {
                return null;
            }
            else if (row[column].GetType() == typeof(System.DateTime))
            {
                return System.Convert.ToDateTime(row[column]);
            }

            return default(System.DateTime? );
        }

        private DataRow myRow2Edit;
        private DataRowCollection myAllRows;
        public System.Windows.Forms.DialogResult ShowDialog(string empDisplayName, DataRow row2Edit, DataRowCollection allRows)
        {
            lblEmployee.Text = empDisplayName;
            myRow2Edit = row2Edit;
            myAllRows = allRows;
            if (GetDateFromRow(myRow2Edit, "ValidFrom").HasValue)
            {
                dtpValidFrom.Value = GetDateFromRow(myRow2Edit, "ValidFrom").Value;
            }
            else
            {
                // neuer Datensatz
                dtpValidFrom.Value = System.DateTime.Now;
            }

            if (row2Edit["Handicap"].GetType() == typeof(DBNull))
            {
                // neuer Datensatz
                tbHandicap.Text = "0";
            }
            else
            {
                tbHandicap.Text = row2Edit["Handicap"].ToString();
            }

            return base.ShowDialog();
        }

        private void ValidateForm()
        {
            double newHandicap = 0;
            bool handicapError = !(double.TryParse(tbHandicap.Text, out newHandicap));
            if (!(handicapError))
            {
                if (newHandicap < 0)
                {
                    handicapError = true;
                }
            }

            if (handicapError)
            {
                throw new InvalidDataException("Der angegebene Wert für das Handicap ist ungültig. Er muss numerisch und positiv sein.");
            }

            System.DateTime newValidFrom = dtpValidFrom.Value.Date;
            foreach (DataRow row in myAllRows)
            {
                if (row != myRow2Edit)
                {
                    if (newValidFrom == System.Convert.ToDateTime(row["validfrom"]))
                    {
                        throw new InvalidDataException("Es existiert bereits ein Handicap Eintrag für den " + newValidFrom.ToString());
                    }
                }
            }
        }

        private class InvalidDataException : Exception
        {
            public InvalidDataException(string msg) : base(msg)
            {
            }
        }

        public frmEmpoyeeHandicapAddEditView()
        {
            InitializeComponent();
        }
    }
}