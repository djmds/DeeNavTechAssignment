using NavTech.Configuration.DataAccess.Models;
using System.Collections.Generic;
using System.Data;

namespace NavTech.Configuration.Common
{
    public static class Extensions
    {
        public static DataTable ToDataTable(this List<EntityConfiguration> items)
        {
            DataTable dataTable = new DataTable();
            dataTable.TableName = "tblBulkInsertUpdateEntityType";
            EntityConfiguration econfig = new EntityConfiguration();
            dataTable.Columns.Add(nameof(econfig.EntityName),typeof(string));
            dataTable.Columns.Add(nameof(econfig.FieldName), typeof(string));
            dataTable.Columns.Add(nameof(econfig.IsRequired), typeof(bool));
            dataTable.Columns.Add(nameof(econfig.MaxLength), typeof(int));
            dataTable.Columns.Add(nameof(econfig.FieldSource), typeof(string));

            foreach (var item in items)
            {
                DataRow newRow = dataTable.NewRow();

                newRow[nameof(econfig.EntityName)] = item.EntityName;
                newRow[nameof(econfig.FieldName)] = item.FieldName;
                newRow[nameof(econfig.IsRequired)] = item.IsRequired;
                newRow[nameof(econfig.MaxLength)] = item.MaxLength;
                newRow[nameof(econfig.FieldSource)] = item.FieldSource;
                dataTable.Rows.Add(newRow);
            }
            return dataTable;
        }
    }
}
