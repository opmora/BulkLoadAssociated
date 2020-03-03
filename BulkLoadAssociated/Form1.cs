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
using BulkLoadAssociated.Modelos;

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
                lblFileName.Text = "File: " + openFileDialog1.FileName;
            }
        }

        private async void BtnLoadFile_Click_1(object sender, EventArgs e)
        {
            ResponseCommon response = new ResponseCommon();
            List<AssociatedModel> associateds = new List<AssociatedModel>();
            string filePath = lblFileName.Text.Substring(6);
            lblMessage.Text = "";

            associateds = CSV.ConverToAssociated(CSV.ReaCSV(filePath));
            foreach (var itemAssociated in associateds)
            {
                response = await AssociateManagement.RegisterAssociated(itemAssociated);
                lblMessage.Text = lblMessage.Text +  "Message: " + response.explain + " status: " + response.status + Environment.NewLine;
                Log.WriteLog(response.explain + " status: " + response.status);
            }
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
