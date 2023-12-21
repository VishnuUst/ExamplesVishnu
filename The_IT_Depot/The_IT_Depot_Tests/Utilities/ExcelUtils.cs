using ExcelDataReader;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_IT_Depot_Tests.Utilities;

namespace The_IT_Depot_Tests.Utilities
{
    
    internal class ExcelUtils
    {
        public static List<ITDepotData> ReadExcelData(string excelFilePath,string sheetName)
        {
            List<ITDepotData> addToCartAndCheckouts = new List<ITDepotData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

            {

                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {

                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()

                    {

                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()

                        {

                            UseHeaderRow = true,

                        }

                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)

                    {

                        foreach (DataRow row in dataTable.Rows)

                        {

                            ITDepotData excelData = new ITDepotData

                            {

                              
                                SearchItem = GetValueOrDefault(row,"searchitem"),
                                ProductNo = GetValueOrDefault(row,"productNo"),
                                Qty = GetValueOrDefault(row,"qty"),
                                Name = GetValueOrDefault(row,"name"),
                                Email = GetValueOrDefault(row,"email"),
                                Mobile = GetValueOrDefault(row,"mobile"),
                                Password = GetValueOrDefault(row,"password"),
                                ConfirmPassword = GetValueOrDefault(row,"confirmpassword"),
                                City = GetValueOrDefault(row,"city"),
                                ZipCode = GetValueOrDefault(row,"zipcode"),
                                State = GetValueOrDefault(row,"state"),
                                Address = GetValueOrDefault(row,"address"),

                                

                            };



                            addToCartAndCheckouts.Add(excelData);

                        }

                    }

                    else

                    {

                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");

                    }

                }

            }

            return addToCartAndCheckouts;

        }

        static string GetValueOrDefault(DataRow row, string columnName)

        {

            Console.WriteLine(row + "  " + columnName);

            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;

        }

    
    }
}


