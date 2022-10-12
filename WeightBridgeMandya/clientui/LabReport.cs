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

namespace WeightBridgeMandya.clientui
{
    public partial class LabReport : MetroForm
    {
        public LabReport()
        {
            InitializeComponent();
            
        }

        #region Form Load Event

        private void LabReport_Load(object sender, EventArgs e)
        {
           // BindDropDownProduct();
            //BindData();
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            //int validate = 1;
            //if (validateFields(validate))
            //{
            //    MetroMessageBox.Show(this, "Success", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else {
            //    MetroMessageBox.Show(this, "Error", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        #region Close Button Click Event
        private void btnClose_Click(object sender, EventArgs e)
        {
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
                if (objResult.ResultDt != null)
                {
                    //txtTEMP.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TEMP]);
                    //EnabledChanged(txtTEMP);
                   
                    //txtAcidity.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITY]);
                    //EnabledChanged(txtAcidity);
                    //txtFat.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FAT]);
                    //EnabledChanged(txtFat);
                    //txtSNF.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SNF]);
                    //EnabledChanged(txtSNF);
                    //txtMBRT.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MBRT]);
                    //EnabledChanged(txtMBRT);
                    //cPhosphateTest.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PHOSPHARASETEST]);
                    //EnabledChangedDd(cPhosphateTest);
                    //txtAlcohol.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ALCOHOL]);
                    //EnabledChanged(txtAlcohol);
                    //Adultration.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ADULTRATION]);
                    //EnabledChangedDd(Adultration);
                    //txtAreobicPlateCountML.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICPLATE]);
                    //EnabledChanged(txtAreobicPlateCountML);
                    //txtColiformML.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_COLIFORM]);
                    //EnabledChanged(txtColiformML);
                    //txtYeastMoulds.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_YESTANDMOULDS]);
                    //EnabledChanged(txtYeastMoulds);
                    //txtSomaticCellCount.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SOMATICCELL]);
                    //EnabledChanged(txtSomaticCellCount);
                    //txtTotalSolids.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALSOLIDS]);
                    //EnabledChanged(txtTotalSolids);
                    //txtApperance.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_APPERARANCE]);
                    //EnabledChanged(txtApperance);
                    //txtFatbyMass.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FATBYMASS]);
                    //EnabledChanged(txtFatbyMass);
                    //txtMoistureBymass.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MOISTUREBYMASS]);
                    //EnabledChanged(txtMoistureBymass);
                    //txtCurbBymass.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_CURNBYMASS]);
                    //EnabledChanged(txtCurbBymass);
                    //txtAciditybyMass.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITYBYMASS]);
                    //EnabledChanged(txtAciditybyMass);
                    //txtAerobicPlateCountg.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICPLATEBYG]);
                    //EnabledChanged(txtAerobicPlateCountg);
                    //txtColiformCountg.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_COLIFORM]);
                    //EnabledChanged(txtColiformCountg);
                    //txtYeastMouldsG.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_YEASTMOULDSPERG]);
                    //EnabledChanged(txtYeastMouldsG);
                    //cEcoli.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ECOLIG]);
                    //EnabledChangedDd(cEcoli);
                    //txtQuality.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_QUANTITY]);
                    //EnabledChanged(txtQuality);
                    //txtBodyTexture.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BODYANDTEXTURE]);
                    //EnabledChanged(txtBodyTexture);
                    //txtFlavour.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FLAVOUR]);
                    //EnabledChanged(txtFlavour);
                    //txtMoisture.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_MOISTURE]);
                    //EnabledChanged(txtMoisture);
                    //txtFFAOA.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FFAOA]);
                    //EnabledChanged(txtFFAOA);
                    //txtBRReading.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BRREADING]);
                    //EnabledChanged(txtBRReading);
                    //txtRMvalue.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_RMVALUE]);
                    //EnabledChanged(txtRMvalue);
                    //txtPValue.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PVALUE]);
                    //EnabledChanged(txtPValue);
                    //cBaudiniTest.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BAUDOUINTEST]);
                    //EnabledChangedDd(cBaudiniTest);
                    //txtFatonDryMaterBasics.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FATONDRYMATTERBASSIS]);
                    //EnabledChanged(txtFatonDryMaterBasics);
                    //txtFatbyWeight.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_FATBYWEIGHT]);
                    //EnabledChanged(txtFatbyWeight);
                    //txtSucroseByWeight.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SUCROSEBYWEIGHT]);
                    //EnabledChanged(txtSucroseByWeight);
                    //txtInsolubilityIndexProtein.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_INSOLUBILITYINDEXPROTEIN]);
                    //EnabledChanged(txtInsolubilityIndexProtein);
                    //txtTotalAshDryBasis.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_TOTALASHDRYBASISBYMASS]);
                    //EnabledChanged(txtTotalAshDryBasis);
                    //txtAcidityNaOH.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_ACIDITYOGNAOH]);
                    //EnabledChanged(txtAcidityNaOH);
                    //txtBulkDensity.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_BULKDENSITY]);
                    //EnabledChanged(txtBulkDensity);
                    //Adultration.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PRESERVATIVE]);
                    //EnabledChangedDd(Adultration);
                    //txtpH.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_PH]);
                    //EnabledChanged(txtpH);
                    //txtCreamingIndex.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_CREAMINGINDEX]);
                    //EnabledChanged(txtCreamingIndex);
                    //txtAerobicSporeCountML.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_AEROBICSPOREML]);
                    //EnabledChanged(txtAerobicSporeCountML);
                    //txtScoechedParticles.Enabled = Convert.ToBoolean(objResult.ResultDt.Rows[0][MainLabProductBO.MAINLABPRODUCTS_SCORCHEDPARTICLE]);
                    //EnabledChanged(txtScoechedParticles);
                }
                int n = objResult.ResultDt.Columns.Count;
                TextBox[] textBox = new TextBox[n];
                Label[] label = new Label[n];

                for(int i = 0; i < n; i++)
                {

                    var n1 = i;
                    textBox[i] = new TextBox();
                    textBox[i].Name = objResult.ResultDt.Columns[i].ToString();

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

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
    }
}
