using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Mandya.BL;
using Mandya.BO;
using Mandya.Common;
using MetroFramework;
using MetroFramework.Forms;
using S7.Net;
using log4net;

namespace WeightBridgeMandya.clientui
{
    public partial class LabReport : MetroForm
    {
        public string mode=string.Empty;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LabReport()
        {
            InitializeComponent();
        }

        #region Form Load Event

        private void LabReport_Load(object sender, EventArgs e)
        {
           
            BindDropDownProduct();
            bindTankDropdown();
            BindCommonDropdown();
            setDefaultValue();
            mode = "Save";
            rdoAuto.Checked = true;
        }
        #endregion

        #region Set Default Value in Controls
        private void setDefaultValue()
        {
            dtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            bindTankDropdown();
            cmbProduct.SelectedIndex = 0;
            txtBatchNo.Text = "";
            rdoAuto.Checked = true;
            txtTemp.Text = "0";
            txtAcidity.Text = "0";
            txtFat.Text = "0";
            txtSnf.Text = "0";
            txtMbrt.Text = "0";
            cmbAdultration.SelectedIndex = 0;
            txtAerobicPlate.Text = "0";
            cmbPhospharaseTest.SelectedIndex = 0;
            txtAlcohol.Text = "0";
            txtColiform.Text = "0";
            txtSomaticCell.Text = "0";
            txtCremingIndex.Text = "0";
            txtTotalSolid.Text = "0";
            txtBulkDensity.Text = "0";
            txtPh.Text = "0";
            txtBRReading.Text = "0";
            txtMoisture.Text = "0";
            txtFFAOA.Text = "0";
            txtProtein.Text = "0";
            txtScorchedParticle.Text = "0";
            txtRMValue.Text = "0";
            txtPValue.Text = "0";
            cmbBauduinTest.SelectedIndex = 0;
            txtSucrosePercent.Text = "0";
            txtEColi.Text = "0";
            txtInsolubilityIndex.Text = "0";
            txtInsolubilityIndex.Text = "0";
            txtTotalAsh.Text = "0";
            txtWettability.Text = "0";
            cmbAppearance.SelectedIndex = 0;
            cmbBodyAndTexture.SelectedIndex = 0;
            cmbFlavour.SelectedIndex = 0;
            txtRemarks.Text = "";

        }

        #endregion

        #region Save Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                MainLabAnalysisBO objMainLabAnalysisBO = new MainLabAnalysisBO();
                ApplicationResult objResult = new ApplicationResult();

                bool entryType = false;

                if (rdoAuto.Checked == true)
                {
                    entryType = true;
                }
                else
                {
                    entryType = false;
                }

