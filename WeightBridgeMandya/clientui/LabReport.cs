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
        public string strMode;
        public int intid;
        public DateTime tempDate;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable dtStatus = new DataTable();

        public LabReport(int Id)
        {
            InitializeComponent();

            if (Id == -1)
            {
                strMode = "New";
                btnSave.Text = "Save";
                btnClear.Enabled = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                rdoAuto.Checked = true;
            }
            else
            {
                strMode = "Edit";
                btnSave.Text = "Update";
                btnClear.Enabled = false;
                intid = Id;
            }
        }

        #region Form Load Event

        private void LabReport_Load(object sender, EventArgs e)
        {
            try
            {

                BindDropDownProduct();
                bindTankDropdown();
                BindCommonDropdown();
                setDefaultValue();
                defineDataTable();
                bindRow();
                bindCombobox();

                if (strMode == "Edit")
                {
                    MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                    var objResult = objMainLabAnalysisBL.MainLabAnalysis_Select_For_Edit(intid);

                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        BindDataToBox(Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_PRODUCTID]));

                        tempDate = Convert.ToDateTime(objResult.ResultDt.Rows[0]["Date"].ToString() + " " + objResult.ResultDt.Rows[0]["Time"].ToString());
                        btnRefresh.Enabled = false;
                        cmbTankNo.Enabled = false;
                        cmbProduct.Enabled = false;
                        dtDate.Text = objResult.ResultDt.Rows[0]["Date"].ToString();
                        dtTime.Text = objResult.ResultDt.Rows[0]["Time"].ToString();
                        cmbTankNo.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_TANKID]);
                        cmbProduct.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_PRODUCTID]);
                        txtBatchNo.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_BATCHNO].ToString();
                        txtTemp.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_TEMP].ToString();
                        txtAcidity.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_ACIDITY].ToString();
                        txtFat.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_FAT].ToString();
                        txtSnf.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_SNF].ToString();
                        txtMbrt.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_MBRT].ToString();
                        cmbAdultration.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_ADULTRATION]);
                        txtAerobicPlate.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_AEROBICPLATE].ToString();
                        cmbPhospharaseTest.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_PHOSPHARASETEST]);
                        txtAlcohol.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_ALCOHOL].ToString();
                        txtColiform.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_COLIFORM].ToString();
                        txtSomaticCell.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_SOMATICCELL].ToString();
                        txtCremingIndex.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_CREMINGINDEX].ToString();
                        txtTotalSolid.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_TOTALSOLID].ToString();
                        txtBulkDensity.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_BULKDENSITY].ToString();
                        txtPh.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_PH].ToString();
                        txtBRReading.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_BRREADING].ToString();
                        txtMoisture.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_MOISTURE].ToString();
                        txtFFAOA.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_FFAOA].ToString();
                        txtProtein.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_PROTEIN].ToString();
                        txtScorchedParticle.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_SCORCHEDPARTICLE].ToString();
                        txtRMValue.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_RMVALUE].ToString();
                        txtPValue.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_PVALUE].ToString();
                        cmbBauduinTest.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_BAUDUINTEST]);
                        txtSucrosePercent.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_SUCROSEPERCENT].ToString();
                        txtEColi.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_ECOLI].ToString();
                        txtInsolubilityIndex.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_INSOLUBILITYINDEX].ToString();
                        txtTotalAsh.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_TOTALASH].ToString();
                        txtWettability.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_WETTABILITY].ToString();
                        cmbBodyAndTexture.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_BODYANDTEXTURE]);
                        cmbFlavour.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_FLAVOUR]);
                        cmbAppearance.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_APPEARANCE]);
                        cmbStatus.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_STATUS]);
                        txtRemarks.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_REMARKS].ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("Load Event :" + ex.ToString());
            }

        }
        #endregion

        #region Define DataTable
        private void defineDataTable()
        {

            dtStatus.Columns.Add("Id", typeof(int));
            dtStatus.Columns.Add("Status", typeof(string));

        }
        #endregion

        #region Define Table Row
        public void bindRow()
        {
            dtStatus.Rows.Add(0, "Accepted");
            dtStatus.Rows.Add(1, "Not Accepted");
        }

        #endregion

        #region Bind Combobox
        public void bindCombobox()
        {

            cmbStatus.DataSource = dtStatus;
            cmbStatus.ValueMember = dtStatus.Columns["Id"].ToString();
            cmbStatus.DisplayMember = dtStatus.Columns["Status"].ToString();

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

                objMainLabAnalysisBO.DateTime = Convert.ToDateTime(dtDate.Text + " " + dtTime.Text);
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
                objMainLabAnalysisBO.CremingIndex = float.Parse(txtCremingIndex.Text.Trim());
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
                objMainLabAnalysisBO.Status = cmbStatus.SelectedIndex;
                objMainLabAnalysisBO.Remarks = txtRemarks.Text.Trim();

                if (strMode == "New")
                {
                    objMainLabAnalysisBO.CreatedByID = Convert.ToInt32(Program.intUserId.ToString());
                    objMainLabAnalysisBO.CreatedByDate = Convert.ToDateTime(DateTime.Now.ToString());
                    objResult = objMainLabAnalysisBL.MainLabAnalysis_Insert(objMainLabAnalysisBO);

                    string Status = string.Empty, TankName = string.Empty;
                    Status = cmbStatus.Text.ToString();
                    TankName = cmbTankNo.Text.ToString();
                    if (objResult != null)
                    {
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {

                            if (objMainLabAnalysisBO.Status == 0)
                            {
                                WriteLMPPLC(TankName, float.Parse(txtFat.Text), float.Parse(txtSnf.Text), Status);
                                WriteFERMPLC(TankName, float.Parse(txtFat.Text), float.Parse(txtSnf.Text), Status);
                            }

                            MetroMessageBox.Show(this, "Record Saved Successfully.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Error Data Not Saved.", "Lab",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                else if (strMode == "Edit")
                {
                    objMainLabAnalysisBO.MainLabID = intid;
                    objMainLabAnalysisBO.LastModifiedByID = Convert.ToInt32(Program.intUserId.ToString());
                    objMainLabAnalysisBO.LastModifiedByDate = Convert.ToDateTime(DateTime.Now.ToString());
                    objResult = objMainLabAnalysisBL.MainLabAnalysis_Update(objMainLabAnalysisBO);
                    if (objResult != null)
                    {
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {

                            if (objMainLabAnalysisBO.Status == 0)
                            {
                                WriteLMPPLC(cmbTankNo.SelectedText, float.Parse(txtFat.Text), float.Parse(txtSnf.Text), cmbStatus.SelectedText);
                                WriteFERMPLC(cmbTankNo.SelectedText, float.Parse(txtFat.Text), float.Parse(txtSnf.Text), cmbStatus.SelectedText);
                            }
                            MetroMessageBox.Show(this, "Record Updated Successfully.", "Lab",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();

                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Error Data Not Updated.", "Lab",
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

        #region Product ComboBox Selected Index Change Event 
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdoAuto_CheckedChanged(sender, e);
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
                if (objResult.ResultDt.Rows.Count > 0)
                {

                    groupBox2.Visible = true;
                    groupBox3.Visible = true;
                    txtTemp.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TEMP]);
                    EnabledChanged(txtTemp);
                    txtAcidity.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITY]);
                    EnabledChanged(txtAcidity);
                    txtFat.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FAT]);
                    EnabledChanged(txtFat);
                    txtFat.Enabled = false;
                    txtSnf.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SNF]);
                    EnabledChanged(txtSnf);
                    txtSnf.Enabled = false;
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
                ApplicationResult objResult1_2 = new ApplicationResult();
                ApplicationResult objResult1_3 = new ApplicationResult();
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

                }
                else
                {
                    cmbPhospharaseTest.Items.Insert(0, "--Select--");
                    cmbPhospharaseTest.SelectedIndex = 0;

                }

                objResult1_2 = objLabReportProductBL.bindCommonValueDropdown();
                if (objResult1_2.ResultDt.Rows.Count > 0)
                {
                    cmbAdultration.DataSource = objResult1_2.ResultDt;
                    cmbAdultration.ValueMember = objResult1_2.ResultDt.Columns["ID"].ToString();
                    cmbAdultration.DisplayMember = objResult1_2.ResultDt.Columns["Name"].ToString();
                    cmbAdultration.SelectedIndex = 0;

                }
                else
                {
                    cmbAdultration.Items.Insert(0, "--Select--");
                    cmbAdultration.SelectedIndex = 0;

                }

                objResult1_3 = objLabReportProductBL.bindCommonValueDropdown();
                if (objResult1_3.ResultDt.Rows.Count > 0)
                {
                    cmbBauduinTest.DataSource = objResult1_3.ResultDt;
                    cmbBauduinTest.ValueMember = objResult1_3.ResultDt.Columns["ID"].ToString();
                    cmbBauduinTest.DisplayMember = objResult1_3.ResultDt.Columns["Name"].ToString();
                    cmbBauduinTest.SelectedIndex = 0;
                }
                else
                {
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
            catch (Exception ex)
            {
                log.Error("Bind Common Dropdown" + ex.ToString());
            }

        }
        #endregion

        #region Enabled True or False Control Base on Product Selection
        private new void EnabledChanged(MetroFramework.Controls.MetroTextBox textBox)
        {
            if (textBox.Enabled == true)
            {
                textBox.BackColor = Color.White;
            }
            else
            {
                textBox.BackColor = Color.DarkGray;
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
                comboBox.BackColor = Color.DarkGray;

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
            else
            {
                txtFat.Enabled = true;
                txtSnf.Enabled = true;
                btnCapture.Enabled = false;
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
            else
            {
                txtFat.Enabled = false;
                txtSnf.Enabled = false;
                btnCapture.Enabled = true;
            }
        }
        #endregion

        #region Capture Button click Event
        private void btnCapture_Click(object sender, EventArgs e)
        {
            readCSV();
        }
        #endregion

        #region Read CSV file for Fat and SNF
        private void readCSV()
        {
            try
            {
                /*----- Select Most Recent Created File -------*/

                string pattern = "*.csv";
                //var directory = new DirectoryInfo(@"D:\CSVFile\");
                var directory = new DirectoryInfo(@"\\DESKTOP-86CIR8M\MISData\");
                var myFile = (from f in directory.GetFiles(pattern)
                              orderby f.LastWriteTime descending
                              select f).First();

                string fileName = directory + myFile.ToString();

                StreamReader streamReader = new StreamReader(fileName);
                string[] totalData = new string[File.ReadAllLines(fileName).Length];

                while (!streamReader.EndOfStream)
                {
                    totalData = streamReader.ReadLine().Split(',');
                    // string date = totalData[0];
                    // string id = totalData[1];
                    string fat = totalData[2];
                    string snf = totalData[3];
                    txtFat.Text = fat;
                    txtSnf.Text = snf;
                }
                streamReader.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Data Not Found", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Write Data In LMP PLC Fat, Snf and Status
        private void WriteLMPPLC(string strTankNo, float flFat, float flSnf, string Status)
        {
            try
            {
                // Declare Variable for PLC Connection
                Plc plc = null;
                string ip = "172.168.0.1";
                string cputype = "S7400";
                int Rack = 0;
                int Slot = 5;
                float fat = flFat;
                float snf = flSnf;
                string strStatus = Status;
                bool status;
                int timeDelay = 3000;

                if (strStatus == "Accepted")
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

                // Initialize for Cpu and plc connection
                CpuType cpu = (CpuType)Enum.Parse(typeof(CpuType), cputype);
                plc = new Plc(cpu, ip, Convert.ToInt16(Rack), Convert.ToInt16(Slot));
                try
                {
                    plc.Open();
                }
                catch (PlcException)
                {
                    log.Error("PLC Connection Open Fails");
                    //MessageBox.Show("PLC Connection Open Fails", MessageBoxIcon.Error.ToString());
                }

                if (plc.IsConnected)
                {
                    if (strTankNo == "A21TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 104, fat);
                        plc.Write(DataType.DataBlock, 64, 108, snf);
                        plc.Write("DB64.DBX114.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX114.0", false);
                        }
                    }
                    else if (strTankNo == "A22TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 116, fat);
                        plc.Write(DataType.DataBlock, 64, 120, snf);
                        plc.Write("DB64.DBX126.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX126.0", false);
                        }
                    }
                    else if (strTankNo == "A23TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 128, fat);
                        plc.Write(DataType.DataBlock, 64, 132, snf);
                        plc.Write("DB64.DBX138.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX138.0", false);
                        }
                    }
                    else if (strTankNo == "A24TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 140, fat);
                        plc.Write(DataType.DataBlock, 64, 144, snf);
                        plc.Write("DB64.DBX150.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX150.0", false);
                        }
                    }
                    else if (strTankNo == "B21TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 152, fat);
                        plc.Write(DataType.DataBlock, 64, 156, snf);
                        plc.Write("DB64.DBX162.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX162.0", false);
                        }
                    }
                    else if (strTankNo == "B22TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 164, fat);
                        plc.Write(DataType.DataBlock, 64, 168, snf);
                        plc.Write("DB64.DBX174.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX174.0", false);
                        }
                    }
                    else if (strTankNo == "B23TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 176, fat);
                        plc.Write(DataType.DataBlock, 64, 180, snf);
                        plc.Write("DB64.DBX186.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX186.0", false);
                        }
                    }
                    else if (strTankNo == "B24TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 188, fat);
                        plc.Write(DataType.DataBlock, 64, 192, snf);
                        plc.Write("DB64.DBX198.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX198.0", false);
                        }
                    }
                    else if (strTankNo == "B51TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 200, fat);
                        plc.Write(DataType.DataBlock, 64, 204, snf);
                        plc.Write("DB64.DBX210.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX210.0", false);
                        }
                    }
                    else if (strTankNo == "B52TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 212, fat);
                        plc.Write(DataType.DataBlock, 64, 216, snf);
                        plc.Write("DB64.DBX222.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX222.0", false);
                        }
                    }
                    else if (strTankNo == "B53TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 224, fat);
                        plc.Write(DataType.DataBlock, 64, 228, snf);
                        plc.Write("DB64.DBX234.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX234.0", false);
                        }
                    }
                    else if (strTankNo == "B54TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 236, fat);
                        plc.Write(DataType.DataBlock, 64, 240, snf);
                        plc.Write("DB64.DBX246.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX246.0", false);
                        }
                    }
                    else if (strTankNo == "C21TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 248, fat);
                        plc.Write(DataType.DataBlock, 64, 252, snf);
                        plc.Write("DB64.DBX258.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX258.0", false);
                        }
                    }
                    else if (strTankNo == "C22TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 260, fat);
                        plc.Write(DataType.DataBlock, 64, 264, snf);
                        plc.Write("DB64.DBX270.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX270.0", false);
                        }
                    }
                    else if (strTankNo == "C41TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 272, fat);
                        plc.Write(DataType.DataBlock, 64, 276, snf);
                        plc.Write("DB64.DBX282.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX282.0", false);
                        }
                    }
                    else if (strTankNo == "C42TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 284, fat);
                        plc.Write(DataType.DataBlock, 64, 288, snf);
                        plc.Write("DB64.DBX294.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX294.0", false);
                        }
                    }
                    else if (strTankNo == "C43TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 296, fat);
                        plc.Write(DataType.DataBlock, 64, 300, snf);
                        plc.Write("DB64.DBX306.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX306.0", false);
                        }
                    }
                    else if (strTankNo == "B31TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 308, fat);
                        plc.Write(DataType.DataBlock, 64, 312, snf);
                        plc.Write("DB64.DBX318.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX318.0", false);
                        }
                    }
                    else if (strTankNo == "B32TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 320, fat);
                        plc.Write(DataType.DataBlock, 64, 324, snf);
                        plc.Write("DB64.DBX330.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX330.0", false);
                        }
                    }
                    else if (strTankNo == "B33TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 332, fat);
                        plc.Write(DataType.DataBlock, 64, 336, snf);
                        plc.Write("DB64.DBX342.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX342.0", false);
                        }
                    }
                    else if (strTankNo == "B34TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 344, fat);
                        plc.Write(DataType.DataBlock, 64, 348, snf);
                        plc.Write("DB64.DBX354.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX354.0", false);
                        }
                    }
                    else if (strTankNo == "G21TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 356, fat);
                        plc.Write(DataType.DataBlock, 64, 360, snf);
                        plc.Write("DB64.DBX366.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX366.0", false);
                        }
                    }
                    else if (strTankNo == "G22TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 368, fat);
                        plc.Write(DataType.DataBlock, 64, 372, snf);
                        plc.Write("DB64.DBX378.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX378.0", false);
                        }
                    }
                    else if (strTankNo == "G23TK001")
                    {
                        plc.Write(DataType.DataBlock, 64, 380, fat);
                        plc.Write(DataType.DataBlock, 64, 384, snf);
                        plc.Write("DB64.DBX390.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB64.DBX390.0", false);
                        }
                    }
                    // Close connection with PLC LMP
                    if (plc.IsConnected)
                    {
                        plc.Close();
                    }

                }
                else
                {
                    MessageBox.Show("LMP PLC Connection Fail.", MessageBoxIcon.Error.ToString());
                }

            }
            catch (PlcException ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Write Data In FERM PLC Fat, Snf and Status
        private void WriteFERMPLC(string strTankNo, float flFat, float flSnf, string Status)
        {
            try
            {
                // Declare Variable for PLC Connection
                Plc plc = null;
                string ip = "172.168.0.3";
                string cputype = "S7400";
                int Rack = 0;
                int Slot = 5;
                float fat = flFat;
                float snf = flSnf;
                string strStatus = Status;
                bool status;
                int timeDelay = 3000;

                if (strStatus == "Accepted")
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

                // Initialize for Cpu and plc connection
                CpuType cpu = (CpuType)Enum.Parse(typeof(CpuType), cputype);
                plc = new Plc(cpu, ip, Convert.ToInt16(Rack), Convert.ToInt16(Slot));
                try
                {
                    plc.Open();
                }
                catch (PlcException)
                {

                    //MessageBox.Show("PLC Connection Open Fails", MessageBoxIcon.Error.ToString());
                }


                if (plc.IsConnected)
                {
                    if (strTankNo == "B61TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 128, fat);
                        plc.Write(DataType.DataBlock, 13, 132, snf);
                        plc.Write("DB13.DBX138.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX138.0", false);
                        }
                    }
                    else if (strTankNo == "B62TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 140, fat);
                        plc.Write(DataType.DataBlock, 13, 144, snf);
                        plc.Write("DB13.DBX150.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX150.0", false);
                        }
                    }
                    else if (strTankNo == "D10TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 152, fat);
                        plc.Write(DataType.DataBlock, 13, 156, snf);
                        plc.Write("DB13.DBX162.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX162.0", false);
                        }
                    }
                    else if (strTankNo == "D11TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 164, fat);
                        plc.Write(DataType.DataBlock, 13, 168, snf);
                        plc.Write("DB13.DBX174.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX174.0", false);
                        }
                    }
                    else if (strTankNo == "D12TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 176, fat);
                        plc.Write(DataType.DataBlock, 13, 180, snf);
                        plc.Write("DB13.DBX186.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX186.0", false);
                        }
                    }
                    else if (strTankNo == "F31TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 188, fat);
                        plc.Write(DataType.DataBlock, 13, 192, snf);
                        plc.Write("DB13.DBX198.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX198.0", false);
                        }
                    }
                    else if (strTankNo == "F32TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 200, fat);
                        plc.Write(DataType.DataBlock, 13, 204, snf);
                        plc.Write("DB13.DBX210.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX210.0", false);
                        }
                    }
                    else if (strTankNo == "F33TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 212, fat);
                        plc.Write(DataType.DataBlock, 13, 216, snf);
                        plc.Write("DB13.DBX222.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX222.0", false);
                        }
                    }
                    else if (strTankNo == "F11TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 224, fat);
                        plc.Write(DataType.DataBlock, 13, 228, snf);
                        plc.Write("DB13.DBX234.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX234.0", false);
                        }
                    }
                    else if (strTankNo == "F12TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 236, fat);
                        plc.Write(DataType.DataBlock, 13, 240, snf);
                        plc.Write("DB13.DBX246.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX246.0", false);
                        }
                    }
                    else if (strTankNo == "F13TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 248, fat);
                        plc.Write(DataType.DataBlock, 13, 252, snf);
                        plc.Write("DB13.DBX258.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX258.0", false);
                        }
                    }
                    else if (strTankNo == "T61TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 260, fat);
                        plc.Write(DataType.DataBlock, 13, 264, snf);
                        plc.Write("DB13.DBX270.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX270.0", false);
                        }
                    }
                    else if (strTankNo == "H11TK001")
                    {
                        plc.Write(DataType.DataBlock, 13, 272, fat);
                        plc.Write(DataType.DataBlock, 13, 276, snf);
                        plc.Write("DB13.DBX282.0", status);
                        if (status == true)
                        {
                            Thread.Sleep(timeDelay);
                            plc.Write("DB13.DBX282.0", false);
                        }
                    }
                    // Close Connection with PLC FERM
                    if (plc.IsConnected)
                    {
                        plc.Close();
                    }
                }
                else
                {
                    MessageBox.Show("FERM PLC Connection Fail.", MessageBoxIcon.Error.ToString());
                }



            }
            catch (PlcException ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Form Close Event
        private void LabReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            EditDeleteData frmEditDeleteData = new EditDeleteData();
            frmEditDeleteData.Show();

        }
        #endregion

        #region Take Numeric Value only
        public void takeNumber(object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
           
        }

        public void takeNumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
        #endregion

        #region Textbox KeyPress Event
        private void txtTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtAcidity_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtFat_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtSnf_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtMbrt_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtAerobicPlate_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumberOnly(sender, e);
        }

        private void txtAlcohol_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtColiform_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtSomaticCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumberOnly(sender, e);
        }

        private void txtCremingIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtTotalSolid_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtBulkDensity_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtPh_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtBRReading_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtMoisture_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtFFAOA_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtProtein_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtScorchedParticle_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtRMValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtPValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtSucrosePercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtEColi_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtInsolubilityIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtTotalAsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }

        private void txtWettability_KeyPress(object sender, KeyPressEventArgs e)
        {
            takeNumber(sender, e);
        }
        #endregion
    }
}
