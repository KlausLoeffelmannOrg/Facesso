using ActiveDev;
using ActiveDev.Controls;
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
    internal class Fac_FunctionsInternal
    {
        private Fac_FunctionsInternal()
        {
        }

        internal static void AddCostCentersToADNullableIdOrIndexComboBox(ADNullableIdOrIndexComboBox cb)
        {
            SqlConnection locSqlConn = new SqlConnection(FacessoGeneric.SQLConnectionString);
            locSqlConn.Open();
            using (locSqlConn)
            {
                SqlCommand locCommand = new SqlCommand("SELECT * From [Costcenters] WHERE [IDSubsidiary]=" + FacessoGeneric.LoginInfo.IDSubsidiary + " AND [IsCurrent]='true'", locSqlConn);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    while (locDR.Read())
                    {
                        ADComboBoxItem locItem = new ADComboBoxItem(locDR.GetInt32(locDR.GetOrdinal("IDCostCenter")), locDR.GetInt32(locDR.GetOrdinal("CostCenterNo")) + ": " + locDR.GetString(locDR.GetOrdinal("CostCenterName")));
                        cb.Items.Add(locItem);
                    }

                    ADNullableComboBoxValueType locT = cb.ComboBoxValueType;
                    cb.ComboBoxValueType = ADNullableComboBoxValueType.Index_As_Int32;
                    cb.TypeSafeValue = 0;
                    cb.ComboBoxValueType = locT;
                }
            }
        }

        internal static void AddCurrencyToADNullableIdOrIndexComboBox(ADNullableIdOrIndexComboBox cb)
        {
            SqlConnection locSqlConn = new SqlConnection(FacessoGeneric.SQLConnectionString);
            locSqlConn.Open();
            using (locSqlConn)
            {
                SqlCommand locCommand = new SqlCommand("SELECT * From [Currencies] ORDER BY [IDCurrency]", locSqlConn);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    while (locDR.Read())
                    {
                        ADComboBoxItem locItem = new ADComboBoxItem(locDR.GetInt32(locDR.GetOrdinal("IDCurrency")), locDR.GetString(locDR.GetOrdinal("CurrencyToken")) + ":  " + "(" + locDR.GetString(locDR.GetOrdinal("CurrencyCode")));
                        cb.Items.Add(locItem);
                    }

                    ADNullableComboBoxValueType locT = cb.ComboBoxValueType;
                    cb.ComboBoxValueType = ADNullableComboBoxValueType.Index_As_Int32;
                    cb.TypeSafeValue = 0;
                    cb.ComboBoxValueType = locT;
                }
            }
        }

        internal static void AddWageGroupsToADNullableIdOrIndexComboBox(ADNullableIdOrIndexComboBox cb)
        {
            SqlConnection locSqlConn = new SqlConnection(FacessoGeneric.SQLConnectionString);
            locSqlConn.Open();
            using (locSqlConn)
            {
                SqlCommand locCommand = new SqlCommand("SELECT * From [WageGroups] WHERE [IDSubsidiary]=" + FacessoGeneric.LoginInfo.IDSubsidiary + " AND [IsCurrent]='true'", locSqlConn);
                SqlDataReader locDR = locCommand.ExecuteReader();
                if (locDR.HasRows)
                {
                    while (locDR.Read())
                    {
                        ADComboBoxItem locItem = new ADComboBoxItem(locDR.GetInt32(locDR.GetOrdinal("IDWageGroup")), locDR.GetString(locDR.GetOrdinal("WageGroupToken")) + ": " + locDR.GetDecimal(locDR.GetOrdinal("HourlyRate")));
                        cb.Items.Add(locItem);
                    }

                    ADNullableComboBoxValueType locT = cb.ComboBoxValueType;
                    cb.ComboBoxValueType = ADNullableComboBoxValueType.Index_As_Int32;
                    cb.TypeSafeValue = 0;
                    cb.ComboBoxValueType = locT;
                }
            }
        }
    }
}