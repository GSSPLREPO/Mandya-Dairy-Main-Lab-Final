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
    public partial class MainLab : MetroForm
    {

        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
       // private string _rxString;
        private string strMode = string.Empty;
        [Obsolete]
        string[] strPortSetup = ConfigurationSettings.AppSettings["Port"].ToString().Split('~');

        #region Declaration
        public string strTankNo = "";
        public int intid;
        public int intactivate = 0;
        public int MilkReceptionID;
        private DataTable dtOT = new DataTable();
        private DataTable dtTemp = new DataTable();
        private DataTable dtNeutrilizer = new DataTable();
        private DataTable dtUrea = new DataTable();
        private DataTable dtSalt = new DataTable();
        private DataTable dtStarch = new DataTable();
        private DataTable dtFpd = new DataTable();
        private DataTable dtCOB = new DataTable();
        private DataTable dtAlcohol = new DataTable();
        private DataTable dtStatus = new DataTable();
        #endregion

        #region Initialize Component
        public MainLab(int id)
        {
            InitializeComponent();
            spWeighBridge.PortName = strPortSetup[0];
            spWeighBridge.BaudRate = Convert.ToInt32(strPortSetup[1]);
            spWeighBridge.DataBits = 8;
            spWeighBridge.StopBits = StopBits.One;
            spWeighBridge.Parity = Parity.None;
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
                dtTime.ShowUpDown = true;
                bindTankNo();
                defineDataTable();
                bindRow();
                bindCombobox();
                bindProduct();
                rdoManual.Checked = true;
                rdoManual_CheckedChanged(sender, e);
                rdoAuto.Enabled = false;
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
                            cmbTankNo.Enabled = false;
                            dtDate.Text = objResult.ResultDt.Rows[0]["Date"].ToString();
                            dtTime.Text = objResult.ResultDt.Rows[0]["Time"].ToString();
                            //cmbTankNo.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_TANKNO].ToString();
                            txtBatchNo.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_BATCHNO].ToString();
                            cmbProduct.SelectedValue = Convert.ToInt32(objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_PRODUCTID]);
                           // cmbOT.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_OT].ToString();
                            cmbTemp.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_TEMP].ToString();
                            txtFat.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_FAT].ToString();
                            txtSnf.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_SNF].ToString();
                            txtAcidity.Text = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_ACIDITY].ToString();
                            //cmbCob.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_COB].ToString();
                            cmbAlcohol.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_ALCOHOL].ToString();
                            ////cmbNeutrilizer.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_NEUTRILIZER].ToString();
                            //cmbUrea.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_UREA].ToString();
                            //cmbSalt.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_SALT].ToString();
                            //cmbStarch.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_STARCH].ToString();
                            //cmbFPD.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_FPD].ToString();
                            //cmbStatus.SelectedValue = objResult.ResultDt.Rows[0][MainLabAnalysisBO.MAINLABANALYSIS_STATUS].ToString();
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

        #region Define DataTable
        private void defineDataTable()
        {
            dtOT.Columns.Add("Id", typeof(int));
            dtOT.Columns.Add("OT", typeof(string));

            dtTemp.Columns.Add("Id", typeof(int));
            dtTemp.Columns.Add("Temp", typeof(string));

            dtCOB.Columns.Add("Id", typeof(int));
            dtCOB.Columns.Add("COB", typeof(string));

            dtAlcohol.Columns.Add("Id", typeof(int));
            dtAlcohol.Columns.Add("Alcohol", typeof(string));

            dtNeutrilizer.Columns.Add("Id", typeof(int));
            dtNeutrilizer.Columns.Add("Neutrilizer", typeof(string));

            dtUrea.Columns.Add("Id", typeof(int));
            dtUrea.Columns.Add("Urea", typeof(string));

            dtSalt.Columns.Add("Id", typeof(int));
            dtSalt.Columns.Add("Salt", typeof(string));

            dtStarch.Columns.Add("Id", typeof(int));
            dtStarch.Columns.Add("Starch", typeof(string));

            dtFpd.Columns.Add("Id", typeof(int));
            dtFpd.Columns.Add("Fpd", typeof(string));

            dtStatus.Columns.Add("Id", typeof(int));
            dtStatus.Columns.Add("Status", typeof(string));

        }
        #endregion

        #region Define Table Row
        public void bindRow()
        {
            dtOT.Rows.Add(0, "Ok");
            dtOT.Rows.Add(1, "Not Ok");

            dtTemp.Rows.Add(0, "Ok");
            dtTemp.Rows.Add(1, "Not Ok");

            dtCOB.Rows.Add(0, "-VE");
            dtCOB.Rows.Add(1, "+VE");

            dtAlcohol.Rows.Add(0, "-VE");
            dtAlcohol.Rows.Add(1, "+VE");

            dtNeutrilizer.Rows.Add(0, "-VE");   
            dtNeutrilizer.Rows.Add(1, "+VE");

            dtUrea.Rows.Add(0, "-VE");
            dtUrea.Rows.Add(1, "+VE");

            dtSalt.Rows.Add(0, "-VE");
            dtSalt.Rows.Add(1, "+VE");

            dtStarch.Rows.Add(0, "-VE");
            dtStarch.Rows.Add(1, "+VE");

            dtFpd.Rows.Add(0, "-VE");
            dtFpd.Rows.Add(1, "+VE");

            dtStatus.Rows.Add(0, "Accepted");
            dtStatus.Rows.Add(1, "Not Accepted");

        }

        #endregion

        #region Bind Combobox
        public void bindCombobox()
        {
            cmbOT.DataSource = dtOT;
            cmbOT.ValueMember = dtOT.Columns["Id"].ToString();
            cmbOT.DisplayMember = dtOT.Columns["OT"].ToString();

            cmbTemp.DataSource = dtTemp;
            cmbTemp.ValueMember = dtTemp.Columns["Id"].ToString();
            cmbTemp.DisplayMember = dtTemp.Columns["Temp"].ToString();

            cmbCob.DataSource = dtCOB;
            cmbCob.ValueMember = dtCOB.Columns["Id"].ToString();
            cmbCob.DisplayMember = dtCOB.Columns["COB"].ToString();

            cmbAlcohol.DataSource = dtAlcohol;
            cmbAlcohol.ValueMember = dtAlcohol.Columns["Id"].ToString();
            cmbAlcohol.DisplayMember = dtAlcohol.Columns["Alcohol"].ToString();

            cmbNeutrilizer.DataSource = dtNeutrilizer;
            cmbNeutrilizer.ValueMember = dtNeutrilizer.Columns["Id"].ToString();
            cmbNeutrilizer.DisplayMember = dtNeutrilizer.Columns["Neutrilizer"].ToString();

            cmbUrea.DataSource = dtUrea;
            cmbUrea.ValueMember = dtUrea.Columns["Id"].ToString();
            cmbUrea.DisplayMember = dtUrea.Columns["Urea"].ToString();

            cmbSalt.DataSource = dtSalt;
            cmbSalt.ValueMember = dtSalt.Columns["Id"].ToString();
            cmbSalt.DisplayMember = dtSalt.Columns["Salt"].ToString();

            cmbStarch.DataSource = dtStarch;
            cmbStarch.ValueMember = dtStarch.Columns["Id"].ToString();
            cmbStarch.DisplayMember = dtStarch.Columns["Starch"].ToString();

            cmbFPD.DataSource = dtFpd;
            cmbFPD.ValueMember = dtFpd.Columns["Id"].ToString();
            cmbFPD.DisplayMember = dtFpd.Columns["Fpd"].ToString();

            cmbStatus.DataSource = dtStatus;
            cmbStatus.ValueMember = dtStatus.Columns["Id"].ToString();
            cmbStatus.DisplayMember = dtStatus.Columns["Status"].ToString();


        }
        #endregion

        #region Save Button Click Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int intValidate = 0;
                if (cmbTankNo.Text == "")
                {
                    MetroMessageBox.Show(this, "Select Tank No", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }

                else if (cmbProduct.Text == "")
                {
                    MetroMessageBox.Show(this, "Select Product Name", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }

                else if (txtFat.Text.Trim() == "" || txtFat.Text=="0" || txtFat.Text=="0.00")
                {
                    MetroMessageBox.Show(this, "Enter Fat (%)", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }

                else if (txtSnf.Text.Trim() == "" || txtSnf.Text == "0" || txtSnf.Text == "0.00")
                {
                    MetroMessageBox.Show(this, "Enter SNF (%)", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }

                else if (txtAcidity.Text.Trim() == "" || txtAcidity.Text == "0" || txtAcidity.Text == "0.00")
                {
                    MetroMessageBox.Show(this, "Enter Acidity", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }

                else if (txtBatchNo.Text == "" && (cmbTankNo.Text =="Ghee" || cmbTankNo.Text == "Paneer" || cmbTankNo.Text == "Butter"))
                {
                    MetroMessageBox.Show(this, "Enter Batch No", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }

                if (intValidate == 0)
                {
                    MainLabAnalysisBO objMainLabAnalysisBO = new MainLabAnalysisBO();
                    MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                    ApplicationResult objResult = new ApplicationResult();

                    objMainLabAnalysisBO.DateTime = Convert.ToDateTime(dtDate.Text + " " + dtTime.Text);
                   // objMainLabAnalysisBO.TankNo = Convert.ToInt32(cmbTankNo.SelectedValue);
                    objMainLabAnalysisBO.BatchNo = txtBatchNo.Text.Trim();
                    objMainLabAnalysisBO.ProductID = Convert.ToInt32(cmbProduct.SelectedValue);
                    //objMainLabAnalysisBO.OT = Convert.ToInt32(cmbOT.SelectedValue);
                    objMainLabAnalysisBO.Temp = Convert.ToInt32(cmbTemp.SelectedValue);
                    objMainLabAnalysisBO.FAT = float.Parse(txtFat.Text.Trim());
                    objMainLabAnalysisBO.SNF = float.Parse(txtSnf.Text.Trim());
                    objMainLabAnalysisBO.Acidity = float.Parse(txtAcidity.Text.Trim());
                    //objMainLabAnalysisBO.COB = Convert.ToInt32(cmbCob.SelectedValue);
                    objMainLabAnalysisBO.Alcohol = Convert.ToInt32(cmbAlcohol.SelectedValue);
                   // objMainLabAnalysisBO.Neutrilizer = Convert.ToInt32(cmbNeutrilizer.SelectedValue);
                    //objMainLabAnalysisBO.Urea = Convert.ToInt32(cmbUrea.SelectedValue);
                    //objMainLabAnalysisBO.Salt = Convert.ToInt32(cmbSalt.SelectedValue);
                    //objMainLabAnalysisBO.Starch = Convert.ToInt32(cmbStarch.SelectedValue);
                    //objMainLabAnalysisBO.Fpd = Convert.ToInt32(cmbFPD.SelectedValue);
                    //objMainLabAnalysisBO.Status = Convert.ToInt32(cmbStatus.SelectedValue);
                    objMainLabAnalysisBO.CreatedByID = Program.intUserId;
                    objMainLabAnalysisBO.CreatedByDate = DateTime.UtcNow.AddHours(5.5);

                    strTankNo = cmbTankNo.Text;
                    if (strMode == "New")
                    {
                        objResult = objMainLabAnalysisBL.MainLabAnalysis_Insert(objMainLabAnalysisBO);
                        if (objResult != null)
                        {
                            if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                            {
                                MetroMessageBox.Show(this, "Record Saved Successfully.", "Lab",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                WriteLMPPLC(strTankNo);
                                WriteFERMPLC(strTankNo);
                                this.Close();
                            }
                        }

                    }
                    else
                    {
                        objMainLabAnalysisBO.MainLabID = intid;
                        objMainLabAnalysisBO.LastModifiedByDate = DateTime.UtcNow.AddHours(5.5);
                        objMainLabAnalysisBO.LastModifiedByID = Program.intUserId;
                        objResult = objMainLabAnalysisBL.MainLabAnalysis_Update(objMainLabAnalysisBO);
                        if (objResult != null)
                        {
                            if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                            {
                                MetroMessageBox.Show(this, "Record Updated Successfully.", "Lab",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                WriteLMPPLC(strTankNo);
                                WriteFERMPLC(strTankNo);
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

        #region Bind TankNo ComboBox
        private void bindTankNo()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                objResult = objMainLabAnalysisBL.TankNo_Select_For_Combobox();


                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        cmbTankNo.DataSource = objResult.ResultDt;
                        cmbTankNo.ValueMember = objResult.ResultDt.Columns["Code"].ToString();
                        cmbTankNo.DisplayMember = objResult.ResultDt.Columns["TankName"].ToString();
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

        #region Bind Product Name ComboBox
        private void bindProduct()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
                objResult = objMainLabAnalysisBL.ProductMainLab_Select_For_Combobox();
                if (objResult != null)
                {
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        cmbProduct.DataSource = objResult.ResultDt;

                        cmbProduct.ValueMember = objResult.ResultDt.Columns["Code"].ToString();
                        cmbProduct.DisplayMember = objResult.ResultDt.Columns["Name"].ToString();


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

        //#region TankerNo Combobox SelectionChangeCommitted Event
        //private void cmbTankerNo_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ApplicationResult objResult = new ApplicationResult();
        //        MainLabAnalysisBL objMainLabAnalysisBL = new MainLabAnalysisBL();
        //        objResult = objMainLabAnalysisBL.TankerID_Select_For_Textbox(cmbTankNo.Text);
        //        if (objResult != null)
        //        {
        //            if (objResult.ResultDt.Rows.Count > 0)
        //            {
        //                txtBatchNo.Text = objResult.ResultDt.Rows[0]["TankerID"].ToString();
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("error", ex);
        //        MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //#endregion

        #region Close Button Click Event
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Clear Button Click Event
        private void btnClear_Click(object sender, EventArgs e)
        {
            dtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            dtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            cmbTankNo.SelectedIndex = 0;
            txtBatchNo.Text = "";
            cmbOT.SelectedIndex = 0;
            cmbProduct.SelectedIndex = 0;
            cmbTemp.SelectedIndex = 0;
            cmbAlcohol.SelectedIndex = 0;
            txtFat.Text = "0";
            txtSnf.Text = "0";
            txtAcidity.Text = "0";
            cmbStarch.SelectedIndex = 0;
            cmbNeutrilizer.SelectedIndex = 0;
            cmbFPD.SelectedIndex = 0;
            cmbSalt.SelectedIndex = 0;
            cmbCob.SelectedIndex = 0;
            cmbUrea.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;
        }
        #endregion

        #region Capture Button Click Event
        private void btnCapture_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (spWeighBridge.IsOpen)
                {
                    spWeighBridge.Close();
                }
                spWeighBridge.Open();
                btnCapture.Text = "Processing";
                btnCapture.Refresh();
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "COM-Port for Lab is not available. Check Connection with Lab", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            //readCSV();
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

        #region Check Textbox Input Validation of float Value
        public void checkValue(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8 || e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region All Textbox Key Press Event
        private void txtFat_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkValue(sender, e);
        }

        private void txtSnf_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkValue(sender, e);
        }

        private void txtAcidity_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkValue(sender, e);
        }

        #endregion

        #region Serial port DataReceived event
        private void spWeighBridge_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           /* try
            {
                Thread.Sleep(500);
                _rxString = "";
                _rxString = spWeighBridge.ReadExisting();
                BeginInvoke(new EventHandler(getstring));
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "COM-Port for Lab is not available. Check Connection with Lab", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }
        #endregion

        #region getString from Com port method
        public void getstring(object sender, EventArgs e)
        {
          /*  string[] strFATSNF = _rxString.Substring(_rxString.IndexOf("H") + 2, 12).Split(',');
            // string[] strFATSNF = _rxString.Substring(_rxString.IndexOf("H") + 2, 7);
            txtFat.Text = strFATSNF[0];
            txtSnf.Text = strFATSNF[1];
            spWeighBridge.Close();
            btnCapture.Text = "Capture";
            btnCapture.Refresh();*/
        }
        #endregion

        #region BatchNo Textbox KeyPress Event
        private void txtBatchNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Write Data In LMP PLC Fat, Snf and Status
        private void WriteLMPPLC(string strTankNo)
        {
            try
            {
                // Declare Variable for PLC Connection
                Plc plc = null;
                string ip = "172.168.0.1";
                string cputype = "S7400";
                int Rack = 0;
                int Slot = 5;
                float fat = float.Parse(txtFat.Text);
                float snf = float.Parse(txtSnf.Text);
                string strStatus = cmbStatus.Text;
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

                    MessageBox.Show("PLC Connection Open Fails", MessageBoxIcon.Error.ToString());
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
            catch(PlcException ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Write Data In FERM PLC Fat, Snf and Status
        private void WriteFERMPLC(string strTankNo)
        {
            try
            {
                // Declare Variable for PLC Connection
                Plc plc = null;
                string ip = "172.168.0.3";
                string cputype = "S7400";
                int Rack = 0;
                int Slot = 5;
                float fat = float.Parse(txtFat.Text);
                float snf = float.Parse(txtSnf.Text);
                string strStatus = cmbStatus.Text;
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
                catch(PlcException)
                {
                  
                        MessageBox.Show("PLC Connection Open Fails", MessageBoxIcon.Error.ToString());
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
            catch(PlcException ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region Auto Radiobutton CheckedChanged Event
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
        #endregion

        #region Auto Radiobutton CheckedChanged Event
        private void rdoManual_CheckedChanged(object sender, EventArgs e)
        {
            //if (Program.intRoleId == 1)
            //{
            if (rdoManual.Checked == true)
            {
                txtFat.Enabled = true;
                txtSnf.Enabled = true;
                //btnCapture.Enabled = false;
            }
            else
            {
                txtFat.Enabled = false;
                txtSnf.Enabled = false;
                btnCapture.Enabled = true;
            }

            /* }
             else
             {
                 MetroMessageBox.Show(this, "Access Denied", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }
        #endregion

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
