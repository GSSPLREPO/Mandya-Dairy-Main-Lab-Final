using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandya.BO
{
    public class ProductBO
    {

        #region Product Class Properties

        public const string PRODUCT_TABLE = "tbl_Product";
        public const string PRODUCT_PRODUCTID = "ProductId";
        public const string PRODUCT_PRODUCTNAME = "ProductName";
        public const string PRODUCT_PRODUCTCODE = "ProductCode";
        public const string PRODUCT_CREATEDBY = "CreatedBy";
        public const string PRODUCT_CREATEDDATE = "CreatedDate";
        public const string PRODUCT_LASTMODIFIEDBY = "LastModifiedBy";
        public const string PRODUCT_LASTMODIFIEDDATE = "LastModifiedDate";
        public const string PRODUCT_ISDELETED = "IsDeleted";



        private int intProductId = 0;
        private string strProductName = string.Empty;
        private int intProductCode = 0;
        private int intCreatedBy = 0;
        private string strCreatedDate = string.Empty;
        private int intLastModifiedBy =0;
        private string strLastModifiedDate = string.Empty;
        private int intIsDeleted = 0;

        #endregion

        #region ---Properties---
        public int ProductId
        {
            get { return intProductId; }
            set { intProductId = value; }
        }
        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }
        }
        public int ProductCode
        {
            get { return intProductCode; }
            set { intProductCode = value; }
        }
        public int CreatedBy
        {
            get { return intCreatedBy; }
            set { intCreatedBy = value; }
        }
        public string CreatedDate
        {
            get { return strCreatedDate; }
            set { strCreatedDate = value; }
        }
        public int LastModifiedBy
        {
            get { return intLastModifiedBy; }
            set { intLastModifiedBy = value; }
        }
        public string LastModifiedDate
        {
            get { return strLastModifiedDate; }
            set { strLastModifiedDate = value; }
        }
        public int IsDeleted
        {
            get { return intIsDeleted; }
            set { intIsDeleted = value; }
        }

        #endregion
        
    }
}
