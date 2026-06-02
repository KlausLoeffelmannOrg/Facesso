using Facesso.Data;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso.Functions
{
    //HACK: Hier die Funktionalität für den Handicap-Manager einbauen
    public partial class frmHandicapRangeManager
    {
        private EmployeeInfo myEmployee;
        private DataTable myHandicapDataTable;
        public DialogResult ShowDialog(EmployeeInfo e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("Interner Fehler: Es wurde bei frmHandicapRangeManager kein Mitarbeiter angegeben.");
            }

            myEmployee = e;
            lblEmployee.Text = e.DisplayName;
            //Demo: Subsidary (Abteilung, Filliale, Mandant. etc.) ermitteln
            var si = FacessoGeneric.LoginInfo.SubsidiaryInfo;
            //(würd aber auch in EmployeeInfo stehen hahahahaha)
            ListView1.MultiSelect = false;
            LoadHandicaps();
            return base.ShowDialog();
        }

        private void LoadHandicaps()
        {
            var selCmd = "Select * from EmployeeHandicaps where IDSubsidiary=@SUBSID and IDEmployee=@EMPID order by validfrom";
            SqlConnection con = new SqlConnection(FacessoGeneric.SQLConnectionString);
            using (con)
            {
                con.Open();
                myHandicapDataTable = new DataTable("EmployeeHandicaps");
                var cmd = con.CreateCommand();
                cmd.CommandText = selCmd;
                cmd.CommandType = CommandType.Text;
                SqlParameter p = new SqlParameter("@SUBSID", myEmployee.IDSubsidiary);
                cmd.Parameters.Add(p);
                p = new SqlParameter("@EMPID", myEmployee.IDEmployee);
                cmd.Parameters.Add(p);
                using (var reader = cmd.ExecuteReader())
                {
                    myHandicapDataTable.Load(reader);
                }

                FillListViewFromDataTable();
            }
        }

        private void FillListViewFromDataTable()
        {
            ListView1.Items.Clear();
            //Tabelle neu Sortieren
            System.DateTime[] sortedvalidFroms = new System.DateTime[(myHandicapDataTable.Rows.Count - 1) + 1];
            int i = 0;
            foreach (DataRow row in myHandicapDataTable.Rows)
            {
                sortedvalidFroms[i] = System.Convert.ToDateTime(row["ValidFrom"]);
                i += 1;
            }

            Array.Sort(sortedvalidFroms);
            // nun sortiert in die Listview einfügen
            foreach (System.DateTime vf in sortedvalidFroms)
            {
                foreach (DataRow row in myHandicapDataTable.Rows)
                {
                    if (vf == System.Convert.ToDateTime(row["validfrom"]))
                    {
                        // der aktuelle Datensatz ist der richtige
                        string t = MapDataTable2ListView(row, "ValidFrom");
                        ListViewItem newLVIitem = new ListViewItem(t);
                        // row im Tag speichern
                        newLVIitem.Tag = row;
                        t = MapDataTable2ListView(row, "Handicap");
                        newLVIitem.SubItems.Add(t);
                        ListView1.Items.Add(newLVIitem);
                    }
                }
            }

            SetDeps();
        }

        private string MapDataTable2ListView(DataRow row, string column)
        {
            if (row[column].GetType() == typeof(DBNull))
            {
                return null;
            }
            else if (row[column].GetType() == typeof(System.DateTime))
            {
                return System.Convert.ToDateTime(row[column]).ToShortDateString();
            }
            else
            {
                return row[column].ToString();
            }

            return default(string);
        }

        private void SetDeps()
        {
            bool enNew = false;
            bool enEdit = false;
            bool enDel = false;
            if (myEmployee == null)
            {
            }
            else
            {
                enNew = true;
                if (ListView1.SelectedIndices.Count > 0)
                {
                    // es ist etwas ausgewählt
                    enDel = true;
                    enEdit = true;
                }
            }

            btnNew.Enabled = enNew;
            btnEdit.Enabled = enEdit;
            btnDelete.Enabled = enDel;
        }

        private void ListView1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (ListView1.MultiSelect)
            {
                throw new NotSupportedException("interner Fehler: Multiselect wird nicht unterstützt");
            }

            SetDeps();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void btnOk_Click(System.Object sender, System.EventArgs e)
        {
            bool hasZeroHandicap = false;
            foreach (DataRow row in myHandicapDataTable.Rows)
            {
                if (System.Convert.ToDouble(row["Handicap"]) == 0)
                {
                    hasZeroHandicap = true;
                }
            }

            if (!(hasZeroHandicap) & myHandicapDataTable.Rows.Count > 0)
            {
                //TODO: Fehlermeldung gemäss Facesso-Fehler ausgeben
                MessageBox.Show("Es muss ein Datensatz mit dem Handicap 0 geben.", "Hinweis");
                return;
            }

            SqlConnection con = null;
            SqlTransaction trans = null;
            try
            {
                con = new SqlConnection(FacessoGeneric.SQLConnectionString);
                con.Open();
                trans = con.BeginTransaction();
                var delCmd = con.CreateCommand();
                delCmd.Transaction = trans;
                delCmd.CommandText = "Delete from EmployeeHandicaps where IDSubsidiary=@SUBSID and IDEmployee=@EMPID";
                delCmd.CommandType = CommandType.Text;
                SqlParameter p = new SqlParameter("@SUBSID", myEmployee.IDSubsidiary);
                delCmd.Parameters.Add(p);
                p = new SqlParameter("@EMPID", myEmployee.IDEmployee);
                delCmd.Parameters.Add(p);
                delCmd.ExecuteNonQuery();
                delCmd.Dispose();
                var insCmd = con.CreateCommand();
                insCmd.Transaction = trans;
                insCmd.CommandText = "Insert into EmployeeHandicaps (IDSubsidiary,IDEmployee,ValidFrom,Handicap) Values(@SUBSID,@EMPID,@ValidFrom,@Handicap)";
                insCmd.CommandType = CommandType.Text;
                foreach (DataRow row in myHandicapDataTable.Rows)
                {
                    insCmd.Parameters.Clear();
                    p = new SqlParameter("@SUBSID", myEmployee.IDSubsidiary);
                    insCmd.Parameters.Add(p);
                    p = new SqlParameter("@EMPID", myEmployee.IDEmployee);
                    insCmd.Parameters.Add(p);
                    var valFrom = System.Convert.ToDateTime(row["ValidFrom"]);
                    p = new SqlParameter("@ValidFrom", valFrom.Date);
                    insCmd.Parameters.Add(p);
                    var handi = System.Convert.ToDouble(row["handicap"]);
                    p = new SqlParameter("@Handicap", handi);
                    insCmd.Parameters.Add(p);
                    insCmd.ExecuteNonQuery();
                }

                trans.Commit();
                trans = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Speichern der Handicaps:" + ex.Message, "Fehler");
                if (trans != null)
                {
                    trans.Rollback();
                    trans = null;
                }
            }
            finally
            {
                if (trans != null)
                {
                    trans.Rollback();
                    trans = null;
                }

                if (con != null)
                {
                    con.Close();
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void ShowNewEditDialog(object sender, EventArgs e)
        {
            if (ListView1.MultiSelect)
            {
                throw new NotSupportedException("interner Fehler: Multiselect wird nicht unterstützt");
            }

            frmEmpoyeeHandicapAddEditView frmNewEdit = new frmEmpoyeeHandicapAddEditView();
            string emptext = lblEmployee.Text;
            DataRow useRow = null;
            bool isNewRow = false;
            if (sender == btnNew)
            {
                useRow = myHandicapDataTable.NewRow();
                isNewRow = true;
            }
            else if (sender == btnEdit)
            {
                useRow = ((DataRow)ListView1.SelectedItems[0].Tag);
            }

            var ret = frmNewEdit.ShowDialog(emptext, useRow, myHandicapDataTable.Rows);
            if (ret == System.Windows.Forms.DialogResult.OK)
            {
                // Daten übernehmen
                if (isNewRow)
                {
                    useRow["IDEmployee"] = myEmployee.IDEmployee;
                    useRow["IDSubsidiary"] = myEmployee.IDSubsidiary;
                    myHandicapDataTable.Rows.Add(useRow);
                }

                FillListViewFromDataTable();
            }
        }

        private void ListView1_DoubleClick(System.Object sender, System.EventArgs e)
        {
            if (ListView1.SelectedItems.Count > 0)
            {
                ShowNewEditDialog(btnEdit, e);
            }
        }

        private void btnNew_Click(System.Object sender, System.EventArgs e)
        {
            ShowNewEditDialog(sender, e);
        }

        private void btnEdit_Click(System.Object sender, System.EventArgs e)
        {
            ShowNewEditDialog(sender, e);
        }

        //Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        //    Dim checkdate As Date = Date.Now
        //    Stop
        //    Dim res = GetHandicapFromDate(myEmployee, checkdate)
        //    Debug.WriteLine("Handicap für " & myEmployee.DisplayName & "; " & checkdate.ToString & "=" & res.ToString)
        //End Sub
        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            if (ListView1.MultiSelect)
            {
                throw new NotSupportedException("interner Fehler: Multiselect wird nicht unterstützt");
            }

            if (ListView1.SelectedItems.Count > 0)
            {
                var selrow = ((DataRow)ListView1.SelectedItems[0].Tag);
                myHandicapDataTable.Rows.Remove(selrow);
                FillListViewFromDataTable();
            }
        }

        public frmHandicapRangeManager()
        {
            InitializeComponent();
        }
    }
}