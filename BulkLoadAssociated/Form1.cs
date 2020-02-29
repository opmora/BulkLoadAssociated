using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BulkLoadAssociated.Bean;

namespace BulkLoadAssociated
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblFileName.Text = openFileDialog1.FileName;
            }
        }

        private async void BtnLoadFile_Click_1(object sender, EventArgs e)
        {
            ResponseCommon response = new ResponseCommon();
            response = await AssociateManagement.RegisterAssociated(CSV.ConverToAssociated(CSV.ReaCSV(lblFileName.Text)));
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
