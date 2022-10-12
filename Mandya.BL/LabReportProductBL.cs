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
    public class LabReportProductBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Insert Event
        public ApplicationResult MainLabProduct_Insert(MainLabProductBO objMainLabProductBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[35];

                pSqlParameter[0] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabProductBO.ProductName;

                pSqlParameter[1] = new SqlParameter("@Temp", SqlDbType.Bit);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabProductBO.Temp;

                pSqlParameter[2] = new SqlParameter("@Acidity", SqlDbType.Bit);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabProductBO.Acidity;

                pSqlParameter[3] = new SqlParameter("@Fat", SqlDbType.Bit);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabProductBO.Fat;

                pSqlParameter[4] = new SqlParameter("@Snf", SqlDbType.Bit);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabProductBO.Snf;

                pSqlParameter[5] = new SqlParameter("@Mbrt", SqlDbType.Bit);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMainLabProductBO.Mbrt;

                pSqlParameter[6] = new SqlParameter("@PhospharasTest", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMainLabProductBO.PhospharaseTest;

                pSqlParameter[7] = new SqlParameter("@Alcohol", SqlDbType.Bit);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMainLabProductBO.Alcohol;

                pSqlParameter[8] = new SqlParameter("@Adultration", SqlDbType.Bit);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMainLabProductBO.Adultration;

                pSqlParameter[9] = new SqlParameter("@AerobicPlate", SqlDbType.Bit);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabProductBO.AerobicPlate;

                pSqlParameter[10] = new SqlParameter("@Coliform", SqlDbType.Bit);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabProductBO.Coliform;

                pSqlParameter[11] = new SqlParameter("@YeastAndMoulds", SqlDbType.Bit);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabProductBO.YeastAndMoulds;

                pSqlParameter[12] = new SqlParameter("@SomaticCell", SqlDbType.Bit);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabProductBO.SomaticCell;

                pSqlParameter[13] = new SqlParameter("@CremingIndex", SqlDbType.Bit);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabProductBO.CremingIndex;

                pSqlParameter[14] = new SqlParameter("@TotalSolid", SqlDbType.Bit);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabProductBO.TotalSolid;

                pSqlParameter[15] = new SqlParameter("@Ph", SqlDbType.Bit);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabProductBO.Ph;

                pSqlParameter[16] = new SqlParameter("@Appearance", SqlDbType.Bit);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabProductBO.Appearance;

                pSqlParameter[17] = new SqlParameter("@BodyAndTexture", SqlDbType.Bit);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabProductBO.BodyAndTexture;

                pSqlParameter[18] = new SqlParameter("@Flavour", SqlDbType.Bit);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabProductBO.Flavuor;

                pSqlParameter[19] = new SqlParameter("@Moisture", SqlDbType.Bit);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMainLabProductBO.Moisture;

                pSqlParameter[20] = new SqlParameter("@FFAOA", SqlDbType.Bit);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMainLabProductBO.FFAOA;

                pSqlParameter[21] = new SqlParameter("@BRReading", SqlDbType.Bit);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMainLabProductBO.BRReading;

                pSqlParameter[22] = new SqlParameter("@RMValue", SqlDbType.Bit);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMainLabProductBO.RMValue;

                pSqlParameter[23] = new SqlParameter("@PValue", SqlDbType.Bit);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMainLabProductBO.PValue;

                pSqlParameter[24] = new SqlParameter("@BauduinTest", SqlDbType.Bit);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMainLabProductBO.BauduinTest;

                pSqlParameter[25] = new SqlParameter("@EColi", SqlDbType.Bit);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMainLabProductBO.EColi;

                pSqlParameter[26] = new SqlParameter("@SucrosePercent", SqlDbType.Bit);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMainLabProductBO.SucrosePercent;

                pSqlParameter[27] = new SqlParameter("@InsolubilityIndex", SqlDbType.Bit);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objMainLabProductBO.InsolubilityIndex;

                pSqlParameter[28] = new SqlParameter("@Protein", SqlDbType.Bit);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objMainLabProductBO.Protein;

                pSqlParameter[29] = new SqlParameter("@TotalAsh", SqlDbType.Bit);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objMainLabProductBO.TotalAsh;

                pSqlParameter[30] = new SqlParameter("@ScorchedParticle", SqlDbType.Bit);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objMainLabProductBO.ScorchedParticle;

                pSqlParameter[31] = new SqlParameter("@BulkDensity", SqlDbType.Bit);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objMainLabProductBO.BulkDensity;

                pSqlParameter[32] = new SqlParameter("@Wettability", SqlDbType.Bit);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objMainLabProductBO.Wettability;

                pSqlParameter[33] = new SqlParameter("@CreatedByID", SqlDbType.Int);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objMainLabProductBO.CreatedByID;

                pSqlParameter[34] = new SqlParameter("@CreatedByDate", SqlDbType.DateTime);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objMainLabProductBO.CreatedByDate;

                sSql = "usp_tbl_LabReportProduct_Insert";

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
                objMainLabProductBO = null;
            }
        }

        #endregion

        #region Update Event
        public ApplicationResult MainLabProduct_Update(MainLabProductBO objMainLabProductBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[35];

                pSqlParameter[0] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabProductBO.ProductName;

                pSqlParameter[1] = new SqlParameter("@Temp", SqlDbType.Bit);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabProductBO.Temp;

                pSqlParameter[2] = new SqlParameter("@Acidity", SqlDbType.Bit);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabProductBO.Acidity;

                pSqlParameter[3] = new SqlParameter("@Fat", SqlDbType.Bit);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabProductBO.Fat;

                pSqlParameter[4] = new SqlParameter("@Snf", SqlDbType.Bit);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabProductBO.Snf;

                pSqlParameter[5] = new SqlParameter("@Mbrt", SqlDbType.Bit);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMainLabProductBO.Mbrt;

                pSqlParameter[6] = new SqlParameter("@PhospharasTest", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMainLabProductBO.PhospharaseTest;

                pSqlParameter[7] = new SqlParameter("@Alcohol", SqlDbType.Bit);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMainLabProductBO.Alcohol;

                pSqlParameter[8] = new SqlParameter("@Adultration", SqlDbType.Bit);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMainLabProductBO.Adultration;

                pSqlParameter[9] = new SqlParameter("@AerobicPlate", SqlDbType.Bit);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabProductBO.AerobicPlate;

                pSqlParameter[10] = new SqlParameter("@Coliform", SqlDbType.Bit);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabProductBO.Coliform;

                pSqlParameter[11] = new SqlParameter("@YeastAndMoulds", SqlDbType.Bit);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabProductBO.YeastAndMoulds;

                pSqlParameter[12] = new SqlParameter("@SomaticCell", SqlDbType.Bit);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabProductBO.SomaticCell;

                pSqlParameter[13] = new SqlParameter("@CremingIndex", SqlDbType.Bit);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabProductBO.CremingIndex;

                pSqlParameter[14] = new SqlParameter("@TotalSolid", SqlDbType.Bit);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabProductBO.TotalSolid;

                pSqlParameter[15] = new SqlParameter("@Ph", SqlDbType.Bit);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabProductBO.Ph;

                pSqlParameter[16] = new SqlParameter("@Appearance", SqlDbType.Bit);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabProductBO.Appearance;

                pSqlParameter[17] = new SqlParameter("@BodyAndTexture", SqlDbType.Bit);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabProductBO.BodyAndTexture;

                pSqlParameter[18] = new SqlParameter("@Flavour", SqlDbType.Bit);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabProductBO.Flavuor;

                pSqlParameter[19] = new SqlParameter("@Moisture", SqlDbType.Bit);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMainLabProductBO.Moisture;

                pSqlParameter[20] = new SqlParameter("@FFAOA", SqlDbType.Bit);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMainLabProductBO.FFAOA;

                pSqlParameter[21] = new SqlParameter("@BRReading", SqlDbType.Bit);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMainLabProductBO.BRReading;

                pSqlParameter[22] = new SqlParameter("@RMValue", SqlDbType.Bit);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMainLabProductBO.RMValue;

                pSqlParameter[23] = new SqlParameter("@PValue", SqlDbType.Bit);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMainLabProductBO.PValue;

                pSqlParameter[24] = new SqlParameter("@BauduinTest", SqlDbType.Bit);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMainLabProductBO.BauduinTest;

                pSqlParameter[25] = new SqlParameter("@EColi", SqlDbType.Bit);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMainLabProductBO.EColi;

                pSqlParameter[26] = new SqlParameter("@SucrosePercent", SqlDbType.Bit);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMainLabProductBO.SucrosePercent;

                pSqlParameter[27] = new SqlParameter("@InsolubilityIndex", SqlDbType.Bit);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objMainLabProductBO.InsolubilityIndex;

                pSqlParameter[28] = new SqlParameter("@Protein", SqlDbType.Bit);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objMainLabProductBO.Protein;

                pSqlParameter[29] = new SqlParameter("@TotalAsh", SqlDbType.Bit);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objMainLabProductBO.TotalAsh;

                pSqlParameter[30] = new SqlParameter("@ScorchedParticle", SqlDbType.Bit);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objMainLabProductBO.ScorchedParticle;

                pSqlParameter[31] = new SqlParameter("@BulkDensity", SqlDbType.Bit);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objMainLabProductBO.BulkDensity;

                pSqlParameter[32] = new SqlParameter("@Wettability", SqlDbType.Bit);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objMainLabProductBO.Wettability;

                pSqlParameter[33] = new SqlParameter("@LastModifiedByID", SqlDbType.Int);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objMainLabProductBO.LastModifiedByID;

                pSqlParameter[34] = new SqlParameter("@ID", SqlDbType.Int);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objMainLabProductBO.ID;

                sSql = "usp_tbl_LabReportProduct_update";

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
                objMainLabProductBO = null;
            }
        }

        #endregion

        #region Delete MainLabAnalysis Data 
        /// <summary>
        /// Delete Data of Mainlab analysis table
        /// Created By : Chirag
        /// Modified By :
        /// </summary>
        public ApplicationResult MainLabProduct_Delete(MainLabProductBO objMainLabProductBO)
        {
            DateTime dtDateTime = DateTime.UtcNow.AddHours(5.5);
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabProductBO.ID;

                pSqlParameter[1] = new SqlParameter("@LastModifiedByID", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabProductBO.LastModifiedByID;

                pSqlParameter[2] = new SqlParameter("@LastModifiedByDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabProductBO.LastModifiedByDate;

                strStoredProcName = "usp_tbl_LabReportProduct_Delete";

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

        #region DropDown data Bind

        public ApplicationResult MainLabProduct_Select_Product()
        {
            try
            {
                sSql = "usp_tbl_LabReportProduct_DropDownSelect";
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

        #region Delete MainLabAnalysis Data 
        /// <summary>
        /// Delete Data of Mainlab analysis table
        /// Created By : Chirag
        /// Modified By :
        /// </summary>
        public ApplicationResult MainLabProduct_SelectProduct(int intID)
        {
            try
            {
                DataTable dtFault = new DataTable();
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@ID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intID;

                strStoredProcName = "usp_tbl_LabReportProduct_Select_ByID";

                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);

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

        #region Validate Product Name 
        /// <summary>
        /// Validate Product Name
        /// Created By : Chirag
        /// Modified By :
        /// </summary>
        public ApplicationResult Validate_ProductName(string productName)
        {
            try
            {
                DataTable dtFault = new DataTable();
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@ProductName", SqlDbType.VarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = productName;

                strStoredProcName = "usp_tbl_Validate_ProductName";

                dtFault = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);

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
    }


}
