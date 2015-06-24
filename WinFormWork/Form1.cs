using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace WinFormWork
{
    public partial class Form1 : Form
    {
        public Data mydata = new Data();

        public Form1()
        {
            InitializeComponent();
        }

        private void dGV1_SelectionChanged(object sender, EventArgs e)
        {
            int row = 0;
            row = dGV1.CurrentRow.Index;
            tbCompany.Text = dGV1[0, row].Value.ToString();
            tbContact.Text = dGV1[1, row].Value.ToString();
            tbTitle.Text = dGV1[2, row].Value.ToString();
            tbID.Text = dGV1[3, row].Value.ToString();
            tbAddress.Text = dGV1[4, row].Value.ToString();
            tbCity.Text = dGV1[5, row].Value.ToString();
            tbCountry.Text = dGV1[6, row].Value.ToString();
            tbRegion.Text = dGV1[7, row].Value.ToString();
            tbPostal.Text = dGV1[8, row].Value.ToString();
            tbPhone.Text = dGV1[9, row].Value.ToString();
            tbFax.Text = dGV1[10, row].Value.ToString();
        }

        private void cmdSearch_Click_1(object sender, EventArgs e)
        {
            mydata.Set(tbSearchCompany.Text, tbSearchContact.Text);
            dGV1.DataSource = mydata.Execute();
            if (dGV1.RowCount==0)
            {
                button1.Enabled = false;
                tableLayoutPanel3.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
            }
            else
            {
                button1.Enabled = true;
                tableLayoutPanel3.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mydata.updatemodel.CustomerID = tbID.Text;
            mydata.updatemodel.CompanyName = tbCompany.Text;
            mydata.updatemodel.ContactTitle= tbTitle.Text;
            mydata.updatemodel.ContactName = tbContact.Text;
            mydata.updatemodel.Address = tbAddress.Text;
            mydata.updatemodel.City = tbCity.Text;
            mydata.updatemodel.Country = tbCountry.Text;
            mydata.updatemodel.Region = tbRegion.Text;
            mydata.updatemodel.PostalCode = tbPostal.Text;
            mydata.updatemodel.Phone = tbPhone.Text;
            mydata.updatemodel.Fax = tbFax.Text;

            //TODO: Add all other fields from table
            
            mydata.Update();

            cmdSearch_Click_1(sender, e);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
