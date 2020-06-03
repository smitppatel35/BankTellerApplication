using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bank_Teller_Application
{
    public partial class Form1 : Form
    {
        Crud c = new Crud();
        string details = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Find(object sender, EventArgs e)
        {
            string accountNumber = textBox1.Text;
            details = c.find(accountNumber);

            if(details != null)
            {
                label3.Text = details.Split(',')[1];
                label5.Text = details.Split(',')[2];
            } else
            {
                label3.Text = "Not Found!!";
                label5.Text = "0";
            }
        }

        private void Totals(object sender, EventArgs e)
        {
            string currentBalance = label5.Text;
            string val = details.Split(',')[2].Trim();

            double updatedVal = Double.Parse(currentBalance) - Double.Parse(val);
            System.Windows.Forms.MessageBox.Show("Total: "+updatedVal.ToString());

            // label5.Text = updatedVal.ToString();
            
        }

        private void Deposit(object sender, EventArgs e)
        {
            string currentBalance = label5.Text;
            string val = textBox2.Text;

            double updatedVal = Double.Parse(val) + Double.Parse(currentBalance);
            // System.Windows.Forms.MessageBox.Show(tmp.ToString());

            label5.Text = updatedVal.ToString();
            // c.updateAmount(details.Split(',')[0].Trim(), updatedVal, Double.Parse(val));
        }

        private void Withdraw(object sender, EventArgs e)
        {

            string currentBalance = label5.Text;
            string val = textBox2.Text;

            double updatedVal = Double.Parse(currentBalance) - Double.Parse(val);
            // System.Windows.Forms.MessageBox.Show(tmp.ToString());

            if(updatedVal > 0)
            {
                label5.Text = "Not Enough Balance.";
            } else
            {
                label5.Text = updatedVal.ToString();
            }
        }

        private void Save(object sender, EventArgs e)
        {
            string currentBalance = label5.Text;
            

            c.updateAmount(details.Split(',')[0].Trim(), currentBalance);
        }

        private void Close(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }
    }
}
