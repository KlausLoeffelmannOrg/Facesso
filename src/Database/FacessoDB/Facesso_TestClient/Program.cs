using Facesso_DatamodelImporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Facesso_Datalayer;

namespace Facesso_TestClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var oc = new FacessoContext())
            {
                var workGroups_GetItems_Result = oc.FromStoredProcedure<WorkGroups>("WorkGroups_GetItems",
                    new Guid("2DA059B5-CB54-E611-9C72-0050B60F7AA9"), null, 1, true);

                var workGroups_GetItems_Result2 = oc.FromStoredProcedure("WorkGroups_GetItems",
                    new Guid("2DA059B5-CB54-E611-9C72-0050B60F7AA9"), null, 1, true);

                //var x = oc.Subsidiaries.FromSql("",);

                //var f = oc.Subsidiaries.First();

                //Console.WriteLine(f.Idsubsidiary);
                Console.WriteLine("Ergebnis von der SP WorkGroups_GetItems (IDs):");
                foreach (var item in workGroups_GetItems_Result)
                {
                    Console.WriteLine(item.IdworkGroup);
                }

                Console.WriteLine("Ergebnis von der SP WorkGroups_GetItems mit Dynamic (IDs):");
                foreach (var item in workGroups_GetItems_Result2)
                {
                    Console.WriteLine(item.IDWorkGroup);
                }
            }
            Console.ReadKey();
        }
    }
}