                if (mode == "Save")
                {
                    objMainLabAnalysisBO.DateTime = Convert.ToDateTime(dtDate.Text+" "+dtTime.Text);
                    objMainLabAnalysisBO.TankID = Convert.ToInt32(cmbTankNo.SelectedValue);
                    objMainLabAnalysisBO.BatchNo = txtBatchNo.Text.Trim();
                    objMainLabAnalysisBO.ProductID = Convert.ToInt32(cmbProduct.SelectedValue);
                    objMainLabAnalysisBO.IsAuto = entryType;
                    objMainLabAnalysisBO.Temp = float.Parse(txtTemp.Text.Trim());
                    objMainLabAnalysisBO.Acidity = float.Parse(txtAcidity.Text.Trim());
                    objMainLabAnalysisBO.FAT = float.Parse(txtFat.Text.Trim());
                    objMainLabAnalysisBO.SNF = float.Parse(txtSnf.Text.Trim());
                    objMainLabAnalysisBO.Mbrt = float.Parse(txtMbrt.Text.Trim());
                    objMainLabAnalysisBO.PhospharaseTest = Convert.ToInt32(cmbPhospharaseTest.SelectedValue);
                    objMainLabAnalysisBO.Alcohol = float.Parse(txtAlcohol.Text.Trim());
                    objMainLabAnalysisBO.Adultration = Convert.ToInt32(cmbAdultration.SelectedValue);
                    objMainLabAnalysisBO.AerobicPlate = float.Parse(txtAerobicPlate.Text.Trim());
                    objMainLabAnalysisBO.Coliform = float.Parse(txtColiform.Text.Trim());
                    objMainLabAnalysisBO.SomaticCell = float.Parse(txtSomaticCell.Text.Trim());
                    objMainLabAnalysisBO.CremingIndex = float.Parse(txtTemp.Text.Trim());
                    objMainLabAnalysisBO.TotalSolid = float.Parse(txtTotalSolid.Text.Trim());
                    objMainLabAnalysisBO.Ph = float.Parse(txtPh.Text.Trim());
                    objMainLabAnalysisBO.Appearance = Convert.ToInt32(cmbAppearance.SelectedValue);
                    objMainLabAnalysisBO.BodyAndTexture = Convert.ToInt32(cmbBodyAndTexture.SelectedValue);
                    objMainLabAnalysisBO.Flavour = Convert.ToInt32(cmbFlavour.SelectedValue);
                    objMainLabAnalysisBO.Moisture = float.Parse(txtMoisture.Text.Trim());
                    objMainLabAnalysisBO.FFAOA = float.Parse(txtFFAOA.Text.Trim());
                    objMainLabAnalysisBO.BRReading = float.Parse(txtBRReading.Text.Trim());
                    objMainLabAnalysisBO.RMValue = float.Parse(txtRMValue.Text.Trim());
                    objMainLabAnalysisBO.PValue = float.Parse(txtPValue.Text.Trim());
                    objMainLabAnalysisBO.BauduinTest = Convert.ToInt32(cmbBauduinTest.SelectedValue);
                    objMainLabAnalysisBO.EColi = float.Parse(txtEColi.Text.Trim());
                    objMainLabAnalysisBO.SucrosePercent = float.Parse(txtSucrosePercent.Text.Trim());
                    objMainLabAnalysisBO.InsolubilityIndex = float.Parse(txtInsolubilityIndex.Text.Trim());
                    objMainLabAnalysisBO.Protein = float.Parse(txtProtein.Text.Trim());
                    objMainLabAnalysisBO.TotalAsh = float.Parse(txtTotalAsh.Text.Trim());
                    objMainLabAnalysisBO.ScorchedParticle = float.Parse(txtScorchedParticle.Text.Trim());
                    objMainLabAnalysisBO.BulkDensity = float.Parse(txtBulkDensity.Text.Trim());
                    objMainLabAnalysisBO.Wettability = float.Parse(txtWettability.Text.Trim());
                    objMainLabAnalysisBO.CreatedByID = Convert.ToInt32(Program.intUserId.ToString());
                    objMainLabAnalysisBO.CreatedByDate = Convert.ToDateTime(DateTime.Now.ToString());

                    objResult = objMainLabAnalysisBL.MainLabAnalysis_Insert(objMainLabAnalysisBO);
                    if (objResult != null)
                    {
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            MetroMessageBox.Show(this, "Record Saved Successfully.", "Lab",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Error Data Not Saved.", "Lab",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {
                log.Error("Save Button Click : " + ex.ToString());
            }
           
        }
        #endregion

        #region Close Button Click Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            Form1 frmMainForm = new Form1();
            frmMainForm.Show();
            this.Close();
        }
        #endregion

