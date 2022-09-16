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
    public partial class LabProduct : MetroForm
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LabProduct()
        {
            InitializeComponent();
        }

        private void LabProduct_Load(object sender, EventArgs e)
        {

        }

        #region Update Button Click Event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            BindDropDownProduct();
            btnGroup.Visible = false;
            cmbProduct.Visible = true;
        }
        #endregion

        #region Save Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int intValidate = 0;


                if (btnSave.Text == "Save")
                {
                    if (txtProduct.Text == "")
                    {
                        MetroMessageBox.Show(this, "Enter ProductName", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        objMainLabProductBO.Flavout = Convert.ToBoolean(cFlavour.Checked);
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
                        objMainLabProductBO.AerobicSporecountML = Convert.ToBoolean(cAerobicSporecountML.Checked);
                        objMainLabProductBO.ScorchedParticle = Convert.ToBoolean(cScorchedParticle.Checked);

                        //if (strMode == "New")
                        //{

                        objMainLabProductBO.CreatedByDate = DateTime.UtcNow.AddHours(5.5);
                        objMainLabProductBO.CreatedByID = Convert.ToString(Program.intUserId);
                        objMainLabProductBO.IsDeleted = false;
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

                        //}
                        //else
                        //{
                        //    objMainLabProductBO.ProductID = intid;
                        //    objMainLabProductBO.LastModifiedByDate = DateTime.UtcNow.AddHours(5.5);
                        //    objMainLabProductBO.LastModifiedByID = Convert.ToString(Program.intUserId);
                        //    objResult = objLabReportProductBL.MainLabProduct_Update(objMainLabProductBO);
                        //    if (objResult != null)
                        //    {
                        //        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        //        {
                        //            MetroMessageBox.Show(this, "Record Updated Successfully.", "Lab",
                        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //            //WriteLMPPLC(strTankNo);
                        //            //WriteFERMPLC(strTankNo);
                        //            this.Close();
                        //        }
                        //    }
                        //}

                    }
                }
                else if (btnSave.Text == "Update")
                {
                    MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                    LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                    ApplicationResult objResult = new ApplicationResult();

                    objMainLabProductBO.ProductID = Convert.ToInt32(Convert.ToInt32(cmbProduct.SelectedValue));
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
                    objMainLabProductBO.Flavout = Convert.ToBoolean(cFlavour.Checked);
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
                    objMainLabProductBO.AerobicSporecountML = Convert.ToBoolean(cAerobicSporecountML.Checked);
                    objMainLabProductBO.ScorchedParticle = Convert.ToBoolean(cScorchedParticle.Checked);

                    //if (strMode == "New")
                    //{

                    objMainLabProductBO.LastModifiedByDate = DateTime.UtcNow.AddHours(5.5);
                    objMainLabProductBO.LastModifiedByID = Convert.ToString(Program.intUserId);
                    objMainLabProductBO.IsDeleted = false;
                    objResult = objLabReportProductBL.MainLabProduct_Update(objMainLabProductBO);
                    if (objResult != null)
                    {
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            MetroMessageBox.Show(this, "Record Updated Successfully.", "Lab",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
                else if (btnSave.Text == "Delete") {
                    MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                    LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                    ApplicationResult objResult = new ApplicationResult();

                    objMainLabProductBO.ProductID = Convert.ToInt32(Convert.ToInt32(cmbProduct.SelectedValue));

                    objMainLabProductBO.LastModifiedByDate = DateTime.UtcNow.AddHours(5.5);
                    objMainLabProductBO.LastModifiedByID = Convert.ToString(Program.intUserId);
                    objMainLabProductBO.IsDeleted = false;
                    objResult = objLabReportProductBL.MainLabProduct_Delete(objMainLabProductBO);
                    if (objResult != null)
                    {
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            MetroMessageBox.Show(this, "Record Deleted Successfully.", "Lab",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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

        #region Clear Button Click Event

        private void Clear() 
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
            cFlavour.Checked = false;
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
            cAerobicSporecountML.Checked = false;
            cScorchedParticle.Checked = false;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        #endregion

        #region Close Button Click Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Delete")
            {
                BindDropDownProduct();
                cmbProduct.Visible = true;
                txtProductName.Visible = false;
                txtProduct.Visible = false;
                btnGroup.Visible = false;
                btnSave.Text = "Delete";
                btnDelete.Text = "ADD";
            }
            else if (btnDelete.Text == "ADD")
            {
                cmbProduct.Visible = false;
                txtProductName.Visible = true;
                txtProduct.Visible = true;
                btnGroup.Visible = true;

                Clear();
                btnSave.Text = "Save";
                btnDelete.Text = "Delete";
            }
        }
        #endregion

        #region UpdateBtn
        private void updateBtn_Click(object sender, EventArgs e)
        {
            BindDropDownProduct();
            btnGroup.Visible = false;
            cmbProduct.Visible = true;
            updateBtn.Visible = false;
            BtnAdd.Visible = true;
            txtProductName.Visible = true;
            txtProduct.Visible = true;
            btnSave.Text = "Update";
        }
        #endregion

        #region OnIndex selection
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.ValueMember != null)
            {
                //BindDataToBox(Convert.ToInt32(cmbProduct.ValueMember.ToString()));
                //BindDataToBox(Convert.ToInt32( cmbProduct.SelectedValue));
                if (btnSave.Text == "Update")
                {
                    BindDataToBox(Convert.ToInt32(cmbProduct.SelectedValue));
                    btnGroup.Visible = true;
                    BtnAdd.Visible = true;
                }
                else if (btnSave.Text == "Delete")
                {
                    btnGroup.Visible = false;
                    //btnDelete.Text = "Update";
                }
            }
        }
        #endregion

        #region Updateing Check Box
        private void BindDataToBox(int productID) {

            MainLabProductBO objMainLabProductBO = new MainLabProductBO();
            LabReportProductBL objLabReportProductBL = new LabReportProductBL();
            ApplicationResult objResult = new ApplicationResult();

            objResult = objLabReportProductBL.MainLabProduct_SelectProduct(productID);
            try {
                if (objResult.ResultDt != null)
                {
                    ctemp.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TEMP]);
                    btnGroup.Visible = true;
                    txtProduct.Text = Convert.ToString(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PRODUCTNAME]);
                    ctemp.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TEMP]);
                    cAcidity.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITY]);
                    cFat.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FAT]);
                    cSNF.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SNF]);
                    cMBRT.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MBRT]);
                    cPhosphateTest.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PHOSPHATETEST]);
                    cAlcohol.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ALCOHOL]);
                    cAdultration.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ADULTRATION]);
                    cAerobicplatecountML.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICPLATE]);
                    cColiformcountML.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_COLIFORMCOUTN]);
                    cYeastMoulds.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_YEASTMOULDS]);
                    somaticcellcountML.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SOMATICCELL]);
                    cHomogenazation.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_HOMOGENAZATION]);
                    cRemarks.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_REMARKS]);
                    cVerifiedBy.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_VERIFIEDBY]);
                    cTotalSolids.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALSOLIDS]);
                    cApperarance.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_APPERARANCE]);
                    cFatbymass.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FATBYMASS]);
                    cMoisturebymass.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MOISTUREBYMASS]);
                    curbbymass.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_CURNBYMASS]);
                    cAcidityLAbymass.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITYBYMASS]);
                    cAerobicPlatecountg.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICPLATEBYG]);
                    cColiformCountg.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_COLIFORM]);
                    cYeastMouldsg.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_YEASTMOULDSPERG]);
                    cEcolig.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ECOLIG]);
                    cQuantity.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_QUANTITY]);
                    cBodyTexture.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BODYANDTEXTURE]);
                    cFlavour.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FLAVOUR]);
                    cMoisture.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MOISTURE]);
                    cFFAOA.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FFAOA]);
                    cBRReading.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BRREADING]);
                    cRmvalue.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_RMVALUE]);
                    cPvalue.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PVALUE]);
                    cBaudouest.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BAUDOUINTEST]);
                    cFatondrymatterbassis.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FATONDRYMATTERBASSIS]);
                    cFatbyweight.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FATBYWEIGHT]);
                    cSucrosebyweight.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SUCROSEBYWEIGHT]);
                    cInsolubilityindexprotein.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_INSOLUBILITYINDEXPROTEIN]);
                    cTotalAshdrybasisbymass.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALASHDRYBASISBYMASS]);
                    cAcidityNNaOHofSNF.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITYOGNAOH]);
                    cBulkdensity.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BULKDENSITY]);
                    cPreservativeAdultrants.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PRESERVATIVE]);
                    cPH.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PH]);
                    cCreamingIndex.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_CREAMINGINDEX]);
                    cAerobicSporecountML.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICSPOREML]);
                    cScorchedParticle.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SCORCHEDPARTICLE]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Text Change
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            btnGroup.Visible = true;
            txtProductName.Visible = true;
            txtProduct.Visible = true;
            cmbProduct.Visible = false;
            BtnAdd.Visible = false;
            updateBtn.Visible = true;
            btnSave.Text = "Save";
        }
        #endregion

        private void cBRReading_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
