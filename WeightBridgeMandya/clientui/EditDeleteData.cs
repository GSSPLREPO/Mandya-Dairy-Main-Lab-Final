using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mandya.BO;
using Mandya.BL;
using Mandya.Common;
using MetroFramework;
using MetroFramework.Forms;

namespace WeightBridgeMandya.clientui
{
    public partial class EditDeleteData : MetroForm
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        DataTable dtMainLabAnalysis = new DataTable();

        #region Initialize Component
        public EditDeleteData()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event
        private void EditDeleteData_Load(object sender, EventArgs e)
        {
            bindMainLabAnalysis();
        }

        #endregion

        #region Bind MainLabAnalysis Gridview
        public void bindMainLabAnalysis()
        {
            try
            {
                MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                var objResult = objMainLabAnalysisBL.MainLabAnalysis_SelectAll_For_Gridview();
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvMainLab.AutoGenerateColumns = false;
                        gvMainLab.DataSource = objResult.ResultDt;
                        dtMainLabAnalysis = objResult.ResultDt;
                        gvMainLab.Visible = true;
                        txtSearch.Enabled = true;
                    }
                    else
                    {
                        gvMainLab.AutoGenerateColumns = false;
                        gvMainLab.DataSource = objResult.ResultDt;
                        dtMainLabAnalysis = objResult.ResultDt;
                        gvMainLab.Visible = false;
                        txtSearch.Enabled = false;
                        //MetroMessageBox.Show(this, "Record Not Found !", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Mandya WeighBridge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Add New Button Click Event
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            MainLab frmMainLab = new MainLab(-1);
            frmMainLab.ShowDialog();
            this.Activate();
            bindMainLabAnalysis();
        }
        #endregion

        #region Textbox TankerNo KeyPress Event
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8 || e.KeyChar >= 'A' && e.KeyChar <= 'Z' || e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Textbox TankerNo TextChanged Event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dtMainLabAnalysis);
                dv.RowFilter = string.Concat("CONVERT(TankerNo,System.String) LIKE '%", txtSearch.Text, "%'");
                gvMainLab.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region OldData Button Click Event
        private void btnOldData_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Activate();
            OldData frmOldData = new OldData();
            frmOldData.ShowDialog();
            this.Show();
            bindMainLabAnalysis();
        }
        #endregion

        #region Gridview CellContentClick Event
        private void gvMainLab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Program.intRoleId == 1)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex == 0)
                    {
                        int id = Convert.ToInt32(gvMainLab[2, e.RowIndex].Value);
                        MainLab frmMilkAnalysis = new MainLab(id);
                        frmMilkAnalysis.ShowDialog();
                        this.Activate();
                        bindMainLabAnalysis();
                    }
                    else if (e.RowIndex != -1 && e.ColumnIndex == 1)
                    {
                        int id = Convert.ToInt32(gvMainLab[2, e.RowIndex].Value);


                        DialogResult result = MetroMessageBox.Show(this, "Do you really want to delete this record?", "Lab", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            ApplicationResult objResult = new ApplicationResult();
                            MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                            objResult = objMainLabAnalysisBL.MainLabAnalysis_Delete(id, Program.intUserId);
                            if (objResult.Status.ToString() == "Success")
                            {
                                MetroMessageBox.Show(this, "Record Deleted Successfully.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bindMainLabAnalysis();
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "You cannot delete this record. Because it is in use.",
                                    "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Access Denied",
                                    "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.",
                    "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Logout Button Click Event
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.intUserId = 0;
            Program.intRoleId = 0;
            Login frmLogin = new Login();
            frmLogin.Show();
        }
        #endregion

        #region Form Closing Event
        private void EditDeleteData_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region AddProduct
        private void btnAddNewProduct(object sender, EventArgs e)
        {
            LabProduct frmLabProduct = new LabProduct();
            frmLabProduct.ShowDialog();
            this.Activate();
            bindMainLabAnalysis();
        }
        #endregion

        #region Lab report
        private void btnLabReport_Click(object sender, EventArgs e)
        {
            LabReport frmLabProduct = new LabReport();
            frmLabProduct.ShowDialog();
            this.Activate();
            bindMainLabAnalysis();
        }
        #endregion
    }
}
