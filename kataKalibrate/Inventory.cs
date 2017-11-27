using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace kataKalibrate
{
    public class Inventory

    {
        private enum ColumnName : int { Name = 1, SellIn, Quality }
        private const int minimumExcelRows = 2; // header plus one data row

        static public List<Object> items = new List<Object>();
        static public void LoadInventory(string fileName)
        {
            var workbook = new XLWorkbook(fileName);
            var ws = workbook.Worksheets.First();
            var range = ws.RangeUsed();
            var columnCount = range.ColumnCount();
            var rowCount = range.RowCount();
            if (rowCount <= minimumExcelRows) 
            {
                MessageBox.Show("No data in excel file.");
            }
            else {

                if (columnCount != 3)  // todo make 9 an changable constant?
                {
                    MessageBox.Show("Excel WorkBook is not formed correctly.");
                } else {

                    foreach (var r in ws.RowsUsed().Skip(1)) // skip header row
                    {
                        bool validItem = false;
                        string name = r.Cell((int)ColumnName.Name).Value.ToString().Trim();
                        int sellin = Convert.ToInt32(r.Cell((int)ColumnName.SellIn).Value);
                        int quality = Convert.ToInt32(r.Cell((int)ColumnName.Quality).Value);

                        if (name.Equals("AgedBrie"))
                        {
                            AgedBrie item = new AgedBrie(name, sellin, quality, (int)Product.ProductType.AgedBrie);
                           
                            
                            items.Add(item);
                            validItem = true;
                        }

                        if (name.Equals("Backstage passes"))
                        {
                            BackstagePass item = new BackstagePass(name, sellin, quality, (int)Product.ProductType.BackstagePasses);
                            items.Add(item);
                            validItem = true;
                        }
                        if (name.Equals("Sulfuras"))
                        {
                            Sulfuras item = new Sulfuras(name, sellin, quality, (int)Product.ProductType.Sulfuras);
                            items.Add(item);
                            validItem = true;
                        }
                        if (name.Equals("Normal Item"))
                        {
                            NormalItem item = new NormalItem(name, sellin, quality, (int)Product.ProductType.NormalItem);
                            items.Add(item);
                            validItem = true;
                        }
                        if (name.Equals("Conjured"))
                        {
                            Conjured item = new Conjured(name, sellin, quality, (int)Product.ProductType.Conjured);
                            items.Add(item);
                            validItem = true;
                        }
                        if (validItem.Equals(false))
                        {
                            InvalidItem item = new InvalidItem((int)Product.ProductType.InvalidItem);
                            items.Add(item);
                        }
        
                    }
                }
            }
            if(rowCount -1 != items.Count)
            {
                MessageBox.Show("Inventory was not loaded properly, mismatch count between Excel worksheet and items loaded.");
            }
        }

        public static void UpdateInventory()
        {
            Product product;
            AgedBrie agedBrie;
            BackstagePass backStagePasses;
            Conjured conjured;
            NormalItem normalItem;
            Sulfuras sulfuras;


            foreach(object o in Inventory.items)
            {
                product = (Product)o;
                if (product.productType.Equals((int)Product.ProductType.AgedBrie))
                {
                    agedBrie = (AgedBrie)o;
                    agedBrie.Update();
                }
                if (product.productType.Equals((int)Product.ProductType.BackstagePasses))
                {
                    backStagePasses = (BackstagePass)o;
                    backStagePasses.Update();
                }
                if (product.productType.Equals((int)Product.ProductType.Conjured))
                {
                    conjured = (Conjured)o;
                    conjured.Update();
                }
                if (product.productType.Equals((int)Product.ProductType.NormalItem))
                {
                    normalItem = (NormalItem)o;
                    normalItem.Update();
                }
                if (product.productType.Equals((int)Product.ProductType.Sulfuras))
                {
                    sulfuras = (Sulfuras)o;
                    sulfuras.Update();
                }
            }
        }
    }
}
