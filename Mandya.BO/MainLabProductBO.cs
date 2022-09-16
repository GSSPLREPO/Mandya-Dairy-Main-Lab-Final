using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandya.BO
{
    public class MainLabProductBO
    {

        #region MainLabProduct

        public const string MAINLABPRODUCT_TABLE = "tbl_MainLabProduct";
        public const string MAINLABPRODUCTS_ID = "Id";
        public const string MAINLABPRODUCTS_DATETIME = "DateTime";
        public const string MAINLABPRODUCTS_PRODUCTNAME = "ProductName";
        public const string MAINLABPRODUCTS_TEMP = "Temp";
        public const string MAINLABPRODUCTS_ACIDITY = "Acidity";
        public const string MAINLABPRODUCTS_FAT = "Fat";
        public const string MAINLABPRODUCTS_SNF = "Snf";
        public const string MAINLABPRODUCTS_MBRT = "Mbrt";
        public const string MAINLABPRODUCTS_PHOSPHARASETEST = "PhospharaseTest";
        public const string MAINLABPRODUCTS_ALCOHOL = "Alcohol";
        public const string MAINLABPRODUCTS_ADULTRATION = "Adultration";
        public const string MAINLABPRODUCTS_AEROBICPLATE = "AerobiPlate";
        public const string MAINLABPRODUCTS_COLIFORM = "Coliform";
        public const string MAINLABPRODUCTS_YESTANDMOULDS = "YeastAndMoulds";
        public const string MAINLABPRODUCTS_SOMATICCELL = "SomaticCell";
        public const string MAINLABPRODUCTS_CREMINGINDEX = "CremingIndex";
        public const string MAINLABPRODUCTS_TOTALSOLID = "TotalSolid";
        public const string MAINLABPRODUCTS_PH = "Ph";
        public const string MAINLABPRODUCTS_APPEARANCE = "Appearance";
        public const string MAINLABPRODUCTS_BODYANDTEXTURE = "BodyAndTexture";
        public const string MAINLABPRODUCTS_FLAVOUR = "Flavour";
        public const string MAINLABPRODUCTS_MOISTURE = "Moisture";
        public const string MAINLABPRODUCTS_FFAOA = "FFAOA";
        public const string MAINLABPRODUCTS_BRREADING = "BRReading";
        public const string MAINLABPRODUCTS_RMVALUE = "RMValue";
        public const string MAINLABPRODUCTS_PVALUE = "PValue";
        public const string MAINLABPRODUCTS_BAUDUINTEST = "BauduinTest";
        public const string MAINLABPRODUCTS_ECOLI = "EColi";
        public const string MAINLABPRODUCTS_SUCROSEPERCENT = "SucrosePercent";
        public const string MAINLABPRODUCTS_INSOLUBILITYINDEX = "InsolubilityIndex";
        public const string MAINLABPRODUCTS_PROTEIN = "Protein";
        public const string MAINLABPRODUCTS_TOTALASH = "TotalAsh";
        public const string MAINLABPRODUCTS_SCORCHEDPARTICLE = "ScorchedParticle";
        public const string MAINLABPRODUCTS_BULKDENSITY = "BulkDensity";
        public const string MAINLABPRODUCTS_WETTABILITY = "Wettability";
        public const string MAINLABPRODUCTS_ISDELETED = "IsDeleted";
        public const string MAINLABPRODUCTS_CREATEDBYID = "CreatedByID";
        public const string MAINLABPRODUCTS_CREATEDBYDATE = "CreatedByDate";
        public const string MAINLABPRODUCTS_LASTMODIFIEDBYID = "LastModifiedByID";
        public const string MAINLABPRODUCTS_LASTMODIFIEDBYDATE = "LastModifiedByDate";


        private int intID = 0;
        private DateTime dtDateTime;
        private string strProductName = string.Empty;
        private bool blTemp = false;
        private bool blAcidity = false;
        private bool blFat = false;
        private bool blSnf = false;
        private bool blMbrt = false;
        private bool blPhospharaseTest = false;
        private bool blAlcohol = false;
        private bool blAdultration = false;
        private bool blAerobicPlate = false;
        private bool blColiform = false;
        private bool blYeastAndMoulds = false;
        private bool blSomaticCell = false;
        private bool blCremingIndex = false;
        private bool blTotalSolid = false;
        private bool blPh = false;
        private bool blAppearance = false;
        private bool blBodyAndTexture = false;
        private bool blFlavour = false;
        private bool blMoisture = false;
        private bool blFFAOA = false;
        private bool blBRReading = false;
        private bool blRMValue = false;
        private bool blPValue = false;
        private bool blBauduinTest = false;
        private bool blEColi = false;
        private bool blSucrosePercent = false;
        private bool blInsolubilityIndex = false;
        private bool blProtein = false;
        private bool blTotalAsh = false;
        private bool blScorchedParticle = false;
        private bool blBulkDensity = false;
        private bool blWettability = false;
        private int intIsDeleted = 0;
        private int intCreatedByID = 0;
        private DateTime dtCreatedByDate=DateTime.Now;
        private int intLastModifiedByIID = 0;
        private DateTime dtLastModifiedByDate=DateTime.Now;

        #endregion

        #region Proprties
        public int ID
        {
            get { return intID; }
            set { intID = value; }
        }

        public DateTime DateTime
        {
            get { return dtDateTime; }
            set { dtDateTime = value; }
        }

        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }   
        }

        public bool Temp
        {
            get { return blTemp; }
            set { blTemp = value; }
        }

        public bool Acidity
        {
            get { return blAcidity; }
            set { blAcidity = value; }
        }

        public bool Fat
        {
            get { return blFat; }
            set { blFat = value; }
        }

        public bool Snf
        {
            get { return blSnf; }
            set { blSnf = value; }
        }

        public bool Mbrt
        {
            get { return blMbrt; }
            set { blMbrt = value; }
        }

        public bool PhospharaseTest
        {
            get { return blPhospharaseTest; }
            set { blPhospharaseTest = value; }
        }

        public bool Alcohol
        {
            get { return blAlcohol; }
            set { blAlcohol = value; }
        }

        public bool Adultration
        {
            get { return blAdultration; }
            set { blAdultration = value; }
        }

        public bool AerobicPlate
        {
            get { return blAerobicPlate; }
            set { blAerobicPlate = value; }
        }

        public bool Coliform
        {
            get { return blColiform; }
            set { blColiform = value; }
        }

        public bool YeastAndMoulds
        {
            get { return blYeastAndMoulds; }
            set { blYeastAndMoulds = value; }
        }

        public bool SomaticCell
        {
            get { return blSomaticCell; }
            set { blSomaticCell = value; }
        }

        public bool CremingIndex
        {
            get { return blCremingIndex; }
            set { blCremingIndex = value; }
        }

        public bool TotalSolid
        {
            get { return blTotalSolid; }
            set { blTotalSolid = value; }
        }

        public bool Ph
        {
            get { return blPh; }
            set { blPh = value; }
        }

        public bool Appearance
        {
            get { return blAppearance; }
            set { blAppearance = value; }
        }

        public bool BodyAndTexture
        {
            get { return blBodyAndTexture; }
            set { blBodyAndTexture = value; }
        }

        public bool Flavuor
        {
            get { return blFlavour; }
            set { blFlavour = value; }
        }

        public bool Moisture
        {
            get { return blMoisture; }
            set { blMoisture = value; }
        }

        public bool FFAOA
        {
            get { return blFFAOA; }
            set { blFFAOA = value; }
        }

        public bool BRReading
        {
            get { return blBRReading; }
            set { blBRReading = value; }
        }

        public bool RMValue
        {
            get { return blRMValue; }
            set { blRMValue = value; }
        }

        public bool PValue
        {
            get { return blPValue; }
            set { blPValue = value; }
        }

        public bool BauduinTest
        {
            get { return blBauduinTest; }
            set { blBauduinTest = value; }
        }

        public bool EColi
        {
            get { return blEColi; }
            set { blEColi = value; }
        }

        public bool SucrosePercent
        {
            get { return blSucrosePercent; }
            set { blSucrosePercent = value; }
        }

        public bool InsolubilityIndex
        {
            get { return blInsolubilityIndex; }
            set { blInsolubilityIndex = value; }
        }

        public bool Protein
        {
            get { return blProtein; }
            set { blProtein = value; }
        }

        public bool TotalAsh
        {
            get { return blTotalAsh; }
            set { blTotalAsh = value; }
        }

        public bool ScorchedParticle
        {
            get { return blScorchedParticle; }
            set { blScorchedParticle = value; }
        }

        public bool BulkDensity
        {
            get { return blBulkDensity; }
            set { blBulkDensity = value; }
        }

        public bool Wettability
        {
            get { return blWettability; }
            set { blWettability = value; }
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
            get { return intLastModifiedByIID; }
            set { intLastModifiedByIID = value; }
        }

        public DateTime LastModifiedByDate
        {
            get { return dtLastModifiedByDate; }
            set { dtLastModifiedByDate = value; }
        }


        #endregion

    }
}
