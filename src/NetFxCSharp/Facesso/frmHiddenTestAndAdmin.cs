using ActiveDevelop.EntitiesFormsLib;
using Facesso.EntityModel;
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
    public partial class frmHiddenTestAndAdmin
    {
        private static readonly System.DateTime DEFAULTFROMSTART = new System.DateTime(2010, 1, 1);
        private static readonly System.DateTime DEFAULTFROMEND = new System.DateTime(2010, 3, 31);
        public frmHiddenTestAndAdmin()
        {
            // This call is required by the designer.
            InitializeComponent();
            // Add any initialization after the InitializeComponent() call.
            this.FromStartNullableDateValue.Value = DEFAULTFROMSTART;
            this.ToStartNullableDateValue.Value = DEFAULTFROMEND;
            //Erste des aktuellen Monats
            this.ToEndNullableDateValue.Value = new System.DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);
            PassCaptionLabel.Text = "";
        }

        private void OKButton_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void ToEndNullableDateValue_IsDirtyChanged(object sender, System.EventArgs e)
        {
            MessageBox.Show("DirtyChanged", "test");
        }

        //TODO: Soll diese Funktionalit�t nicht besser in den DataLayer (Entity?)
        private void CopyNowButton_Clck(System.Object sender, System.EventArgs e)
        {
            //Schauen, ob Daten im Bereich vorhanden sind
            var productionDataExist = false;
            var timeDataExist = false;
            FacessoEntities facEnt = new FacessoEntities(FacessoGeneric.SqlEntityConnectionString);
            if (!(ToEndNullableDateValue.Value.HasValue) || !(FromStartNullableDateValue.Value.HasValue) || !(ToStartNullableDateValue.Value.HasValue))
            {
                MessageBox.Show("Bitte w�hlen Sie g�ltige Datumswerte!");
                return;
            }

            var toEndValue = ToEndNullableDateValue.Value.Value;
            productionDataExist = (facEnt.ProductionDatas.Where(item => item.ProductionDate >= toEndValue).Count()) > 0;
            timeDataExist = (facEnt.TimeLogs.Where(item => item.ProductionDate >= toEndValue).Count()) > 0;
            //Meldung f�r das L�schen aufbauen
            var message = "Facesso hat festgestellt, dass ab dem Zielbereich (" + ToEndNullableDateValue.Value.Value.ToLongDateString() + ") ";
            if (productionDataExist)
            {
                message += "Produktionsdaten";
            }

            if (productionDataExist & timeDataExist)
            {
                message += " und ";
            }

            if (timeDataExist)
            {
                message += "Zeitbuchungsdaten";
            }

            message += " existieren. Sollen diese Daten gel�scht werden?";
            if (productionDataExist | timeDataExist)
            {
                //Sicherheitsabfrage
                var retmb = MessageBox.Show(message, "Vorhandene Daten:", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (retmb == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                PassCaptionLabel.Text = "Zeitdaten ab Einf�gezeitpunkt l�schen...";
                PassCaptionLabel.Refresh();
                //Die l�schen wir direkt - geht schneller
                facEnt.ExecuteStoreCommand("Delete from TimeLog Where [ProductionDate]>=Convert(datetime,{0},104)", toEndValue.ToString("dd.MM.yyyy"));
                PassCaptionLabel.Text = "Mengendaten ab Einf�gezeitpunkt l�schen...";
                PassCaptionLabel.Refresh();
                //Die l�schen wir �ber das Entity-Modell.
                var prodDataToDelete = ((
                    from prodItem in facEnt.ProductionDatas
                    where prodItem.ProductionDate >= toEndValue
                    select prodItem)).ToList();
                foreach (var prodItem in prodDataToDelete)
                {
                    CopyInfoLabel.Text = prodItem.ProductionDate.ToLongDateString();
                    CopyInfoLabel.Refresh();
                    facEnt.ExecuteStoreCommand("Delete from ProductionDataItems Where [IDProductionData]={0}", prodItem.IDProductionData);
                    facEnt.DeleteObject(prodItem);
                }

                facEnt.SaveChanges();
            }

            //Und jetzt beginnen wir die Werte zu kopieren
            var currentDate = FromStartNullableDateValue.Value.Value;
            var endDate = ToStartNullableDateValue.Value.Value;
            var daysOffset = System.Convert.ToInt32((ToEndNullableDateValue.Value.Value - currentDate).TotalDays);
            FacessoEntities targetFacEntity = new FacessoEntities(FacessoGeneric.SqlEntityConnectionString);
            var changed = false;
            CopyProgressBar.Maximum = System.Convert.ToInt32((endDate - currentDate).TotalDays);
            var daysCount = 0;
            while (currentDate < endDate)
            {
                CopyProgressBar.Value = daysCount;
                CopyProgressBar.Refresh();
                CopyInfoLabel.Text = currentDate.ToLongDateString();
                CopyInfoLabel.Refresh();
                //Zuerst die Produktionsdaten kopieren
                PassCaptionLabel.Text = "Produktionsdaten verarbeiten:";
                PassCaptionLabel.Refresh();
                var prodData = ((
                    from prodItem in facEnt.ProductionDatas
                    where prodItem.ProductionDate == currentDate
                    select prodItem)).ToList();
                changed = prodData.Count > 0;
                foreach (var prodDataItem in prodData)
                {
                    prodDataItem.ProductionDataItems.Load();
                    var prodDataItems = (prodDataItem.ProductionDataItems).ToList();
                    foreach (var pdi in prodDataItems)
                    {
                        facEnt.Detach(pdi);
                    }

                    var entCopy = prodDataItem;
                    facEnt.Detach(entCopy);
                    entCopy.ProductionDate = currentDate.AddDays(daysOffset);
                    foreach (var pdi in prodDataItems)
                    {
                        entCopy.ProductionDataItems.Add(pdi);
                    }

                    Application.DoEvents();
                    targetFacEntity.ProductionDatas.AddObject(entCopy);
                }

                if (changed)
                {
                    targetFacEntity.SaveChanges();
                }

                PassCaptionLabel.Text = "Zeitdaten verarbeiten:";
                PassCaptionLabel.Refresh();
                var timeLogData = ((
                    from timeItem in facEnt.TimeLogs
                    where timeItem.ProductionDate == currentDate
                    select timeItem)).ToList();
                changed = timeLogData.Count > 0;
                foreach (var timeItem in timeLogData)
                {
                    var entCopy = timeItem;
                    facEnt.Detach(entCopy);
                    entCopy.ProductionDate = currentDate.AddDays(daysOffset);
                    targetFacEntity.TimeLogs.AddObject(entCopy);
                    Application.DoEvents();
                }

                if (changed)
                {
                    targetFacEntity.SaveChanges();
                }

                currentDate = currentDate.AddDays(1);
                daysCount += 1;
            }
        }

        private void DisplayLogmessage(string Message)
        {
        }

        private void btnNamenAnonymisieren_Click(System.Object sender, System.EventArgs e)
        {
            FacessoEntities facEnt = new FacessoEntities(FacessoGeneric.SqlEntityConnectionString);
            var allEmployees = ((
                from empItems in facEnt.Employees
                select empItems)).ToList();
            var demoContacts = DemoContact.RandomContacts(allEmployees.Count);
            var count = 0;
            foreach (var item in allEmployees)
            {
                item.FirstName = demoContacts[count].FirstName;
                item.LastName = demoContacts[count].LastName;
                item.PersonnelNumber = count + 10000;
                count += 1;
                item.AddressDetail.FirstName = item.FirstName;
                item.AddressDetail.LastName = item.LastName;
            }

            facEnt.SaveChanges();
        }
    }
}
