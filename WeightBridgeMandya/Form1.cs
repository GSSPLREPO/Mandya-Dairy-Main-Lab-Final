using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mandya.BL;
using Mandya.BO;
using Mandya.Common;
using MetroFramework;
using WeightBridgeMandya.clientui;
using System.Threading;


namespace WeightBridgeMandya
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void metroTile1_Click(object sender, EventArgs e)
        {
            EditDeleteData frmData = new EditDeleteData();
            frmData.ShowDialog();
           
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
           
            LabProduct frmLabProduct = new LabProduct();
            frmLabProduct.ShowDialog();
            
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(200);
            Login frmLogin = new Login();
            frmLogin.Show();
            
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
