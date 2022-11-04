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
                pSqlParameter = new SqlParameter[40];

                pSqlParameter[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabAnalysisBO.DateTime;

                pSqlParameter[1] = new SqlParameter("@TankNo", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabAnalysisBO.TankID;

                pSqlParameter[2] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabAnalysisBO.BatchNo;

                pSqlParameter[3] = new SqlParameter("@ProductID", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabAnalysisBO.ProductID;

                pSqlParameter[4] = new SqlParameter("@IsAuto", SqlDbType.Bit);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabAnalysisBO.IsAuto;

                pSqlParameter[5] = new SqlParameter("@Temp", SqlDbType.Float);
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

                pSqlParameter[9] = new SqlParameter("@Mbrt", SqlDbType.Float);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabAnalysisBO.Mbrt;

                pSqlParameter[10] = new SqlParameter("@PhospharseTest", SqlDbType.Int);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabAnalysisBO.PhospharaseTest;

                pSqlParameter[11] = new SqlParameter("@Alcohol", SqlDbType.Float);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabAnalysisBO.Alcohol;

                pSqlParameter[12] = new SqlParameter("@Adultration", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabAnalysisBO.Adultration;

                pSqlParameter[13] = new SqlParameter("@AerobicPlate", SqlDbType.Float);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabAnalysisBO.AerobicPlate;

                pSqlParameter[14] = new SqlParameter("@Coliform", SqlDbType.Float);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabAnalysisBO.Coliform;

                pSqlParameter[15] = new SqlParameter("@SomaticCell", SqlDbType.Float);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabAnalysisBO.SomaticCell;

                pSqlParameter[16] = new SqlParameter("@CremingIndex", SqlDbType.Float);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabAnalysisBO.CremingIndex;

                pSqlParameter[17] = new SqlParameter("@TotalSolid", SqlDbType.Float);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabAnalysisBO.TotalSolid;

                pSqlParameter[18] = new SqlParameter("@Ph", SqlDbType.Float);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabAnalysisBO.Ph;

                pSqlParameter[19] = new SqlParameter("@Appearance", SqlDbType.Int);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMainLabAnalysisBO.Appearance;

                pSqlParameter[20] = new SqlParameter("@BodyAndTexture", SqlDbType.Int);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMainLabAnalysisBO.BodyAndTexture;

                pSqlParameter[21] = new SqlParameter("@Flavour", SqlDbType.Int);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMainLabAnalysisBO.Flavour;

                pSqlParameter[22] = new SqlParameter("@Moisture", SqlDbType.Float);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMainLabAnalysisBO.Moisture;

                pSqlParameter[23] = new SqlParameter("@FFAOA", SqlDbType.Float);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMainLabAnalysisBO.FFAOA;

                pSqlParameter[24] = new SqlParameter("@BRReading", SqlDbType.Float);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMainLabAnalysisBO.BRReading;

                pSqlParameter[25] = new SqlParameter("@RMValue", SqlDbType.Float);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMainLabAnalysisBO.RMValue;

                pSqlParameter[26] = new SqlParameter("@PValue", SqlDbType.Float);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMainLabAnalysisBO.PValue;

                pSqlParameter[27] = new SqlParameter("@BauduinTest", SqlDbType.Int);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objMainLabAnalysisBO.BauduinTest;

                pSqlParameter[28] = new SqlParameter("@EColi", SqlDbType.Float);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objMainLabAnalysisBO.EColi;

                pSqlParameter[29] = new SqlParameter("@SucrosePercent", SqlDbType.Float);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objMainLabAnalysisBO.SucrosePercent;

                pSqlParameter[30] = new SqlParameter("@InsolubilityIndex", SqlDbType.Float);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objMainLabAnalysisBO.InsolubilityIndex;

                pSqlParameter[31] = new SqlParameter("@Protein", SqlDbType.Float);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objMainLabAnalysisBO.Protein;

                pSqlParameter[32] = new SqlParameter("@TotalAsh", SqlDbType.Float);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objMainLabAnalysisBO.TotalAsh;

                pSqlParameter[33] = new SqlParameter("@ScorchedParticle", SqlDbType.Float);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objMainLabAnalysisBO.ScorchedParticle;

                pSqlParameter[34] = new SqlParameter("@BulkDensity", SqlDbType.Float);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objMainLabAnalysisBO.BulkDensity;

                pSqlParameter[35] = new SqlParameter("@Wettability", SqlDbType.Float);
                pSqlParameter[35].Direction = ParameterDirection.Input;
                pSqlParameter[35].Value = objMainLabAnalysisBO.Wettability;

                pSqlParameter[36] = new SqlParameter("@CreatedByID", SqlDbType.Int);
                pSqlParameter[36].Direction = ParameterDirection.Input;
                pSqlParameter[36].Value = objMainLabAnalysisBO.CreatedByID;

                pSqlParameter[37] = new SqlParameter("@CreatedByDate", SqlDbType.DateTime);
                pSqlParameter[37].Direction = ParameterDirection.Input;
                pSqlParameter[37].Value = objMainLabAnalysisBO.CreatedByDate;

                pSqlParameter[38] = new SqlParameter("@Status", SqlDbType.Int);
                pSqlParameter[38].Direction = ParameterDirection.Input;
                pSqlParameter[38].Value = objMainLabAnalysisBO.Status;

                pSqlParameter[39] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[39].Direction = ParameterDirection.Input;
                pSqlParameter[39].Value = objMainLabAnalysisBO.Remarks;


                sSql = "usp_tbl_MainLabAnalysis_Insert_New";

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
        /// Created By : Chiragkumar Solanki
        /// Modified By :
        /// </summary>
        public ApplicationResult MainLabAnalysis_SelectAll_For_Gridview(DateTime dtDateTime)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = dtDateTime;

                sSql = "usp_tbl_MainLabAnalysis_SelectAll_For_Gridview_New";
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

                pSqlParameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intMainLabAnalysisID;

                strStoredProcName = "usp_tbl_MainLabAnalysis_Select_For_Edit_New";

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
                pSqlParameter = new SqlParameter[41];

                pSqlParameter[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabAnalysisBO.DateTime;

                pSqlParameter[1] = new SqlParameter("@TankNo", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabAnalysisBO.TankID;

                pSqlParameter[2] = new SqlParameter("@BatchNo", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabAnalysisBO.BatchNo;

                pSqlParameter[3] = new SqlParameter("@ProductID", SqlDbType.Int);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabAnalysisBO.ProductID;

                pSqlParameter[4] = new SqlParameter("@IsAuto", SqlDbType.Bit);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabAnalysisBO.IsAuto;

                pSqlParameter[5] = new SqlParameter("@Temp", SqlDbType.Float);
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

                pSqlParameter[9] = new SqlParameter("@Mbrt", SqlDbType.Float);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabAnalysisBO.Mbrt;

                pSqlParameter[10] = new SqlParameter("@PhospharseTest", SqlDbType.Int);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabAnalysisBO.PhospharaseTest;

                pSqlParameter[11] = new SqlParameter("@Alcohol", SqlDbType.Float);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabAnalysisBO.Alcohol;

                pSqlParameter[12] = new SqlParameter("@Adultration", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabAnalysisBO.Adultration;

                pSqlParameter[13] = new SqlParameter("@AerobicPlate", SqlDbType.Float);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabAnalysisBO.AerobicPlate;

                pSqlParameter[14] = new SqlParameter("@Coliform", SqlDbType.Float);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabAnalysisBO.Coliform;

                pSqlParameter[15] = new SqlParameter("@SomaticCell", SqlDbType.Float);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabAnalysisBO.SomaticCell;

                pSqlParameter[16] = new SqlParameter("@CremingIndex", SqlDbType.Float);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabAnalysisBO.CremingIndex;

                pSqlParameter[17] = new SqlParameter("@TotalSolid", SqlDbType.Float);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabAnalysisBO.TotalSolid;

                pSqlParameter[18] = new SqlParameter("@Ph", SqlDbType.Float);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabAnalysisBO.Ph;

                pSqlParameter[19] = new SqlParameter("@Appearance", SqlDbType.Int);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMainLabAnalysisBO.Appearance;

                pSqlParameter[20] = new SqlParameter("@BodyAndTexture", SqlDbType.Int);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMainLabAnalysisBO.BodyAndTexture;

                pSqlParameter[21] = new SqlParameter("@Flavour", SqlDbType.Int);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMainLabAnalysisBO.Flavour;

                pSqlParameter[22] = new SqlParameter("@Moisture", SqlDbType.Float);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMainLabAnalysisBO.Moisture;

                pSqlParameter[23] = new SqlParameter("@FFAOA", SqlDbType.Float);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMainLabAnalysisBO.FFAOA;

                pSqlParameter[24] = new SqlParameter("@BRReading", SqlDbType.Float);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMainLabAnalysisBO.BRReading;

                pSqlParameter[25] = new SqlParameter("@RMValue", SqlDbType.Float);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMainLabAnalysisBO.RMValue;

                pSqlParameter[26] = new SqlParameter("@PValue", SqlDbType.Float);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMainLabAnalysisBO.PValue;

                pSqlParameter[27] = new SqlParameter("@BauduinTest", SqlDbType.Int);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objMainLabAnalysisBO.BauduinTest;

                pSqlParameter[28] = new SqlParameter("@EColi", SqlDbType.Float);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objMainLabAnalysisBO.EColi;

                pSqlParameter[29] = new SqlParameter("@SucrosePercent", SqlDbType.Float);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objMainLabAnalysisBO.SucrosePercent;

                pSqlParameter[30] = new SqlParameter("@InsolubilityIndex", SqlDbType.Float);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objMainLabAnalysisBO.InsolubilityIndex;

                pSqlParameter[31] = new SqlParameter("@Protein", SqlDbType.Float);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objMainLabAnalysisBO.Protein;

                pSqlParameter[32] = new SqlParameter("@TotalAsh", SqlDbType.Float);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objMainLabAnalysisBO.TotalAsh;

                pSqlParameter[33] = new SqlParameter("@ScorchedParticle", SqlDbType.Float);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objMainLabAnalysisBO.ScorchedParticle;

                pSqlParameter[34] = new SqlParameter("@BulkDensity", SqlDbType.Float);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objMainLabAnalysisBO.BulkDensity;

                pSqlParameter[35] = new SqlParameter("@Wettability", SqlDbType.Float);
                pSqlParameter[35].Direction = ParameterDirection.Input;
                pSqlParameter[35].Value = objMainLabAnalysisBO.Wettability;

                pSqlParameter[36] = new SqlParameter("@LastModifiedByID", SqlDbType.Int);
                pSqlParameter[36].Direction = ParameterDirection.Input;
                pSqlParameter[36].Value = objMainLabAnalysisBO.LastModifiedByID;

                pSqlParameter[37] = new SqlParameter("@LastModifiedByDate", SqlDbType.DateTime);
                pSqlParameter[37].Direction = ParameterDirection.Input;
                pSqlParameter[37].Value = objMainLabAnalysisBO.LastModifiedByDate;

                pSqlParameter[38] = new SqlParameter("@Status", SqlDbType.Int);
                pSqlParameter[38].Direction = ParameterDirection.Input;
                pSqlParameter[38].Value = objMainLabAnalysisBO.Status;

                pSqlParameter[39] = new SqlParameter("@Remarks", SqlDbType.VarChar);
                pSqlParameter[39].Direction = ParameterDirection.Input;
                pSqlParameter[39].Value = objMainLabAnalysisBO.Remarks;

                pSqlParameter[40] = new SqlParameter("@MainLabID", SqlDbType.Int);
                pSqlParameter[40].Direction = ParameterDirection.Input;
                pSqlParameter[40].Value = objMainLabAnalysisBO.MainLabID;


                sSql = "usp_tbl_MainLabAnalysis_Update_New";

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

                strStoredProcName = "usp_tbl_MainLabAnalysis_Delete_New";

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
