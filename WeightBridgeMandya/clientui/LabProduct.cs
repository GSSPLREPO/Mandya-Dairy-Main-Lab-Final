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
            BindDropDownProduct();
        }

        #region Update Button Click Event
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
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
                        objMainLabProductBO.Temp = Convert.ToBoolean(chkTemp.Checked);
                        objMainLabProductBO.Acidity = Convert.ToBoolean(chkAcidity.Checked);
                        objMainLabProductBO.Fat = Convert.ToBoolean(chkFat.Checked);
                        objMainLabProductBO.Snf = Convert.ToBoolean(chkSnf.Checked);
                        objMainLabProductBO.Mbrt = Convert.ToBoolean(chkMbrt.Checked);
                        objMainLabProductBO.PhospharaseTest = Convert.ToBoolean(chkPhospharaseTest.Checked);
                        objMainLabProductBO.Alcohol = Convert.ToBoolean(chkAlcohol.Checked);
                        objMainLabProductBO.Adultration = Convert.ToBoolean(chkAdultration.Checked);
                        objMainLabProductBO.AerobicPlate = Convert.ToBoolean(chkAerobicPlateCount.Checked);
                        objMainLabProductBO.Coliform = Convert.ToBoolean(chkColiform.Checked);
                        objMainLabProductBO.YeastAndMoulds = Convert.ToBoolean(chkYeastAndMoulds.Checked);
                        objMainLabProductBO.SomaticCell = Convert.ToBoolean(chkSomaticCell.Checked);
                        objMainLabProductBO.CremingIndex = Convert.ToBoolean(chkCreamingIndex.Checked);
                        objMainLabProductBO.TotalSolid = Convert.ToBoolean(chkTotalSolids.Checked);
                        objMainLabProductBO.Ph = Convert.ToBoolean(chkPH.Checked);
                        objMainLabProductBO.Appearance = Convert.ToBoolean(chkApperarance.Checked);
                        objMainLabProductBO.BodyAndTexture = Convert.ToBoolean(chkBodyTexture.Checked);
                        objMainLabProductBO.Flavuor = Convert.ToBoolean(chkFlavour.Checked);
                        objMainLabProductBO.Moisture = Convert.ToBoolean(chkMoisture.Checked);
                        objMainLabProductBO.FFAOA = Convert.ToBoolean(chkFFAOA.Checked);
                        objMainLabProductBO.BRReading = Convert.ToBoolean(chkBRReading.Checked);
                        objMainLabProductBO.RMValue = Convert.ToBoolean(chkRmvalue.Checked);
                        objMainLabProductBO.PValue = Convert.ToBoolean(chkPvalue.Checked);
                        objMainLabProductBO.BauduinTest = Convert.ToBoolean(chkBaudoinTest.Checked);
                        objMainLabProductBO.EColi = Convert.ToBoolean(chkEcolig.Checked);
                        objMainLabProductBO.SucrosePercent = Convert.ToBoolean(chkSucrose.Checked);
                        objMainLabProductBO.InsolubilityIndex = Convert.ToBoolean(chkInsolubilityIndex.Checked);
                        objMainLabProductBO.Protein = Convert.ToBoolean(chkProtein.Checked);
                        objMainLabProductBO.TotalAsh = Convert.ToBoolean(chkTotalAsh.Checked);
                        objMainLabProductBO.ScorchedParticle = Convert.ToBoolean(chkScorchedParticle.Checked);
                        objMainLabProductBO.BulkDensity = Convert.ToBoolean(chkBulkdensity.Checked);
                        objMainLabProductBO.Wettability = Convert.ToBoolean(chkBulkdensity.Checked);
                        objMainLabProductBO.CreatedByDate = DateTime.UtcNow.AddHours(5.5);
                        objMainLabProductBO.CreatedByID = Convert.ToInt32(Program.intUserId);

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
                }
                else if (btnSave.Text == "Update")
                {
                    MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                    LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                    ApplicationResult objResult = new ApplicationResult();

                    objMainLabProductBO.ProductName = Convert.ToString(txtProduct.Text);
                    objMainLabProductBO.Temp = Convert.ToBoolean(chkTemp.Checked);
                    objMainLabProductBO.Acidity = Convert.ToBoolean(chkAcidity.Checked);
                    objMainLabProductBO.Fat = Convert.ToBoolean(chkFat.Checked);
                    objMainLabProductBO.Snf = Convert.ToBoolean(chkSnf.Checked);
                    objMainLabProductBO.Mbrt = Convert.ToBoolean(chkMbrt.Checked);
                    objMainLabProductBO.PhospharaseTest = Convert.ToBoolean(chkPhospharaseTest.Checked);
                    objMainLabProductBO.Alcohol = Convert.ToBoolean(chkAlcohol.Checked);
                    objMainLabProductBO.Adultration = Convert.ToBoolean(chkAdultration.Checked);
                    objMainLabProductBO.AerobicPlate = Convert.ToBoolean(chkAerobicPlateCount.Checked);
                    objMainLabProductBO.Coliform = Convert.ToBoolean(chkColiform.Checked);
                    objMainLabProductBO.YeastAndMoulds = Convert.ToBoolean(chkYeastAndMoulds.Checked);
                    objMainLabProductBO.SomaticCell = Convert.ToBoolean(chkSomaticCell.Checked);
                    objMainLabProductBO.TotalSolid = Convert.ToBoolean(chkTotalSolids.Checked);
                    objMainLabProductBO.Ph = Convert.ToBoolean(chkPH.Checked);
                    objMainLabProductBO.Appearance = Convert.ToBoolean(chkApperarance.Checked);
                    objMainLabProductBO.BodyAndTexture = Convert.ToBoolean(chkBodyTexture.Checked);
                    objMainLabProductBO.Flavuor = Convert.ToBoolean(chkFlavour.Checked);
                    objMainLabProductBO.Moisture = Convert.ToBoolean(chkMoisture.Checked);
                    objMainLabProductBO.FFAOA = Convert.ToBoolean(chkFFAOA.Checked);
                    objMainLabProductBO.BRReading = Convert.ToBoolean(chkBRReading.Checked);
                    objMainLabProductBO.RMValue = Convert.ToBoolean(chkRmvalue.Checked);
                    objMainLabProductBO.PValue = Convert.ToBoolean(chkPvalue.Checked);
                    objMainLabProductBO.BauduinTest = Convert.ToBoolean(chkBaudoinTest.Checked);
                    objMainLabProductBO.EColi = Convert.ToBoolean(chkEcolig.Checked);
                    objMainLabProductBO.SucrosePercent = Convert.ToBoolean(chkSucrose.Checked);
                    objMainLabProductBO.InsolubilityIndex = Convert.ToBoolean(chkInsolubilityIndex.Checked);
                    objMainLabProductBO.Protein = Convert.ToBoolean(chkProtein.Checked);
                    objMainLabProductBO.TotalAsh = Convert.ToBoolean(chkTotalAsh.Checked);
                    objMainLabProductBO.ScorchedParticle = Convert.ToBoolean(chkScorchedParticle.Checked);
                    objMainLabProductBO.BulkDensity = Convert.ToBoolean(chkBulkdensity.Checked);
                    objMainLabProductBO.Wettability = Convert.ToBoolean(chkBulkdensity.Checked);
                    objMainLabProductBO.LastModifiedByDate = DateTime.UtcNow.AddHours(5.5);
                    objMainLabProductBO.LastModifiedByID = Convert.ToInt32(Program.intUserId);

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

                    objMainLabProductBO.ID = Convert.ToInt32(cmbProduct.SelectedValue.ToString());

                    objMainLabProductBO.LastModifiedByDate = DateTime.UtcNow.AddHours(5.5);
                    objMainLabProductBO.LastModifiedByID = Convert.ToInt32(Program.intUserId);
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
            chkTemp.Checked = false;
            chkAcidity.Checked = false;
            chkFat.Checked = false;
            chkSnf.Checked = false;
            chkMbrt.Checked = false;
            chkPhospharaseTest.Checked = false;
            chkAlcohol.Checked = false;
            chkAdultration.Checked = false;
            chkAerobicPlateCount.Checked = false;
            chkColiform.Checked = false;
            chkYeastAndMoulds.Checked = false;
            chkSomaticCell.Checked = false;
            chkProtein.Checked = false;
            chkWattability.Checked = false;
            chkTotalSolids.Checked = false;
            chkApperarance.Checked = false;
            chkMoisture.Checked = false;
            chkEcolig.Checked = false;
            chkBodyTexture.Checked = false;
            chkFlavour.Checked = false;
            chkFFAOA.Checked = false;
            chkBRReading.Checked = false;
            chkRmvalue.Checked = false;
            chkPvalue.Checked = false;
            chkBaudoinTest.Checked = false;
            chkSucrose.Checked = false;
            chkInsolubilityIndex.Checked = false;
            chkTotalAsh.Checked = false;
            chkBulkdensity.Checked = false;
            chkPH.Checked = false;
            chkCreamingIndex.Checked = false;
            chkScorchedParticle.Checked = false;
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
            try
            {
                MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                ApplicationResult objResult = new ApplicationResult();

                objResult = objLabReportProductBL.MainLabProduct_Select_Product();

                if (objResult.ResultDt.Rows.Count > 0)
                {
                    cmbProduct.Items.Clear();
                    cmbProduct.DataSource = objResult.ResultDt;
                    cmbProduct.ValueMember = objResult.ResultDt.Columns["ID"].ToString();
                    cmbProduct.DisplayMember = objResult.ResultDt.Columns["ProductName"].ToString();
                    
                    visibility(1);
                }
                else
                {
                    visibility(2);
                }
                
            }
            catch (Exception ex)
            {
                log.Error("Bind Product Dropdown :" + ex.ToString());
            }
            
        }


        #endregion

        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region UpdateBtn
        private void updateBtn_Click(object sender, EventArgs e)
        {
            BindDropDownProduct();
        }
        #endregion

        #region OnIndex selection
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ProductID = Convert.ToInt32(cmbProduct.SelectedValue.ToString());
                MainLabProductBO objMainLabProductBO = new MainLabProductBO();
                LabReportProductBL objLabReportProductBL = new LabReportProductBL();
                ApplicationResult objResult = new ApplicationResult();

                objResult = objLabReportProductBL.MainLabProduct_SelectProduct(ProductID);

                if (objResult.ResultDt.Rows.Count > 0)
                {
                    if(objResult.ResultDt.Rows[0][""])
                    visibility(1);
                }

            }
            catch(Exception ex)
            {
                log.Error("Dropdown Selected Index Change: " + ex.ToString());
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
                    chkTemp.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TEMP]);
                    gpProductCheckbox.Visible = true;
                    txtProduct.Text = Convert.ToString(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PRODUCTNAME]);
                    chkTemp.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TEMP]);
                    chkAcidity.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITY]);
                    chkFat.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FAT]);
                    chkSnf.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SNF]);
                    chkMbrt.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MBRT]);
                    chkPhospharaseTest.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PHOSPHARASETEST]);
                    chkAlcohol.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ALCOHOL]);
                    chkAdultration.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ADULTRATION]);
                    chkAerobicPlateCount.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICPLATE]);
                    chkColiform.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_COLIFORM]);
                    chkYeastAndMoulds.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_YESTANDMOULDS]);
                    chkSomaticCell.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SOMATICCELL]);
                    chkTotalSolids.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALSOLID]);
                    chkApperarance.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_APPEARANCE]);
                    chkEcolig.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ECOLI]);
                    chkBodyTexture.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BODYANDTEXTURE]);
                    chkFlavour.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FLAVOUR]);
                    chkFFAOA.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FFAOA]);
                    chkBRReading.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BRREADING]);
                    chkRmvalue.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_RMVALUE]);
                    chkPvalue.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PVALUE]);
                    chkBaudoinTest.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BAUDUINTEST]);
                   
                    chkSucrose.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SUCROSEPERCENT]);
                    chkInsolubilityIndex.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_INSOLUBILITYINDEX]);
                    chkTotalAsh.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALASH]);
                    chkBulkdensity.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BULKDENSITY]);
                    chkPH.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PH]);
                    chkCreamingIndex.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_CREMINGINDEX]);
                    chkScorchedParticle.Checked = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SCORCHEDPARTICLE]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Visibility Method of Page Components
        public void visibility(int Mode)
        {
            if(Mode == 1)
            {
                gpProductCheckbox.Visible = false;
                txtProduct.Visible = false;
                gpButton.Visible = false;
                cmbProduct.Visible = true;
                btnDelete.Visible = false;
                
            }
            else if (Mode == 2)
            {
                gpProductCheckbox.Visible = true;
                txtProduct.Visible = true;
                gpButton.Visible = true;
                cmbProduct.Visible = true;
                btnDelete.Visible = false;
            }
            else if (Mode == 3)
            {

            }
        }
        #endregion

        #region Add New Button Click Event
        /// <summary>
        /// Created By : Chiragkumar Solanki, 29-09-2022
        /// Description : Add new Product 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            visibility(2);
        }
        #endregion


    }
}
