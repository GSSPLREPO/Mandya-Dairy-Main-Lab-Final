using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandya.BO;
using Mandya.Common;
using Mandya.DataAccess;
using System.Data;
using System.Data.SqlClient;

namespace Mandya.BL
{
    public class MainLabAnalysisBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Insert MilkAnalysis Details
        /// <summary>
        /// To Insert details of Main Lab Analysis in tbl_MainLabAnalysis Table
        /// Created By : Chirag Solanki 04/04/2022
        /// Modified By : 
        /// </summary>
        public ApplicationResult MainLabAnalysis_Insert(MainLabAnalysisBO objMainLabAnalysisBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[19];

                pSqlParameter[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabAnalysisBO.DateTime;

                pSqlParameter[1] = new SqlParameter("@TankNo", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabAnalysisBO.TankNo;

                pSqlParameter[2] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabAnalysisBO.BatchNo;

                pSqlParameter[3] = new SqlParameter("@ProductID", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabAnalysisBO.ProductID;

                pSqlParameter[4] = new SqlParameter("@OT", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabAnalysisBO.OT;

                pSqlParameter[5] = new SqlParameter("@Temp", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMainLabAnalysisBO.Temp;

                pSqlParameter[6] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMainLabAnalysisBO.FAT;

                pSqlParameter[7] = new SqlParameter("@SNF", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMainLabAnalysisBO.SNF;

                pSqlParameter[8] = new SqlParameter("@Acidity", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMainLabAnalysisBO.Acidity;

                pSqlParameter[9] = new SqlParameter("@COB", SqlDbType.Int);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabAnalysisBO.COB;

                pSqlParameter[10] = new SqlParameter("@Alcohol", SqlDbType.Int);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabAnalysisBO.Alcohol;

                pSqlParameter[11] = new SqlParameter("@Neutrilizer", SqlDbType.Int);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabAnalysisBO.Neutrilizer;

                pSqlParameter[12] = new SqlParameter("@Urea", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabAnalysisBO.Urea;

                pSqlParameter[13] = new SqlParameter("@Salt", SqlDbType.Int);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabAnalysisBO.Salt;

                pSqlParameter[14] = new SqlParameter("@Starch", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabAnalysisBO.Starch;

                pSqlParameter[15] = new SqlParameter("@FPD", SqlDbType.Int);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabAnalysisBO.Fpd;

                pSqlParameter[16] = new SqlParameter("@Status", SqlDbType.Int);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabAnalysisBO.Status;

                pSqlParameter[17] = new SqlParameter("@CreatedByID", SqlDbType.Int);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabAnalysisBO.CreatedByID;

                pSqlParameter[18] = new SqlParameter("@CreatedByDate", SqlDbType.DateTime);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabAnalysisBO.CreatedByDate;

                sSql = "usp_tbl_MainLabAnalysis_Insert";

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMainLabAnalysisBO = null;
            }
        }
        #endregion

        #region Select All Main lab Analysis Details
        /// <summary>
        /// To Select All data from the Main lab Analysis table
        /// Created By : Chirag
        /// Modified By :
        /// </summary>
        public ApplicationResult MainLabAnalysis_SelectAll_For_Gridview()
        {
            try
            {
                sSql = "usp_tbl_MainLabAnalysis_SelectAll_For_Gridview";
                DataTable dtFault = new DataTable();
                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtFault);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicationResult MainLabAnalysis_SelectAll_For_Gridview(DateTime dtFromDate, DateTime dtToDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = dtFromDate;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = dtToDate;

                sSql = "usp_tbl_MainLabAnalysis_SelectAll_For_Gridview_DateTime";
                DataTable dtFault = new DataTable();
                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtFault);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select All TankNo for Bind ComboBox
        /// <summary>
        /// To Select All TankNo for Bind ComboBox
        /// Created By : Chirag 03/04/2022
        /// Modified By :  
        /// </summary>
        public ApplicationResult TankNo_Select_For_Combobox()
        {
            try
            {
                sSql = "usp_tbl_TankNo_Select_For_Combobox";
                DataTable dtFault = new DataTable();
                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtFault);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select All Product for Bind ComboBox
        /// <summary>
        /// To Select All Product for Bind ComboBox
        /// Created By : Chirag 04/04/2022
        /// Modified By :  
        /// </summary>
        public ApplicationResult ProductMainLab_Select_For_Combobox()
        {
            try
            {
                sSql = "usp_tbl_ProductMainLab_Select_For_Combobox";
                DataTable dtFault = new DataTable();
                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, sSql, null);

                ApplicationResult objResults = new ApplicationResult(dtFault);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select MainLabAnalysis Details by Id For Edit
        /// <summary>
        /// Select all details of MainLabAnalysis for selected Id from MainLabAnalysis table
        /// Created By : Chirag
        /// Modified By :
        /// </summary>
        public ApplicationResult MainLabAnalysis_Select_For_Edit(int intMainLabAnalysisID)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@MainLabAnalysisID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intMainLabAnalysisID;

                strStoredProcName = "usp_tbl_MainLabAnalysis_Select_For_Edit";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update MainLabAnalysis Details
        /// <summary>
        /// To Update details of MainLabAnalysis in tbl_MainLabAnalysis table
        /// Created By : Chirag
        /// Modified By :
        /// </summary>
        public ApplicationResult MainLabAnalysis_Update(MainLabAnalysisBO objMainLabAnalysisBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[20];

                pSqlParameter[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabAnalysisBO.DateTime;

                pSqlParameter[1] = new SqlParameter("@TankNo", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabAnalysisBO.TankNo;

                pSqlParameter[2] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabAnalysisBO.BatchNo;

                pSqlParameter[3] = new SqlParameter("@ProductID", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabAnalysisBO.ProductID;

                pSqlParameter[4] = new SqlParameter("@OT", SqlDbType.Int);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabAnalysisBO.OT;

                pSqlParameter[5] = new SqlParameter("@Temp", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMainLabAnalysisBO.Temp;

                pSqlParameter[6] = new SqlParameter("@FAT", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMainLabAnalysisBO.FAT;

                pSqlParameter[7] = new SqlParameter("@SNF", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMainLabAnalysisBO.SNF;

                pSqlParameter[8] = new SqlParameter("@Acidity", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMainLabAnalysisBO.Acidity;

                pSqlParameter[9] = new SqlParameter("@COB", SqlDbType.Int);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabAnalysisBO.COB;

                pSqlParameter[10] = new SqlParameter("@Alcohol", SqlDbType.Int);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabAnalysisBO.Alcohol;

                pSqlParameter[11] = new SqlParameter("@Neutrilizer", SqlDbType.Int);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabAnalysisBO.Neutrilizer;

                pSqlParameter[12] = new SqlParameter("@Urea", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabAnalysisBO.Urea;

                pSqlParameter[13] = new SqlParameter("@Salt", SqlDbType.Int);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabAnalysisBO.Salt;

                pSqlParameter[14] = new SqlParameter("@Starch", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabAnalysisBO.Starch;

                pSqlParameter[15] = new SqlParameter("@FPD", SqlDbType.Int);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabAnalysisBO.Fpd;

                pSqlParameter[16] = new SqlParameter("@Status", SqlDbType.Int);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabAnalysisBO.Status;

                pSqlParameter[17] = new SqlParameter("@LastModifiedByID", SqlDbType.Int);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabAnalysisBO.LastModifiedByID;

                pSqlParameter[18] = new SqlParameter("@LastModifiedByDate", SqlDbType.DateTime);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabAnalysisBO.LastModifiedByDate;

                pSqlParameter[19] = new SqlParameter("@MainLabAnalysisID", SqlDbType.Int);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMainLabAnalysisBO.MainLabAnalysisID;


                sSql = "usp_tbl_MainLabAnalysis_Update";

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);
                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMainLabAnalysisBO = null;
            }
        }
        #endregion

        #region Delete MainLabAnalysis Data 
        /// <summary>
        /// Delete Data of Mainlab analysis table
        /// Created By : Chirag
        /// Modified By :
        /// </summary>
        public ApplicationResult MainLabAnalysis_Delete(int intID, int intUserID)
        {
            DateTime dtDateTime = DateTime.UtcNow.AddHours(5.5);
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intID;

                pSqlParameter[1] = new SqlParameter("@UserID", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intUserID;

                pSqlParameter[2] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = dtDateTime;

                strStoredProcName = "usp_tbl_MainLabAnalysis_Delete";

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Select Data for Report
        public ApplicationResult MainLabAnalysis_SelectAll_For_Report(DateTime dtFromDateTime, DateTime dtToDateTime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = dtFromDateTime;

                pSqlParameter[1] = new SqlParameter("@ToDateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = dtToDateTime;


                strStoredProcName = "usp_rpt_MainLabAnalysis_SelectAll_For_Report";
                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);

                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
