using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandya.BO
{
    public class VehicleBO
    {
        #region Vehicle Class Properties

        public const string VEHICLE_TABLE = "tbl_Vehicle";
        public const string VEHICLE_VEHICLEID = "VehicleId";
        public const string VEHICLE_ISACTIVE = "IsActive";
        public const string VEHICLE_VEHICLENUMBER = "VehicleNumber";
        public const string VEHICLE_VEHICLETYPE = "VehicleType";
        public const string VEHICLE_CAPACITY = "Capacity";
        public const string VEHICLE_DRIVERNAME = "DriverName";
        public const string VEHICLE_COMPARTMENTS = "Compartments";
        public const string VEHICLE_TAREWEIGHT = "TareWeight";
        public const string VEHICLE_REMARKS = "Remarks";
        public const string VEHICLE_CREATEDBY = "CreatedBy";
        public const string VEHICLE_CREATEDDATE = "CreatedDate";
        public const string VEHICLE_LASTMODIFIEDBY = "LastModifiedBy";
        public const string VEHICLE_LASTMODIFIEDDATE = "LastModifiedDate";
        public const string VEHICLE_ISDELETED = "IsDeleted";
        public const string VEHICLE_RouteID = "RouteID";



        private int intVehicleId = 0;
        private int intIsActive = 0;
        private string strVehicleNumber = string.Empty;
        private int intVehicleType = 0;
        private int intCapacity = 0;
        private string strDriverName = string.Empty;
        private int intCompartments = 0;
        private double dblTareWeight = 0;
        private string strRemarks = string.Empty;
        private int intCreatedBy = 0;
        private string strCreatedDate = string.Empty;
        private int strLastModifiedBy = 0;
        private string strLastModifiedDate = string.Empty;
        private int intIsDeleted = 0;
        private int intRouteID = 0;

        #endregion

        #region ---Properties---
        public int VehicleId
        {
            get { return intVehicleId; }
            set { intVehicleId = value; }
        }

        public int IsActive
        {
            get { return intIsActive; }
            set { intIsActive = value; }
        }
        public string VehicleNumber
        {
            get { return strVehicleNumber; }
            set { strVehicleNumber = value; }
        }
        public int VehicleType
        {
            get { return intVehicleType; }
            set { intVehicleType = value; }
        }
        public int Capacity
        {
            get { return intCapacity; }
            set { intCapacity = value; }
        }
        public string DriverName
        {
            get { return strDriverName; }
            set { strDriverName = value; }
        }
        public int Compartments
        {
            get { return intCompartments; }
            set { intCompartments = value; }
        }

        public double TareWeight
        {
            get{return dblTareWeight;}
            set { dblTareWeight = value; }
        }
        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
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
            get { return strLastModifiedBy; }
            set { strLastModifiedBy = value; }
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
        public int RouteID
        {
            get { return intRouteID; }
            set { intRouteID = value; }
        }
        #endregion

    }
}
