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
using Mandya.Common;
using MetroFramework;
using MetroFramework.Forms;


namespace WeightBridgeMandya.clientui
{

    public partial class OldData : MetroForm
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        DataTable dtMainLabAnalysis = new DataTable();

        #region Initialize Component
        public OldData()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event
        private void OldData_Load(object sender, EventArgs e)
        {
            gvMainLab.Visible = false;
            txtSearch.Enabled = false;
        }
        #endregion

        #region Go Button Click Event
        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                var objResult = objMainLabAnalysisBL.MainLabAnalysis_SelectAll_For_Gridview(Convert.ToDateTime(dtFromDate.Text),Convert.ToDateTime(dtToDate.Text));
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
                        MetroMessageBox.Show(this, "Record Not Found !", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        #region Close Button Click Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #region Gridview MainLabAnalysis CellContentClick Event
        private void gvMainLab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Program.intRoleId == 1)
                {
                    if (e.RowIndex != -1 && e.ColumnIndex == 0)
                    {
                        int id = Convert.ToInt32(gvMainLab[2, e.RowIndex].Value);
                        MainLab frmMainLabAnalysis = new MainLab(id);
                        frmMainLabAnalysis.ShowDialog();
                        this.Activate();
                        this.Show();
                        btnGo_Click(sender, e);

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
                                btnGo_Click(sender, e);
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
    }
}
