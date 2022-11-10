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
            bindMainLabAnalysis(System.DateTime.Now);
        }

        #endregion

        #region Bind MainLabAnalysis Gridview
        public void bindMainLabAnalysis(DateTime dtDateTime)
        {
            try
            {
                MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                var objResult = objMainLabAnalysisBL.MainLabAnalysis_SelectAll_For_Gridview(dtDateTime);
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvMainLab.AutoGenerateColumns = false;
                        gvMainLab.DataSource = objResult.ResultDt;
                        dtMainLabAnalysis = objResult.ResultDt;
                        gvMainLab.Visible = true;
                        //txtSearch.Enabled = true;
                    }
                    else
                    {
                        gvMainLab.AutoGenerateColumns = false;
                        gvMainLab.DataSource = objResult.ResultDt;
                        dtMainLabAnalysis = objResult.ResultDt;
                        gvMainLab.Visible = false;
                        // txtSearch.Enabled = false;
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
            LabReport frmLabReport = new LabReport(-1);
            frmLabReport.Show();
            bindMainLabAnalysis(System.DateTime.Now);
        }
        #endregion

        #region Textbox Tank TextChanged Event
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DataView dv = new DataView(dtMainLabAnalysis);
            //    dv.RowFilter = string.Concat("CONVERT(TankerNo,System.String) LIKE '%", txtSearch.Text, "%'");
            //    gvMainLab.DataSource = dv.ToTable();
            //}
            //catch (Exception ex)
            //{
            //    log.Error("error", ex);
            //    MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion

        #region OldData Button Click Event
        //private void btnOldData_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    this.Activate();
        //    OldData frmOldData = new OldData();
        //    frmOldData.ShowDialog();
        //    this.Show();
        //    bindMainLabAnalysis();
        //}
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
                        this.Hide();
                        int id = Convert.ToInt32(gvMainLab[2, e.RowIndex].Value);
                        LabReport frmLabReport = new LabReport(id);
                        frmLabReport.Show();
                        this.Activate();
                        bindMainLabAnalysis(Convert.ToDateTime(dtDate.Text));
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
                                bindMainLabAnalysis(Convert.ToDateTime(dtDate.Text));
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

        #region Lab report
        private void btnLabReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            LabReport frmLabProduct = new LabReport(-1);
            frmLabProduct.Show();
            
        }
        #endregion

        #region Select Old Data Datewise
        private void btnGo_Click(object sender, EventArgs e)
        {
            bindMainLabAnalysis(Convert.ToDateTime(dtDate.Text));
        }
        #endregion

        #region Form Close Event
        private void EditDeleteData_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Form1 frmMainForm = new Form1();
            frmMainForm.Show();

        }
        #endregion
    }
}
