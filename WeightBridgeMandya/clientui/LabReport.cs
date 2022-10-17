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
            mode = "Save";
        }
        #endregion

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
                    }

                }

            }
            catch (Exception ex)
            {
                log.Error("Save Button Click : " + ex.ToString());
            }
           
        }

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

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDataToBox(Convert.ToInt32(cmbProduct.SelectedValue));
        }

        #region Updating Check Box
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
                    txtAcidity.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITY]);
                    txtFat.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FAT]);
                    txtSnf.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SNF]);
                    txtMbrt.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MBRT]);
                    cmbAdultration.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ADULTRATION]);
                    txtAerobicPlate.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICPLATE]);
                    cmbPhospharaseTest.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PHOSPHARASETEST]);
                    txtAlcohol.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ALCOHOL]);
                    txtColiform.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_COLIFORM]);
                    txtSomaticCell.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SOMATICCELL]);
                    txtCremingIndex.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_CREMINGINDEX]);
                    txtTotalSolid.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALSOLID]);
                    cmbAppearance.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_APPEARANCE]);
                    txtPh.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PH]);
                    cmbFlavour.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FLAVOUR]);
                    txtMoisture.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MOISTURE]);
                    txtFFAOA.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FFAOA]);
                    cmbBodyAndTexture.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BODYANDTEXTURE]);
                    txtScorchedParticle.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SCORCHEDPARTICLE]);
                    txtRMValue.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_RMVALUE]);
                    txtPValue.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PVALUE]);
                    cmbBauduinTest.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BAUDUINTEST]);
                    txtSucrosePercent.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SUCROSEPERCENT]);
                    txtProtein.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PROTEIN]);
                    txtInsolubilityIndex.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_INSOLUBILITYINDEX]);
                    txtTotalAsh.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALASH]);
                    txtWettability.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_WETTABILITY]);
                    txtEColi.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ECOLI]);
                    txtBRReading.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BRREADING]);
                    txtBulkDensity.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BULKDENSITY]);
                   
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
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

        #region BindRow
        private void BindData()
        {

            //cPhosphateTest.Items.Insert(0, "+VE");
            //cPhosphateTest.Items.Insert(1, "-VE");

            //cPreservative.Items.Insert(0, "+VE");
            //cPreservative.Items.Insert(1, "-VE");

            //Adultration.Items.Insert(0, "+VE");
            //Adultration.Items.Insert(1, "-VE");

            //cEcoli.Items.Insert(0, "+VE");
            //cEcoli.Items.Insert(1, "-VE");

            //cBaudiniTest.Items.Insert(0, "+VE");
            //cBaudiniTest.Items.Insert(1, "-VE");

        }
        #endregion

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private new void EnabledChanged(MetroFramework.Controls.MetroTextBox box)
        {
            if (box.Enabled == false)
            {
                box.BackColor = Color.LightGray;
            }
            else
            {
                box.BackColor = Color.White; //same here with the color
            }
        }

        private void EnabledChangedDd(MetroFramework.Controls.MetroComboBox box)
        {
            if (box.Enabled == false)
            {
                box.BackColor = Color.LightGray;
            }
            else
            {
                box.BackColor = Color.White; //same here with the color
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bindTankDropdown();
        }
    }
}
