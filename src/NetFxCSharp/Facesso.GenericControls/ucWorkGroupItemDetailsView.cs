using ActiveDev;
using Facesso.Data;
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

namespace Facesso.GenericControls
{
    public class ucWorkGroupItemDetailsView : ucObjectContentDataGridView<WorkGroupAnalysisInfoItem>
    {
        protected override void AssignValues()
        {
            if (Object.HasData)
            {
                this.Rows.Add(new object[] { "Referenzzeit", Object.TotalReferenceIWT });
                this.Rows.Add(new object[] { "Effektivzeit", Object.TotalEffectiveIWT });
                this.Rows.Add(new object[] { "Ang. Effektivzeit", Object.TotalEffectiveIWTAdj });
                this.Rows.Add(new object[] { "Gesamt-Pausenzeit", Object.TotalWorkBreakTime });
                this.Rows.Add(new object[] { "Gesamt-Ausfallzeit", Object.TotalDownTime });
                this.Rows.Add(new object[] { Object.WorkGroup.IncentiveIndicatorSynonym, Object.DegreeOfTime.ToString(Object.WorkGroup.IncentiveFormatString) });
                this.Rows.Add(new object[] { "Ang. " + Object.WorkGroup.IncentiveIndicatorSynonym, Object.DegreeOfTimeAdj.ToString(Object.WorkGroup.IncentiveFormatString) });
                this.Rows.Add(new object[] { "Ist ausgesetzt", Microsoft.VisualBasic.Interaction.IIf(Object.IsSuspended, "Ja", "Nein").ToString() });
            }
            else
            {
                this.Rows.Add(new object[] { "Referenzzeit", "- - -" });
                this.Rows.Add(new object[] { "Effektivzeit", "- - -" });
                this.Rows.Add(new object[] { "Ang. Effektivzeit", "- - -" });
                this.Rows.Add(new object[] { "Gesamt-Pausenzeit", "- - -" });
                this.Rows.Add(new object[] { "Gesamt-Ausfallzeit", "- - -" });
                this.Rows.Add(new object[] { Object.WorkGroup.IncentiveIndicatorSynonym, "- - -" });
                this.Rows.Add(new object[] { "Ang. " + Object.WorkGroup.IncentiveIndicatorSynonym, "- - -" });
                this.Rows.Add(new object[] { "Ist ausgesetzt", "- - -" });
            }
        }
    }
}