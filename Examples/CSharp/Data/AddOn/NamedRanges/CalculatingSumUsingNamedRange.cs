﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aspose.Cells.Examples.CSharp.Data
{
    public class CalculatingSumUsingNamedRange
    {
        //Output directory
        static string outputDir = RunExamples.Get_OutputDirectory();

        public static void Run()
        {
            // Create an instance of Workbook
            Workbook book = new Workbook();

            // Get the WorksheetCollection
            WorksheetCollection worksheets = book.Worksheets;

            // Insert some data in cell A1 of Sheet1
            worksheets["Sheet1"].Cells["A1"].PutValue(10);

            // Add a new Worksheet and insert a value to cell A1
            worksheets[worksheets.Add()].Cells["A1"].PutValue(10);

            // Add a new Named Range with name "range"
            int index = worksheets.Names.Add("range");

            // Access the newly created Named Range from the collection
            Name range = worksheets.Names[index];

            // Set RefersTo property of the Named Range to a SUM function
            range.RefersTo = "=SUM(Sheet1!$A$1,Sheet2!$A$1)";

            // Insert the Named Range as formula to 3rd worksheet
            worksheets[worksheets.Add()].Cells["A1"].Formula = "range";

            // Calculate formulas
            book.CalculateFormula();

            // Save the result in XLSX format
            book.Save(outputDir + "outputCalculatingSumUsingNamedRange.xlsx");

            Console.WriteLine("CalculatingSumUsingNamedRange executed successfully.");
        }
    }
}
