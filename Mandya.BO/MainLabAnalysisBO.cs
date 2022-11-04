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

        public const string MAINLABANALYSIS_TABLE = "tbl_MainLabAnalysis_New";
        public const string MAINLABANALYSIS_MAINLABID = "MainLabID";
        public const string MAINLABANALYSIS_DATETIME = "DateTime";
        public const string MAINLABANALYSIS_TANKID = "TankID";
        public const string MAINLABANALYSIS_BATCHNO = "BatchNo";
        public const string MAINLABANALYSIS_PRODUCTID = "ProductID";
        public const string MAINLABANALYSIS_ISAUTO = "IsAuto";
        public const string MAINLABANALYSIS_TEMP = "Temp";
        public const string MAINLABANALYSIS_ACIDITY = "Acidity";
        public const string MAINLABANALYSIS_FAT = "Fat";
        public const string MAINLABANALYSIS_SNF = "Snf";
        public const string MAINLABANALYSIS_MBRT = "Mbrt";
        public const string MAINLABANALYSIS_PHOSPHARASETEST = "PhospharaseTest";
        public const string MAINLABANALYSIS_ALCOHOL = "Alcohol";
        public const string MAINLABANALYSIS_ADULTRATION = "Adultration";
        public const string MAINLABANALYSIS_AEROBICPLATE = "Aerobicplate";
        public const string MAINLABANALYSIS_COLIFORM = "Coliform";
        public const string MAINLABANALYSIS_SOMATICCELL = "SomaticCell";
        public const string MAINLABANALYSIS_CREMINGINDEX = "CremingIndex";
        public const string MAINLABANALYSIS_TOTALSOLID = "TotalSolid";
        public const string MAINLABANALYSIS_PH = "Ph";
        public const string MAINLABANALYSIS_APPEARANCE = "Appearance";
        public const string MAINLABANALYSIS_BODYANDTEXTURE = "BodyAndTexture";
        public const string MAINLABANALYSIS_FLAVOUR = "Flavour";
        public const string MAINLABANALYSIS_MOISTURE = "Moisture";
        public const string MAINLABANALYSIS_FFAOA = "FFAOA";
        public const string MAINLABANALYSIS_BRREADING = "BRReading";
        public const string MAINLABANALYSIS_RMVALUE = "RMValue";
        public const string MAINLABANALYSIS_PVALUE = "PValue";
        public const string MAINLABANALYSIS_BAUDUINTEST = "BauduinTest";
        public const string MAINLABANALYSIS_ECOLI = "EColi";
        public const string MAINLABANALYSIS_SUCROSEPERCENT = "SucrosePercent";
        public const string MAINLABANALYSIS_INSOLUBILITYINDEX = "InsolubilityIndex";
        public const string MAINLABANALYSIS_PROTEIN = "Protein";
        public const string MAINLABANALYSIS_TOTALASH = "TotalAsh";
        public const string MAINLABANALYSIS_SCORCHEDPARTICLE = "ScorchedParticle";
        public const string MAINLABANALYSIS_BULKDENSITY = "BulkDensity";
        public const string MAINLABANALYSIS_WETTABILITY = "Wettability";
        public const string MAINLABANALYSIS_STATUS = "Status";
        public const string MAINLABANALYSIS_REMARKS = "Remarks";
        public const string MAINLABANALYSIS_ISDELETED = "IsDeleted";
        public const string MAINLABANALYSIS_CREATEDBYID = "CreatedByID";
        public const string MAINLABANALYSIS_CREATEDBYDATE = "CreatedByDate";
        public const string MAINLABANALYSIS_LASTMODIFIEDBYID = "LastModifiedByID";
        public const string MAINLABANALYSIS_LASTMODIFIEDBYDATE = "LastModifiedByDate";

        private int intMainLabID = 0;
        private DateTime dtDateTime;
        private int intTankeID = 0;
        private string strBatchNo = string.Empty;
        private int intProductID = 0;
        private bool blIsAuto;
        private float flTemp = 0;
        private float flFat = 0;
        private float flSnf = 0;
        private float flAcidity = 0;
        private float flMbrt = 0;
        private int intPhospharaseTest = 0;
        private float flAlcohol = 0;
        private int intAdultration = 0;
        private float flAerobicPlate = 0;
        private float flColiform = 0;
        private float flSomaticCell = 0;
        private float flCremingIndex = 0;
        private float flTotalSolid = 0;
        private float flPh = 0;
        private int intAppearance = 0;
        private int intBodyAndTexture = 0;
        private int intFlavour = 0;
        private float flMoisture = 0;
        private float flFFAOA = 0;
        private float flBRReading = 0;
        private float flRMValue = 0;
        private float flPValue = 0;
        private int intBauduinTest = 0;
        private float flEColi = 0;
        private float flSucrosePercent = 0;
        private float flInsolubilityIndex = 0;
        private float flProtein = 0;
        private float flTotalAsh = 0;
        private float flScorchedParticle = 0;
        private float flBulkDensity = 0;
        private float flWettability = 0;
        private int intStatus = 0;
        private string strRemarks = string.Empty;
        private int intIsDeleted = 0;
        private int intCreatedByID = 0;
        private DateTime dtCreatedByDate;
        private int intLastModifiedByID = 0;
        private DateTime dtLastModifiedByDate;


        #endregion

        #region ---Properties---
        public int MainLabID
        {
            get { return intMainLabID; }
            set { intMainLabID = value; }
        }
        public DateTime DateTime
        {
            get { return dtDateTime; }
            set { dtDateTime = value; }
        }
        public int TankID
        {
            get { return intTankeID; }
            set { intTankeID = value; }
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

        public bool IsAuto
        {
            get { return blIsAuto ; }
            set { blIsAuto = value; }
        }

        public float Temp
        {
            get { return flTemp; }
            set { flTemp = value; }
        }

        public float Acidity
        {
            get { return flAcidity; }
            set { flAcidity = value; }
        }
        public float FAT
        {
            get { return flFat; }
            set { flFat = value; }
        }

        public float SNF
        {
            get { return flSnf; }
            set { flSnf = value; }
        }

        public float Mbrt
        {
            get { return flMbrt; }
            set { flMbrt = value; }
        }
        public int PhospharaseTest
        {
            get { return intPhospharaseTest; }
            set { intPhospharaseTest = value; }
        }

        public float Alcohol
        {
            get { return flAlcohol; }
            set { flAlcohol = value; }
        }

        public int Adultration
        {
            get { return intAdultration; }
            set { intAdultration = value; }
        }

        public float AerobicPlate
        {
            get { return flAerobicPlate; }
            set { flAerobicPlate = value; }
        }

        public float Coliform
        {
            get { return flColiform; }
            set { flColiform = value; }
        }

        public float SomaticCell
        {
            get { return flSomaticCell; }
            set { flSomaticCell = value; }
        }
        public float CremingIndex
        {
            get { return flCremingIndex; }
            set { flCremingIndex = value; }
        }
        public float TotalSolid
        {
            get { return flTotalSolid; }
            set { flTotalSolid = value; }
        }

        public float Ph
        {
            get { return flPh; }
            set { flPh = value; }
        }

        public int Appearance
        {
            get { return intAppearance; }
            set { intAppearance = value; }
        }

        public int BodyAndTexture
        {
            get { return intBodyAndTexture; }
            set { intBodyAndTexture = value; }
        }

        public int Flavour
        {
            get { return intFlavour; }
            set { intFlavour = value; }
        }

        public float Moisture
        {
            get { return flMoisture; }
            set { flMoisture = value; }
        }

        public float FFAOA
        {
            get { return flFFAOA;}
            set { flFFAOA = value; }
        }

        public float BRReading
        {
            get {return flBRReading; }
            set { flBRReading = value; }
        }

        public float RMValue
        {
            get { return flRMValue; }
            set { flRMValue = value; }
        }

        public float PValue
        {
            get { return flPValue; }
            set { flPValue = value; }
        }

        public int BauduinTest
        {
            get { return intBauduinTest; }
            set { intBauduinTest = value; }
        }

        public float EColi
        {
            get { return flEColi; }
            set { flEColi = value; }
        }

        public float SucrosePercent
        {
            get { return flSucrosePercent; }
            set { flSucrosePercent=value; }
        }

        public float InsolubilityIndex
        {
            get { return flInsolubilityIndex; }
            set { flInsolubilityIndex = value; }
        }

        public float Protein
        {
            get { return flProtein; }
            set { flProtein = value; }
        }

        public float TotalAsh
        {
            get { return flTotalAsh;}
            set { flTotalAsh = value; }
        }

        public float ScorchedParticle
        {
            get { return flScorchedParticle; }
            set { flScorchedParticle = value; }
        }

        public float BulkDensity
        {
            get { return flBulkDensity; }
            set { flBulkDensity = value; }
        }

        public float Wettability
        {
            get { return flWettability; }
            set { flWettability = value; }
        }

        public int Status
        {
            get { return intStatus; }
            set { intStatus = value; }
        }

        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
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