        #region Validate
        /* private Boolean validateFields(int validate) {
            int intValid = 0;

            #region Raw Milk
            
            if (validate == 1) 
            {
                if (Convert.ToDouble(txtTEMP.Text) != 4) {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) < 0.135 || Convert.ToDouble(txtAcidity.Text) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 3.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 8.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 90)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAlcohol.Text) < 68)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //if (Convert.ToDouble(txtAreobicPlateCountML.Text) < 0.135 && Convert.ToDouble(txtAreobicPlateCountML) > 0.153)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtSomaticCellCount.Text) > 300000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }

            }
#endregion
            #region  Pasteurised Milk
            else if (validate == 2) 
            {
                if (Convert.ToDouble(txtTEMP.Text) < 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 3.1)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 8.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 330)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtAlcohol.Text) < 68)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                if (Convert.ToDouble(txtAreobicPlateCountML.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtSomaticCellCount.Text) < 300000)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtColiformML.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion 
            #region Pasteurised HCM
            else if (validate == 3)
            {
                if (Convert.ToDouble(txtTEMP.Text) < 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 3.6)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 8.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 330)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtAlcohol.Text) < 68)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                if (Convert.ToDouble(txtAreobicPlateCountML.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtSomaticCellCount.Text) < 300000)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtColiformML.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtCreamingIndex.Text) > 10) 
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Pasteurised SSM
            else if (validate == 4)
            {
                if (Convert.ToDouble(txtTEMP.Text) < 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 4.6)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 8.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 330)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtAlcohol.Text) < 68)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                if (Convert.ToDouble(txtAreobicPlateCountML.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtSomaticCellCount.Text) < 300000)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtColiformML.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtCreamingIndex.Text) > 10)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
            }
#endregion
            #region Pasteurized NSM
            else if (validate == 5)
            {
                if (Convert.ToDouble(txtTEMP.Text) < 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 4.1)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 9.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 330)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtAlcohol.Text) < 68)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                if (Convert.ToDouble(txtAreobicPlateCountML.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtSomaticCellCount.Text) < 300000)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtColiformML.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtCreamingIndex.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Pasteurised Curd MIlk
            else if (validate == 6)
            {
                if (Convert.ToDouble(txtTEMP.Text) < 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 3.1)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 300)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtAlcohol.Text) < 68)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtAreobicPlateCountML.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtSomaticCellCount.Text) < 300000)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtColiformML.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtCreamingIndex.Text) > 10)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
            }
#endregion
            #region Pasteurised Panner Milk
            else if (validate == 7)
            {
                if (Convert.ToDouble(txtTEMP.Text) < 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 4.6)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 8.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 360)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtAlcohol.Text) < 68)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                if (Convert.ToDouble(txtAreobicPlateCountML.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtSomaticCellCount.Text) < 300000)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
                else if (Convert.ToDouble(txtColiformML.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                //else if (Convert.ToDouble(txtCreamingIndex.Text) > 10)
                //{
                //    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    intValid = 1;
                //}
            }
#endregion
            #region Curd/Dahi
            else if (validate == 8)
            {
                if (Convert.ToDouble(txtTEMP.Text) > 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) < 0.6 || Convert.ToDouble(txtAcidity) > 0.8)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 3.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtTotalSolids.Text) < 13.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtColiformML.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMoulds.Text) > 50.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region UHT Toned Milk
            else if (validate == 9)
            {
                if (Convert.ToDouble(txtTEMP.Text) > 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) < 0.135 || Convert.ToDouble(txtAcidity) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 3.1)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 8.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtpH.Text) < 6.3 || Convert.ToDouble(txtpH) > 6.7)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicSporeCountML.Text) > 5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtCreamingIndex.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region UHT Double Toned Milk
            else if (validate == 10)
            {
                if (Convert.ToDouble(txtTEMP.Text) > 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) < 0.135 || Convert.ToDouble(txtAcidity) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 1.6)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 9.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtpH.Text) < 6.3 || Convert.ToDouble(txtpH) > 6.7)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicSporeCountML.Text) > 5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtCreamingIndex.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
            #endregion
            #region UHT Skimmed MIlk
            else if (validate == 11)
            {
                if (Convert.ToDouble(txtTEMP.Text) > 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) < 0.135 || Convert.ToDouble(txtAcidity) > 0.153)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) > 0.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 8.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtpH.Text) < 6.3 || Convert.ToDouble(txtpH) > 6.7)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicSporeCountML.Text) > 5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtCreamingIndex.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Pasteurised Cream
            else if (validate == 12)
            {
                if (Convert.ToDouble(txtTEMP.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.08)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 40)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMBRT.Text) < 240)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Spiced Butter MIlk
            else if (validate == 13)
            {
                if (Convert.ToDouble(txtTEMP.Text) > 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.45)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 1.2)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSNF.Text) < 4.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtTotalSolids.Text) < 13.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtColiformML.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMoulds.Text) > 50.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Pasturised Sweet Lassi
            else if (validate == 14)
            {
                if (Convert.ToDouble(txtTEMP.Text) > 4)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 2.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtColiformML.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMoulds.Text) > 50.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Pasteurised Cooking Butter
            else if (validate == 15)
            {
                if (Convert.ToDouble(txtFatbyMass.Text) < 82.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMoistureBymass.Text) > 16)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtCurbBymass.Text) < 1.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAciditybyMass.Text) > 0.06)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) < 25000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtColiformCountg.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMouldsG.Text) > 20.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Ghee Special Grade
            else if (validate == 16)
            {
                if (Convert.ToDouble(txtMoisture.Text) > 0.3)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFFAOA.Text) > 0.6)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtBRReading.Text) < 40 || Convert.ToDouble(txtBRReading) > 43)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtRMvalue.Text) < 28.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtPValue.Text) < 1.0 || Convert.ToDouble(txtPValue) > 2.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Paneer
            else if (validate == 17)
            {
                if (Convert.ToDouble(txtMoisture.Text) > 60)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFatonDryMaterBasics.Text) < 50)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAciditybyMass.Text) > 50)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) > 150000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtColiformCountg.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMouldsG.Text) > 50)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txteColig.Text) < 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Milk Peda
            else if (validate == 18)
            {
                if (Convert.ToDouble(txtMoisture.Text) > 17.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFat.Text) < 16)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) > 25000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMouldsG.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Milk Burfi
            else if (validate == 19)
            {
                if (Convert.ToDouble(txtMoisture.Text) > 15.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFatbyWeight.Text) < 10.0 || Convert.ToDouble(txtFatbyWeight) > 23.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.45)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) > 25000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMouldsG.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region Mysore Pak
            else if (validate == 20)
            {
                if (Convert.ToDouble(txtMoisture.Text) > 5.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFatbyMass.Text) < 42.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 1.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSucroseByWeight.Text) > 40.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) > 5000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }

            }
#endregion
            #region Ladoo
            else if (validate == 21)
            {
                if (Convert.ToDouble(txtMoisture.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtFatbyMass.Text) < 20.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidity.Text) > 0.45)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtSucroseByWeight.Text) > 33.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) > 5000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
#endregion
            #region SMP Standered Grade
            else if (validate == 22)
            {
                if (Convert.ToDouble(txtFatbyMass.Text) > 1.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtInsolubilityIndexProtein.Text) > 0.5)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMoistureBymass.Text) > 4.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtProtein.Text) > 34.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtTotalAshDryBasis.Text) > 8.2)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtColiformCountg.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMouldsG.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidityNaOH.Text) > 18.0 || Convert.ToDouble(txtAcidityNaOH) < 12)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtBulkDensity.Text) > 0.60 || Convert.ToDouble(txtBulkDensity) < 0.50)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtWettability.Text) > 60)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }

#endregion
            #region WMP
            else if (validate == 23)
            {
                if (Convert.ToDouble(txtFatbyMass.Text) > 26)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtInsolubilityIndexProtein.Text) > 2.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtMoistureBymass.Text) > 4.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtProtein.Text) > 34.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtTotalAshDryBasis.Text) > 7.3)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAerobicPlateCountg.Text) > 30000)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtColiformCountg.Text) > 10)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtYeastMouldsG.Text) > 10.0)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtBulkDensity.Text) > 0.60 || Convert.ToDouble(txtBulkDensity) < 0.50)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtAcidityNaOH.Text) > 1.2)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
                else if (Convert.ToDouble(txtWettability.Text) > 60)
                {
                    //MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValid = 1;
                }
            }
            #endregion

            if (intValid == 1) return false;
            return true;
        }*/
        #endregion

