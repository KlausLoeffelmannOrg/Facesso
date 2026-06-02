using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ActiveDev.Controls
{
    [CLSCompliant(true)]
    public class ADNullableValueControls : Collection<IADNullableValueControl>
    {
        public static ADNullableValueControls FromContainerControl(Control cControl)
        {
            return FromContainerControlInternal(new ADNullableValueControls(), cControl);
        }

        private static ADNullableValueControls FromContainerControlInternal(ADNullableValueControls nullableControls, Control cControl)
        {
            foreach (Control c in cControl.Controls)
            {
                if (c.GetType().GetInterface(typeof(IADNullableValueControl).Name) != null)
                {
                    nullableControls.Add(((IADNullableValueControl)c));
                }

                if (c.HasChildren)
                {
                    FromContainerControlInternal(nullableControls, ((Control)c));
                }
            }

            return nullableControls;
        }

        public string CheckForNotAllowedNullValues()
        {
            string locString = "";
            foreach (IADNullableValueControl ic in this)
            {
                if (ic.NullValueMessage != null)
                {
                    if (ic.NullValueMessage != "")
                    {
                        if (ic.Value.IsNull)
                        {
                            locString += "* " + ic.Text + " " + ic.NullValueMessage + System.Environment.NewLine + System.Environment.NewLine;
                        }
                    }
                }
            }

            if (locString == "")
            {
                return null;
            }
            else
            {
                return locString;
            }
        }
    }
}