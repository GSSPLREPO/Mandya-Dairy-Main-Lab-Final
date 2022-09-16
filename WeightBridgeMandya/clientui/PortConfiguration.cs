using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mandya.Common;
using MetroFramework;
using MetroFramework.Forms;
using System.Configuration;

namespace WeightBridgeMandya.clientui
{
    public partial class PortConfiguration : MetroForm
    {
        [Obsolete]
        string[] strPortSetup = ConfigurationSettings.AppSettings["Port"].ToString().Split('~');
        private static readonly log4net.ILog log =log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Initialize Component
        public PortConfiguration()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event
        private void PortConfiguration_Load(object sender, EventArgs e)
        {
            try
            {
                string[] ports = System.IO.Ports.SerialPort.GetPortNames();

                if (ports.Length > 0)
                {
                    cmbPortName.Items.Add("--Select--");
                    for (int i = 0; i < ports.Length; i++)
                    {
                        cmbPortName.Items.Add(ports[i].ToString());
                    }
                    btnSave.Enabled = true;

                    cmbPortName.SelectedItem = strPortSetup[0];
                    cmbBaudRate.SelectedItem = strPortSetup[1];
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Mandya WeighBridge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Save Button Click Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPortName.Text == "--Select--")
                {
                    MetroMessageBox.Show(this, "Please Select Proper Com Port.", "Hem Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cmbBaudRate.Text == "--Select--")
                {
                    MetroMessageBox.Show(this, "Please Select Proper BaudRate.", "Hem Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;
                    bool flag;
                    string strlog = string.Empty;
                    if (settings["Port"] == null)
                    {
                        settings.Add("Port", cmbPortName.Text + "~" + cmbBaudRate.Text);
                    }
                    else
                    {
                        settings["Port"].Value = cmbPortName.Text + "~" + cmbBaudRate.Text;
                    }
                    //configFile.AppSettings.Settings["Port"].Value = "hi";
                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

                    MetroMessageBox.Show(this, "Port Saved Successfully.", "Hem Wizard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                MetroMessageBox.Show(this, "Opps! There is some technical issue. Please Contact to your administrator.", "Mandya WeighBridge", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Cancle Button Click Event
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
