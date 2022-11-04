using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Mandya.Common;
using Mandya.BL;
using Mandya.BO;
using WeightBridgeMandya.clientui;
using MetroFramework;

namespace WeightBridgeMandya
{
    public partial class Login : MetroForm
    {
        private static readonly log4net.ILog log =
        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Initialize Component
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                txtUserName.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Oops! There is some technical issue. Please Contact to your administrator." + ex);
                log.Error("error", ex);
            }
        }
        #endregion

        #region Login Button Click Event
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int intValidate = 0;
                if (txtUserName.Text.Trim() == "")
                {
                    MetroMessageBox.Show(this, "Enter User Name", "Mandya WeighBridge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }
                else if (txtPassword.Text.Trim() == "")
                {
                    MetroMessageBox.Show(this, "Enter password", "Mandya WeighBridge", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    intValidate = 1;
                }
                if (intValidate == 0)
                {

                    EmployeeBl objEmployeeBl = new EmployeeBl();
                    ApplicationResult objResult = new ApplicationResult();

                    objResult = objEmployeeBl.Employee_Select_ForLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                    if (objResult != null)
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            Program.intUserId = Convert.ToInt32(objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_ID].ToString());
                            Program.strUserName = objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_USERNAME].ToString();
                            Program.intRoleId = Convert.ToInt32(objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_ROLEID].ToString());
                            Program.intOrganisationId = Convert.ToInt32(objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_ORGANISATIONID].ToString());
                            Program.intDepartmentId = Convert.ToInt32(objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_DEPARTMENTID].ToString());
                            if(Program.intRoleId==1 || Program.intRoleId == 3)
                            {
                                this.Hide();
                                Form1 frmMainForm = new Form1();
                                frmMainForm.ShowDialog();
                                
                            }
                            else
                            {
                                MetroMessageBox.Show(this, "You Are Not Authorized User", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            
                        }
                        else
                        {
                            MetroMessageBox.Show(this, "Invalid User Name or password", "Lab", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         
                        }
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this,"Oops! There is some technical issue. Please Contact to your administrator.");
                log.Error("error", ex);
            }
        }
        #endregion

        #region Cancle Button Click Event
        private void btnCancel_Click(object sender, EventArgs e)
        {

            Application.Exit();
          
        }
        #endregion

        #region Form Closing Event
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {

            Application.Exit();
           
        }
        #endregion
    }
}
