using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using WeightBridgeMandya.clientui;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace WeightBridgeMandya
{
    static class Program
    {
        public static int intUserId;
        public static string strUserName;
        public static int intRoleId;
        public static int intBranchId;
        public static int intDepartmentId;
        public static int intOrganisationId;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
            Application.Run(new Login());
        }
    }
}
