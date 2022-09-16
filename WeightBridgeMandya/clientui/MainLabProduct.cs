using System;
using System.Configuration;
using System.Data;
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


namespace WeightBridgeMandya.clientui
{
    public partial class MainLabProduct : MetroForm
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private string strMode = string.Empty;

        

        #region Declaration
        public string strProductName = "";
        public int intid;
        public int intactivate = 0;
        #endregion

        #region Initialize Component
        public MainLabProduct(int id)
        {
            InitializeComponent();
            
            if (id == -1)
            {
                strMode = "New";
                btnSave.Text = "Save";
                btnClear.Enabled = true;
            }
            else
            {
                strMode = "Edit";
                btnSave.Text = "Update";
                intid = id;
                btnClear.Enabled = false;
            }
        }
        #endregion

        #region Form Load Event
        private void MilkAnalysis_Load(object sender, EventArgs e)
        {
            
            try
            {
                
                /*rdoAuto.Checked = true;
                rdoAuto_CheckedChanged(sender, e);*/

                if (strMode == "Edit")
                {

                    MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                    var objResult = objMainLabAnalysisBL.MainLabAnalysis_Select_For_Edit(intid);

                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {

                        }
                    }
                }
            }

            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion

        #region Save Button Click Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int intValidate = 0;
                if (txtProduct.Text == "")
                {
                    MetroMessageBox.Show(this, "Select ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }

                if (intValidate == 0)
                {
                    MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                    LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                    ApplicationResult objResult = new ApplicationResult();

                    objMainLabProductBO.ProductName = Convert.ToString(txtProduct.Text);
                    objMainLabProductBO.TEMP = Convert.ToBoolean(ctemp.Checked);
                    objMainLabProductBO.Acidity = Convert.ToBoolean(cAcidity.Checked);
                    objMainLabProductBO.FAT = Convert.ToBoolean(cFat.Checked);
                    objMainLabProductBO.SNF = Convert.ToBoolean(cSNF.Checked);
                    objMainLabProductBO.MBRT = Convert.ToBoolean(cMBRT.Checked);
                    objMainLabProductBO.PhosphateTest = Convert.ToBoolean(cPhosphateTest.Checked);
                    objMainLabProductBO.Alcohol = Convert.ToBoolean(cAlcohol.Checked);
                    objMainLabProductBO.Adultration = Convert.ToBoolean(cAdultration.Checked);
                    objMainLabProductBO.AerobicplatecountML = Convert.ToBoolean(cAerobicplatecountML.Checked);
                    objMainLabProductBO.ColiformcountML = Convert.ToBoolean(cColiformcountML.Checked);
                    objMainLabProductBO.YeastMoulds = Convert.ToBoolean(cYeastMoulds.Checked);
                    objMainLabProductBO.somaticcellcountML = Convert.ToBoolean(somaticcellcountML.Checked);
                    objMainLabProductBO.Homogenazation = Convert.ToBoolean(cHomogenazation.Checked);
                    objMainLabProductBO.Remarks = Convert.ToBoolean(cRemarks.Checked);
                    objMainLabProductBO.VerifiedBy = Convert.ToBoolean(cVerifiedBy.Checked);
                    objMainLabProductBO.TotalSolids = Convert.ToBoolean(cTotalSolids.Checked);
                    objMainLabProductBO.Apperarance = Convert.ToBoolean(cApperarance.Checked);
                    objMainLabProductBO.Fatbymass = Convert.ToBoolean(cFatbymass.Checked);
                    objMainLabProductBO.Moisturebymass = Convert.ToBoolean(cMoisturebymass.Checked);
                    objMainLabProductBO.curbbymass = Convert.ToBoolean(curbbymass.Checked);
                    objMainLabProductBO.AcidityLAbymass = Convert.ToBoolean(cAcidityLAbymass.Checked);
                    objMainLabProductBO.AerobicPlatecountg = Convert.ToBoolean(cAerobicPlatecountg.Checked);
                    objMainLabProductBO.Coliformcountg = Convert.ToBoolean(cColiformCountg.Checked);
                    objMainLabProductBO.YeastMouldsg = Convert.ToBoolean(cYeastMouldsg.Checked);
                    objMainLabProductBO.ecolig = Convert.ToBoolean(cEcolig.Checked);
                    objMainLabProductBO.Quantity = Convert.ToBoolean(cQuantity.Checked);
                    objMainLabProductBO.BodyTexture = Convert.ToBoolean(cBodyTexture.Checked);
                    objMainLabProductBO.Flavout = Convert.ToBoolean(cFlavout.Checked);
                    objMainLabProductBO.Moisture = Convert.ToBoolean(cMoisture.Checked);
                    objMainLabProductBO.FFAOA = Convert.ToBoolean(cFFAOA.Checked);
                    objMainLabProductBO.BRReading = Convert.ToBoolean(cBRReading.Checked);
                    objMainLabProductBO.Rmvalue = Convert.ToBoolean(cRmvalue.Checked);
                    objMainLabProductBO.pvalue = Convert.ToBoolean(cPvalue.Checked);
                    objMainLabProductBO.BaudouinTest = Convert.ToBoolean(cBaudouest.Checked);
                    objMainLabProductBO.fatondrymatterbassis = Convert.ToBoolean(cFatondrymatterbassis.Checked);
                    objMainLabProductBO.fatbyweight = Convert.ToBoolean(cFatbyweight.Checked);
                    objMainLabProductBO.sucrosebyweight = Convert.ToBoolean(cSucrosebyweight.Checked);
                    objMainLabProductBO.insolubilityindexprotein = Convert.ToBoolean(cInsolubilityindexprotein.Checked);
                    objMainLabProductBO.TotalAshdrybasisbymass = Convert.ToBoolean(cTotalAshdrybasisbymass.Checked);
                    objMainLabProductBO.AcidityNNaOHofSNF = Convert.ToBoolean(cAcidityNNaOHofSNF.Checked);
                    objMainLabProductBO.bulkdensity = Convert.ToBoolean(cBulkdensity.Checked);
                    objMainLabProductBO.preservativeAdultrants = Convert.ToBoolean(cPreservativeAdultrants.Checked);
                    objMainLabProductBO.PH = Convert.ToBoolean(cPH.Checked);
                    objMainLabProductBO.creamingIndex = Convert.ToBoolean(cCreamingIndex.Checked);



                    if (strMode == "New")
                    {

                        objMainLabProductBO.CreatedByDate = DateTime.UtcNow.AddHours(5.5);
                        objMainLabProductBO.CreatedByID = Convert.ToString(Program.intUserId);
                        objMainLabProductBO.IsDeleted =false;
                        objResult = objLabReportProductBL.MainLabProduct_Insert(objMainLabProductBO);
                        if (objResult != null)
                        {
                            if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                            {
                                MetroMessageBox.Show(this, "Record Saved Successfully.", "Lab",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }

                    }
                    else
                    {
                        objMainLabProductBO.ProductID = intid;
                        objMainLabProductBO.LastModifiedByDate = DateTime.UtcNow.AddHours(5.5);
                        objMainLabProductBO.LastModifiedByID = Convert.ToString(Program.intUserId);
                        objResult = objLabReportProductBL.MainLabProduct_Update(objMainLabProductBO);
                        if (objResult != null)
                        {
                            if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                            {
                                MetroMessageBox.Show(this, "Record Updated Successfully.", "Lab",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //WriteLMPPLC(strTankNo);
                                //WriteFERMPLC(strTankNo);
                                this.Close();
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Close Button Click Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Clear Button Click Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProduct.Text = string.Empty;
            ctemp.Checked = false;
            cAcidity.Checked = false;
            cFat.Checked = false;
            cSNF.Checked = false;
            cMBRT.Checked = false;
            cPhosphateTest.Checked = false;
            cAlcohol.Checked = false;
            cAdultration.Checked = false;
            cAerobicplatecountML.Checked = false;
            cColiformcountML.Checked = false;
            cYeastMoulds.Checked = false;
            somaticcellcountML.Checked = false;
            cHomogenazation.Checked = false;
            cRemarks.Checked = false;
            cVerifiedBy.Checked = false;
            cTotalSolids.Checked = false;
            cApperarance.Checked = false;
            cFatbymass.Checked = false;
            cMoisturebymass.Checked = false;
            curbbymass.Checked = false;
            cAcidityLAbymass.Checked = false;
            cAerobicPlatecountg.Checked = false;
            cColiformCountg.Checked = false;
            cYeastMouldsg.Checked = false;
            cEcolig.Checked = false;
            cQuantity.Checked = false;
            cBodyTexture.Checked = false;
            cFlavout.Checked = false;
            cMoisture.Checked = false;
            cFFAOA.Checked = false;
            cBRReading.Checked = false;
            cRmvalue.Checked = false;
            cPvalue.Checked = false;
            cBaudouest.Checked = false;
            cFatondrymatterbassis.Checked = false;
            cFatbyweight.Checked = false;
            cSucrosebyweight.Checked = false;
            cInsolubilityindexprotein.Checked = false;
            cTotalAshdrybasisbymass.Checked = false;
            cAcidityNNaOHofSNF.Checked = false;
            cBulkdensity.Checked = false;
            cPreservativeAdultrants.Checked = false;
            cPH.Checked = false;
            cCreamingIndex.Checked = false;
        }
        #endregion

        #region on Bind Product

        private void BindDropDownProduct()
        {
            MainLabProductBO objMainLabProductBO = new MainLabProductBO();
            LabReportProductBL objLabReportProductBL = new LabReportProductBL();
            ApplicationResult objResult = new ApplicationResult();

            objResult = objLabReportProductBL.MainLabProduct_Select_Product();

            cmbProduct.DataSource = objResult.ResultDt;

            cmbProduct.ValueMember = objResult.ResultDt.Columns["ProductID"].ToString();
            cmbProduct.DisplayMember = objResult.ResultDt.Columns["ProductName"].ToString();
        }

        #endregion

        #region on delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            cmbProduct.Visible = true;
        }
        #endregion

        #region Update
        private void btnUpdate_OnClick(object sender, EventArgs e)
        {
            
            cmbProduct.Visible = true;
            BindDropDownProduct(); 
            MainLabProduct mainLabProduct = new MainLabProduct(intid);
            this.Activate();
            this.Show();
        }


        #endregion

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
