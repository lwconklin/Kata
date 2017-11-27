using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kataKalibrate
{
    public partial class KataKalibrate : Form
    {
        public KataKalibrate()
        {
            InitializeComponent();
            inventoryGridView.Visible = false;
            label1.Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inventory.items.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "Excel Files(*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                Inventory.LoadInventory(openFileDialog1.FileName);
                if (Inventory.items.Count > 1)
                {
                    label1.Text = "Inital Inventory loaded";
                    ShowDataGrid();
 
                }
            }
            if(Inventory.items.Count.Equals(0))
            {
                MessageBox.Show("Sorry, No file selected or inventory items loaded.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Inventory.items.Count.Equals(0))
            {
                Inventory.UpdateInventory();
                label1.Text = "Inventory has been updated";
                ShowDataGrid();

            }
            else
            {
                MessageBox.Show("No inventory has been loaded, no inventory to update");
            }
        }

        private void ShowDataGrid()
        {
            label1.Visible = true;
            inventoryGridView.Visible = true;
            var list = new BindingList<Object>(Inventory.items);
            inventoryGridView.DataSource = list;

        }
    }
}
