using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandya.BO
{
    public class MainLabAnalysisBO
    {
        #region MainLabAnalysis Class Properties

        public const string MAINLABANALYSIS_TABLE = "tbl_MainLabAnalysis";
        public const string MAINLABANALYSIS_MAINLABANALYSISID = "MainLabAnalysisID";
        public const string MAINLABANALYSIS_DATETIME = "DateTime";
        public const string MAINLABANALYSIS_TANKNO = "TankNo";
        public const string MAINLABANALYSIS_BATCHNO = "BatchNo";
        public const string MAINLABANALYSIS_PRODUCTID = "ProductID";
        public const string MAINLABANALYSIS_OT = "OT";
        public const string MAINLABANALYSIS_TEMP = "Temp";
        public const string MAINLABANALYSIS_FAT = "Fat";
        public const string MAINLABANALYSIS_SNF = "Snf";
        public const string MAINLABANALYSIS_ACIDITY = "Acidity";
        public const string MAINLABANALYSIS_COB = "Cob";
        public const string MAINLABANALYSIS_ALCOHOL = "Alcohol";
        public const string MAINLABANALYSIS_NEUTRILIZER = "Neutrilizer";
        public const string MAINLABANALYSIS_UREA = "Urea";
        public const string MAINLABANALYSIS_SALT = "Salt";
        public const string MAINLABANALYSIS_STARCH = "Starch";
        public const string MAINLABANALYSIS_FPD = "Fpd";
        public const string MAINLABANALYSIS_STATUS = "Status";
        public const string MAINLABANALYSIS_ISDELETED = "IsDeleted";
        public const string MAINLABANALYSIS_CREATEDBYID = "CreatedByID";
        public const string MAINLABANALYSIS_CREATEDBYDATE = "CreatedByDate";
        public const string MAINLABANALYSIS_LASTMODIFIEDBYID = "LastModifiedByID";
        public const string MAINLABANALYSIS_LASTMODIFIEDBYDATE = "LastModifiedByDate";


        private int intMainLabAnalysisID = 0;
        private DateTime dtDateTime;
        private int intTankNo = 0;
        private string strBatchNo = string.Empty;
        private int intProductID = 0;
        private int intOT = 0;
        private int intTemp = 0;
        private float ftFAT = 0;
        private float ftSNF = 0;
        private float ftAcidity = 0;
        private int intCOB = 0;
        private int intAlcohol = 0;
        private int intNeutrilizer = 0;
        private int intUrea = 0;
        private int intSalt = 0;
        private int intStarch = 0;
        private int intFpd = 0;
        private int intStatus = 0;
        private int intIsDeleted = 0;
        private int intCreatedByID = 0;
        private DateTime dtCreatedByDate;
        private int intLastModifiedByID = 0;
        private DateTime dtLastModifiedByDate;

        #endregion

        #region ---Properties---
        public int MainLabAnalysisID
        {
            get { return intMainLabAnalysisID; }
            set { intMainLabAnalysisID = value; }
        }
        public DateTime DateTime
        {
            get { return dtDateTime; }
            set { dtDateTime = value; }
        }
        public int TankNo
        {
            get { return intTankNo; }
            set { intTankNo = value; }
        }

        public string BatchNo
        {
            get { return strBatchNo; }
            set { strBatchNo = value; }
        }
        public int ProductID
        {
            get { return intProductID; }
            set { intProductID = value; }
        }

        public int OT
        {
            get { return intOT; }
            set { intOT = value; }
        }

        public int Temp
        {
            get { return intTemp; }
            set { intTemp = value; }
        }
        public float FAT
        {
            get { return ftFAT; }
            set { ftFAT = value; }
        }

        public float SNF
        {
            get { return ftSNF; }
            set { ftSNF = value; }
        }

        public float Acidity
        {
            get { return ftAcidity; }
            set { ftAcidity = value; }
        }
        public int COB
        {
            get { return intCOB; }
            set { intCOB = value; }
        }
        public int Alcohol
        {
            get { return intAlcohol; }
            set { intAlcohol = value; }
        }

        public int Neutrilizer
        {
            get { return intNeutrilizer; }
            set { intNeutrilizer = value; }
        }

        public int Urea
        {
            get { return intUrea; }
            set { intUrea = value; }
        }

        public int Salt
        {
            get { return intSalt; }
            set { intSalt = value; }
        }

        public int Starch
        {
            get { return intStarch; }
            set { intStarch = value; }
        }

        public int Fpd
        {
            get { return intFpd; }
            set { intFpd = value; }
        }
        public int Status
        {
            get { return intStatus; }
            set { intStatus = value; }
        }
        public int IsDeleted
        {
            get { return intIsDeleted; }
            set { intIsDeleted = value; }
        }
        public int CreatedByID
        {
            get { return intCreatedByID; }
            set { intCreatedByID = value; }
        }
        public DateTime CreatedByDate
        {
            get { return dtCreatedByDate; }
            set { dtCreatedByDate = value; }
        }
        public int LastModifiedByID
        {
            get { return intLastModifiedByID; }
            set { intLastModifiedByID = value; }
        }
        public DateTime LastModifiedByDate
        {
            get { return dtLastModifiedByDate; }
            set { dtLastModifiedByDate = value; }
        }

        #endregion
    }
}