        #region Product ComboBox Selected Index Change Event 
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataToBox(Convert.ToInt32(cmbProduct.SelectedValue));
        }

        
        private void BindDataToBox(int productID)
        {

            MainLabProductBO objMainLabProductBO = new MainLabProductBO();
            LabReportProductBL objLabReportProductBL = new LabReportProductBL();
            ApplicationResult objResult = new ApplicationResult();

            objResult = objLabReportProductBL.MainLabProduct_SelectProduct(productID);
            try
            {
                if (objResult.ResultDt.Rows.Count>0)
                {
                    txtTemp.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TEMP]);
                    EnabledChanged(txtTemp);
                    txtAcidity.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITY]);
                    EnabledChanged(txtAcidity);
                    txtFat.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FAT]);
                    EnabledChanged(txtFat);
                    txtSnf.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SNF]);
                    EnabledChanged(txtSnf);
                    txtMbrt.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MBRT]);
                    EnabledChanged(txtMbrt);
                    cmbAdultration.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ADULTRATION]);
                    EnabledChangedDd(cmbAdultration);
                    txtAerobicPlate.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICPLATE]);
                    EnabledChanged(txtAerobicPlate);
                    cmbPhospharaseTest.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PHOSPHARASETEST]);
                    EnabledChangedDd(cmbPhospharaseTest);
                    txtAlcohol.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ALCOHOL]);
                    EnabledChanged(txtAlcohol);
                    txtColiform.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_COLIFORM]);
                    EnabledChanged(txtColiform);
                    txtSomaticCell.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SOMATICCELL]);
                    EnabledChanged(txtSomaticCell);
                    txtCremingIndex.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_CREMINGINDEX]);
                    EnabledChanged(txtCremingIndex);
                    txtTotalSolid.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALSOLID]);
                    EnabledChanged(txtTotalSolid);
                    cmbAppearance.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_APPEARANCE]);
                    EnabledChangedDd(cmbAppearance);
                    txtPh.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PH]);
                    EnabledChanged(txtPh);
                    cmbFlavour.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FLAVOUR]);
                    EnabledChangedDd(cmbFlavour);
                    txtMoisture.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MOISTURE]);
                    EnabledChanged(txtMoisture);
                    txtFFAOA.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FFAOA]);
                    EnabledChanged(txtFFAOA);
                    cmbBodyAndTexture.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BODYANDTEXTURE]);
                    EnabledChangedDd(cmbBodyAndTexture);
                    txtScorchedParticle.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SCORCHEDPARTICLE]);
                    EnabledChanged(txtScorchedParticle);
                    txtRMValue.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_RMVALUE]);
                    EnabledChanged(txtRMValue);
                    txtPValue.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PVALUE]);
                    EnabledChanged(txtPValue);
                    cmbBauduinTest.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BAUDUINTEST]);
                    EnabledChangedDd(cmbBauduinTest);
                    txtSucrosePercent.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SUCROSEPERCENT]);
                    EnabledChanged(txtSucrosePercent);
                    txtProtein.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PROTEIN]);
                    EnabledChanged(txtProtein);
                    txtInsolubilityIndex.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_INSOLUBILITYINDEX]);
                    EnabledChanged(txtInsolubilityIndex);
                    txtTotalAsh.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALASH]);
                    EnabledChanged(txtTotalAsh);
                    txtWettability.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_WETTABILITY]);
                    EnabledChanged(txtWettability);
                    txtEColi.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ECOLI]);
                    EnabledChanged(txtEColi);
                    txtBRReading.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BRREADING]);
                    EnabledChanged(txtBRReading);
                    txtBulkDensity.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BULKDENSITY]);
                    EnabledChanged(txtBulkDensity);
                }
               
            }
            catch (Exception ex)
            {
                log.Error("Product Dropdown Selected Index Change Event :" + ex.ToString());
            }

        }
        #endregion

        #region Bind Product Name Dropdown

        private void BindDropDownProduct()
        {
            try
            {
                MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                ApplicationResult objResult = new ApplicationResult();

                objResult = objLabReportProductBL.MainLabProduct_Select_Product();

                if (objResult.ResultDt.Rows.Count > 0)
                {
                    cmbProduct.DataSource = objResult.ResultDt;
                    cmbProduct.ValueMember = objResult.ResultDt.Columns["ID"].ToString();
                    cmbProduct.DisplayMember = objResult.ResultDt.Columns["ProductName"].ToString();
                }
                else
                {
                    cmbProduct.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
                log.Error("BindProduct Dropdown :" + ex.ToString());
            }
            
        }

        #endregion

        #region Bind Tank No Dropdown
        private void bindTankDropdown()
        {
            try
            {
                MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                ApplicationResult objResult = new ApplicationResult();

                objResult = objLabReportProductBL.TankDropdown();

                if (objResult.ResultDt.Rows.Count > 0)
                {
                    cmbTankNo.DataSource = objResult.ResultDt;
                    cmbTankNo.ValueMember = objResult.ResultDt.Columns["TankID"].ToString();
                    cmbTankNo.DisplayMember = objResult.ResultDt.Columns["TankName"].ToString();
                }
                else
                {
                    cmbTankNo.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
                log.Error("bindTank Dropdown :" + ex.ToString());
            }
        }
        #endregion

        #region Bind Common Data Dropdown
        private void BindCommonDropdown()
        {
            try
            {
                MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                ApplicationResult objResult1 = new ApplicationResult();
                ApplicationResult objResult2 = new ApplicationResult();
                ApplicationResult objResult3 = new ApplicationResult();
                ApplicationResult objResult4 = new ApplicationResult();


                /*  objResult1 for Common Data Dropdown Bind */
                objResult1 = objLabReportProductBL.bindCommonValueDropdown();
                if (objResult1.ResultDt.Rows.Count > 0)
                {
                    cmbPhospharaseTest.DataSource = objResult1.ResultDt;
                    cmbPhospharaseTest.ValueMember = objResult1.ResultDt.Columns["ID"].ToString();
                    cmbPhospharaseTest.DisplayMember = objResult1.ResultDt.Columns["Name"].ToString();
                    cmbPhospharaseTest.SelectedIndex = 0;

                    cmbAdultration.DataSource = objResult1.ResultDt;
                    cmbAdultration.ValueMember = objResult1.ResultDt.Columns["ID"].ToString();
                    cmbAdultration.DisplayMember = objResult1.ResultDt.Columns["Name"].ToString();
                    cmbAdultration.SelectedIndex = 0;

                    cmbBauduinTest.DataSource = objResult1.ResultDt;
                    cmbBauduinTest.ValueMember = objResult1.ResultDt.Columns["ID"].ToString();
                    cmbBauduinTest.DisplayMember = objResult1.ResultDt.Columns["Name"].ToString();
                    cmbBauduinTest.SelectedIndex = 0;
                }
                else
                {
                    cmbPhospharaseTest.Items.Insert(0, "--Select--");
                    cmbPhospharaseTest.SelectedIndex = 0;

                    cmbAdultration.Items.Insert(0, "--Select--");
                    cmbAdultration.SelectedIndex = 0;

                    cmbBauduinTest.Items.Insert(0, "--Select--");
                    cmbBauduinTest.SelectedIndex = 0;
                }

                /* objResult2 for BodyAndTexture Dropdown Bind */
                objResult2 = objLabReportProductBL.bindBodyAndTextureDropdown();

                if (objResult2.ResultDt.Rows.Count > 0)
                {
                    cmbBodyAndTexture.DataSource = objResult2.ResultDt;
                    cmbBodyAndTexture.ValueMember = objResult2.ResultDt.Columns["ID"].ToString();
                    cmbBodyAndTexture.DisplayMember = objResult2.ResultDt.Columns["Name"].ToString();
                    cmbBodyAndTexture.SelectedIndex = 0;
                }
                else
                {
                    cmbBodyAndTexture.Items.Insert(0, "--Select--");
                    cmbBodyAndTexture.SelectedIndex = 0;
                }

                /* objResult3 for Appearance Dropdown Bind */
                objResult3 = objLabReportProductBL.bindAppearanceDropdown();

                if (objResult3.ResultDt.Rows.Count > 0)
                {
                    cmbAppearance.DataSource = objResult3.ResultDt;
                    cmbAppearance.ValueMember = objResult3.ResultDt.Columns["ID"].ToString();
                    cmbAppearance.DisplayMember = objResult3.ResultDt.Columns["Name"].ToString();
                    cmbAppearance.SelectedIndex = 0;
                }
                else
                {
                    cmbAppearance.Items.Insert(0, "--Select--");
                    cmbAppearance.SelectedIndex = 0;
                }

                /* objResult4 for Flavour Dropdown Bind */
                objResult4 = objLabReportProductBL.bindFlavourDropdown();

                if (objResult4.ResultDt.Rows.Count > 0)
                {
                    cmbFlavour.DataSource = objResult4.ResultDt;
                    cmbFlavour.ValueMember = objResult4.ResultDt.Columns["ID"].ToString();
                    cmbFlavour.DisplayMember = objResult4.ResultDt.Columns["Name"].ToString();
                    cmbFlavour.SelectedIndex = 0;
                }
                else
                {
                    cmbFlavour.Items.Insert(0, "--Select--");
                    cmbFlavour.SelectedIndex = 0;
                }

            }
            catch(Exception ex)
            {
                log.Error("Bind Common Dropdown"+ex.ToString());
            }

        }
        #endregion

        #region Enabled True or False Control Base on Product Selection
        private new void  EnabledChanged(MetroFramework.Controls.MetroTextBox textBox)
        {
            if (textBox.Enabled == true)
            {
                textBox.BackColor = Color.White;
                
            }
            else
            {
                textBox.BackColor = Color.LightGray; //same here with the color
              
            }
        }

        private void EnabledChangedDd(MetroFramework.Controls.MetroComboBox comboBox)
        {
            if (comboBox.Enabled == true)
            {
                comboBox.BackColor = Color.White;
                
            }
            else
            {
                comboBox.BackColor = Color.LightGray; //same here with the color
               
            }
        }
        #endregion

        #region Refresh Tank With Latest Value on Refresh Button click Event
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bindTankDropdown();
        }
        #endregion

        #region Radio Button Auto, Manual Checked Change Event
        private void rdoAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAuto.Checked == true)
            {
                txtFat.Enabled = false;
                txtSnf.Enabled = false;
                btnCapture.Enabled = true;
            }
        }

        private void rdoManual_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoManual.Checked == true)
            {
                txtFat.Enabled = true;
                txtSnf.Enabled = true;
                btnCapture.Enabled = false;
            }
        }
        #endregion

        #region Capture Button click Event
        private void btnCapture_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
