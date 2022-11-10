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
            this.Hide();
            this.Activate();
            EditDeleteData frmData = new EditDeleteData();
            frmData.ShowDialog(this);
            //this.Close();
            
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Activate();
            LabProduct frmLabProduct = new LabProduct();
            frmLabProduct.ShowDialog(this);
            //this.Close();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.intUserId = 0;
            Program.intRoleId = 0;
            Login frmLogin = new Login();
            frmLogin.Show();
            
        }

        #region Method to Close Open form befor Application Exit
        public void IsFormOpen()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType().Name == form.Name)
                {
                    string temp = form.ToString();
                    
                }
            }  
        }
        #endregion
    }
}
