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
                pSqlParameter = new SqlParameter[50];

                pSqlParameter[0] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabProductBO.ProductName;

                pSqlParameter[1] = new SqlParameter("@TEMP", SqlDbType.Bit);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabProductBO.TEMP;

                pSqlParameter[2] = new SqlParameter("@Acidity", SqlDbType.Bit);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabProductBO.Acidity;

                pSqlParameter[3] = new SqlParameter("@FAT", SqlDbType.Bit);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabProductBO.FAT;

                pSqlParameter[4] = new SqlParameter("@SNF", SqlDbType.Bit);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabProductBO.SNF;

                pSqlParameter[5] = new SqlParameter("@MBRT", SqlDbType.Bit);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMainLabProductBO.MBRT;

                pSqlParameter[6] = new SqlParameter("@PhosphateTest", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMainLabProductBO.PhosphateTest;

                pSqlParameter[7] = new SqlParameter("@Alcohol", SqlDbType.Bit);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMainLabProductBO.Alcohol;

                pSqlParameter[8] = new SqlParameter("@Adultration", SqlDbType.Bit);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMainLabProductBO.Adultration;

                pSqlParameter[9] = new SqlParameter("@AerobicplatecountML", SqlDbType.Bit);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabProductBO.AerobicplatecountML;

                pSqlParameter[10] = new SqlParameter("@ColiformcountML", SqlDbType.Bit);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabProductBO.ColiformcountML;

                pSqlParameter[11] = new SqlParameter("@YeastMoulds", SqlDbType.Bit);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabProductBO.YeastMoulds;

                pSqlParameter[12] = new SqlParameter("@somaticcellcountML", SqlDbType.Bit);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabProductBO.somaticcellcountML;

                pSqlParameter[13] = new SqlParameter("@Homogenazation", SqlDbType.Bit);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabProductBO.Homogenazation;

                pSqlParameter[14] = new SqlParameter("@Remarks", SqlDbType.Bit);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabProductBO.Remarks;

                pSqlParameter[15] = new SqlParameter("@VerifiedBy", SqlDbType.Bit);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabProductBO.VerifiedBy;

                pSqlParameter[16] = new SqlParameter("@TotalSolids", SqlDbType.Bit);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabProductBO.TotalSolids;

                pSqlParameter[17] = new SqlParameter("@Apperarance", SqlDbType.Bit);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabProductBO.Apperarance;

                pSqlParameter[18] = new SqlParameter("@Fatbymass", SqlDbType.Bit);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabProductBO.Fatbymass;

                pSqlParameter[19] = new SqlParameter("@Moisturebymass", SqlDbType.Bit);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMainLabProductBO.Moisturebymass;

                pSqlParameter[20] = new SqlParameter("@curbbymass", SqlDbType.Bit);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMainLabProductBO.curbbymass;

                pSqlParameter[21] = new SqlParameter("@AcidityLAbymass", SqlDbType.Bit);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMainLabProductBO.AcidityLAbymass;

                pSqlParameter[22] = new SqlParameter("@AerobicPlatecountg", SqlDbType.Bit);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMainLabProductBO.AerobicPlatecountg;

                pSqlParameter[23] = new SqlParameter("@Coliformcountg", SqlDbType.Bit);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMainLabProductBO.Coliformcountg;

                pSqlParameter[24] = new SqlParameter("@YeastMouldsg", SqlDbType.Bit);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMainLabProductBO.YeastMouldsg;

                pSqlParameter[25] = new SqlParameter("@ecolig", SqlDbType.Bit);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMainLabProductBO.ecolig;

                pSqlParameter[26] = new SqlParameter("@Quantity", SqlDbType.Bit);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMainLabProductBO.Quantity;

                pSqlParameter[27] = new SqlParameter("@BodyTexture", SqlDbType.Bit);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objMainLabProductBO.BodyTexture;

                pSqlParameter[28] = new SqlParameter("@Flavout", SqlDbType.Bit);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objMainLabProductBO.Flavout;

                pSqlParameter[29] = new SqlParameter("@Moisture", SqlDbType.Bit);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objMainLabProductBO.Moisture;

                pSqlParameter[30] = new SqlParameter("@FFAOA", SqlDbType.Bit);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objMainLabProductBO.FFAOA;

                pSqlParameter[31] = new SqlParameter("@BRReading", SqlDbType.Bit);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objMainLabProductBO.BRReading;

                pSqlParameter[32] = new SqlParameter("@Rmvalue", SqlDbType.Bit);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objMainLabProductBO.Rmvalue;

                pSqlParameter[33] = new SqlParameter("@pvalue", SqlDbType.Bit);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objMainLabProductBO.pvalue;

                pSqlParameter[34] = new SqlParameter("@Baudouest", SqlDbType.Bit);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objMainLabProductBO.BaudouinTest;

                pSqlParameter[35] = new SqlParameter("@fatondrymatterbassis", SqlDbType.Bit);
                pSqlParameter[35].Direction = ParameterDirection.Input;
                pSqlParameter[35].Value = objMainLabProductBO.fatondrymatterbassis;

                pSqlParameter[36] = new SqlParameter("@fatbyweight", SqlDbType.Bit);
                pSqlParameter[36].Direction = ParameterDirection.Input;
                pSqlParameter[36].Value = objMainLabProductBO.fatbyweight;

                pSqlParameter[37] = new SqlParameter("@sucrosebyweight", SqlDbType.Bit);
                pSqlParameter[37].Direction = ParameterDirection.Input;
                pSqlParameter[37].Value = objMainLabProductBO.sucrosebyweight;

                pSqlParameter[38] = new SqlParameter("@insolubilityindexprotein", SqlDbType.Bit);
                pSqlParameter[38].Direction = ParameterDirection.Input;
                pSqlParameter[38].Value = objMainLabProductBO.insolubilityindexprotein;

                pSqlParameter[39] = new SqlParameter("@TotalAshdrybasisbymass", SqlDbType.Bit);
                pSqlParameter[39].Direction = ParameterDirection.Input;
                pSqlParameter[39].Value = objMainLabProductBO.TotalAshdrybasisbymass;

                pSqlParameter[40] = new SqlParameter("@AcidityNNaOHofSNF", SqlDbType.Bit);
                pSqlParameter[40].Direction = ParameterDirection.Input;
                pSqlParameter[40].Value = objMainLabProductBO.AcidityNNaOHofSNF;

                pSqlParameter[41] = new SqlParameter("@bulkdensity", SqlDbType.Bit);
                pSqlParameter[41].Direction = ParameterDirection.Input;
                pSqlParameter[41].Value = objMainLabProductBO.bulkdensity;

                pSqlParameter[42] = new SqlParameter("@preservativeAdultrants", SqlDbType.Bit);
                pSqlParameter[42].Direction = ParameterDirection.Input;
                pSqlParameter[42].Value = objMainLabProductBO.preservativeAdultrants;

                pSqlParameter[43] = new SqlParameter("@PH", SqlDbType.Bit);
                pSqlParameter[43].Direction = ParameterDirection.Input;
                pSqlParameter[43].Value = objMainLabProductBO.PH;

                pSqlParameter[44] = new SqlParameter("@creamingIndex", SqlDbType.Bit);
                pSqlParameter[44].Direction = ParameterDirection.Input;
                pSqlParameter[44].Value = objMainLabProductBO.creamingIndex;

                pSqlParameter[45] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[45].Direction = ParameterDirection.Input;
                pSqlParameter[45].Value = objMainLabProductBO.IsDeleted;

                pSqlParameter[46] = new SqlParameter("@CreatedByID", SqlDbType.Int);
                pSqlParameter[46].Direction = ParameterDirection.Input;
                pSqlParameter[46].Value = objMainLabProductBO.CreatedByID;

                pSqlParameter[47] = new SqlParameter("@CreatedByDate", SqlDbType.DateTime);
                pSqlParameter[47].Direction = ParameterDirection.Input;
                pSqlParameter[47].Value = objMainLabProductBO.CreatedByDate;

                pSqlParameter[48] = new SqlParameter("@AerobicSporecountML", SqlDbType.Bit);
                pSqlParameter[48].Direction = ParameterDirection.Input;
                pSqlParameter[48].Value = objMainLabProductBO.AerobicSporecountML;

                pSqlParameter[49] = new SqlParameter("@ScorchedParticle", SqlDbType.Bit);
                pSqlParameter[44].Direction = ParameterDirection.Input;
                pSqlParameter[49].Value = objMainLabProductBO.ScorchedParticle;

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
                pSqlParameter = new SqlParameter[51];

                pSqlParameter[0] = new SqlParameter("@ProductID", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMainLabProductBO.ProductID;

                pSqlParameter[1] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabProductBO.ProductName;

                pSqlParameter[2] = new SqlParameter("@TEMP", SqlDbType.Bit);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMainLabProductBO.TEMP;

                pSqlParameter[3] = new SqlParameter("@Acidity", SqlDbType.Bit);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMainLabProductBO.Acidity;

                pSqlParameter[4] = new SqlParameter("@FAT", SqlDbType.Bit);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMainLabProductBO.FAT;

                pSqlParameter[5] = new SqlParameter("@SNF", SqlDbType.Bit);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMainLabProductBO.SNF;
                
                pSqlParameter[6] = new SqlParameter("@MBRT", SqlDbType.Bit);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMainLabProductBO.MBRT;

                pSqlParameter[7] = new SqlParameter("@PhosphateTest", SqlDbType.Bit);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMainLabProductBO.PhosphateTest;

                pSqlParameter[8] = new SqlParameter("@Alcohol", SqlDbType.Bit);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMainLabProductBO.Alcohol;

                pSqlParameter[9] = new SqlParameter("@Adultration", SqlDbType.Bit);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMainLabProductBO.Adultration;

                pSqlParameter[10] = new SqlParameter("@AerobicplatecountML", SqlDbType.Bit);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMainLabProductBO.AerobicplatecountML;

                pSqlParameter[11] = new SqlParameter("@ColiformcountML", SqlDbType.Bit);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMainLabProductBO.ColiformcountML;

                pSqlParameter[12] = new SqlParameter("@YeastMoulds", SqlDbType.Bit);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMainLabProductBO.YeastMoulds;

                pSqlParameter[13] = new SqlParameter("@somaticcellcountML", SqlDbType.Bit);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMainLabProductBO.somaticcellcountML;

                pSqlParameter[14] = new SqlParameter("@Homogenazation", SqlDbType.Bit);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objMainLabProductBO.Homogenazation;

                pSqlParameter[15] = new SqlParameter("@Remarks", SqlDbType.Bit);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objMainLabProductBO.Remarks;

                pSqlParameter[16] = new SqlParameter("@VerifiedBy", SqlDbType.Bit);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objMainLabProductBO.VerifiedBy;

                pSqlParameter[17] = new SqlParameter("@TotalSolids", SqlDbType.Bit);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objMainLabProductBO.TotalSolids;

                pSqlParameter[18] = new SqlParameter("@Apperarance", SqlDbType.Bit);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objMainLabProductBO.Apperarance;

                pSqlParameter[19] = new SqlParameter("@Fatbymass", SqlDbType.Bit);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objMainLabProductBO.Fatbymass;

                pSqlParameter[20] = new SqlParameter("@Moisturebymass", SqlDbType.Bit);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objMainLabProductBO.Moisturebymass;

                pSqlParameter[21] = new SqlParameter("@curbbymass", SqlDbType.Bit);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objMainLabProductBO.curbbymass;

                pSqlParameter[22] = new SqlParameter("@AcidityLAbymass", SqlDbType.Bit);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objMainLabProductBO.AcidityLAbymass;

                pSqlParameter[23] = new SqlParameter("@AerobicPlatecountg", SqlDbType.Bit);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objMainLabProductBO.AerobicPlatecountg;

                pSqlParameter[24] = new SqlParameter("@Coliformcountg", SqlDbType.Bit);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objMainLabProductBO.Coliformcountg;

                pSqlParameter[25] = new SqlParameter("@YeastMouldsg", SqlDbType.Bit);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objMainLabProductBO.YeastMouldsg;

                pSqlParameter[26] = new SqlParameter("@ecolig", SqlDbType.Bit);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objMainLabProductBO.ecolig;

                pSqlParameter[27] = new SqlParameter("@Quantity", SqlDbType.Bit);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objMainLabProductBO.Quantity;

                pSqlParameter[28] = new SqlParameter("@BodyTexture", SqlDbType.Bit);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objMainLabProductBO.BodyTexture;

                pSqlParameter[29] = new SqlParameter("@Flavout", SqlDbType.Bit);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objMainLabProductBO.Flavout;

                pSqlParameter[30] = new SqlParameter("@Moisture", SqlDbType.Bit);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objMainLabProductBO.Moisture;

                pSqlParameter[31] = new SqlParameter("@FFAOA", SqlDbType.Bit);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objMainLabProductBO.FFAOA;

                pSqlParameter[32] = new SqlParameter("@BRReading", SqlDbType.Bit);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objMainLabProductBO.BRReading;

                pSqlParameter[33] = new SqlParameter("@Rmvalue", SqlDbType.Bit);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objMainLabProductBO.Rmvalue;

                pSqlParameter[34] = new SqlParameter("@pvalue", SqlDbType.Bit);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objMainLabProductBO.pvalue;

                pSqlParameter[35] = new SqlParameter("@Baudouest", SqlDbType.Bit);
                pSqlParameter[35].Direction = ParameterDirection.Input;
                pSqlParameter[35].Value = objMainLabProductBO.BaudouinTest;

                pSqlParameter[36] = new SqlParameter("@fatondrymatterbassis", SqlDbType.Bit);
                pSqlParameter[36].Direction = ParameterDirection.Input;
                pSqlParameter[36].Value = objMainLabProductBO.fatondrymatterbassis;

                pSqlParameter[37] = new SqlParameter("@fatbyweight", SqlDbType.Bit);
                pSqlParameter[37].Direction = ParameterDirection.Input;
                pSqlParameter[37].Value = objMainLabProductBO.fatbyweight;

                pSqlParameter[38] = new SqlParameter("@sucrosebyweight", SqlDbType.Bit);
                pSqlParameter[38].Direction = ParameterDirection.Input;
                pSqlParameter[38].Value = objMainLabProductBO.sucrosebyweight;

                pSqlParameter[39] = new SqlParameter("@insolubilityindexprotein", SqlDbType.Bit);
                pSqlParameter[39].Direction = ParameterDirection.Input;
                pSqlParameter[39].Value = objMainLabProductBO.insolubilityindexprotein;

                pSqlParameter[40] = new SqlParameter("@TotalAshdrybasisbymass", SqlDbType.Bit);
                pSqlParameter[40].Direction = ParameterDirection.Input;
                pSqlParameter[40].Value = objMainLabProductBO.TotalAshdrybasisbymass;

                pSqlParameter[41] = new SqlParameter("@AcidityNNaOHofSNF", SqlDbType.Bit);
                pSqlParameter[41].Direction = ParameterDirection.Input;
                pSqlParameter[41].Value = objMainLabProductBO.AcidityNNaOHofSNF;

                pSqlParameter[42] = new SqlParameter("@bulkdensity", SqlDbType.Bit);
                pSqlParameter[42].Direction = ParameterDirection.Input;
                pSqlParameter[42].Value = objMainLabProductBO.bulkdensity;

                pSqlParameter[43] = new SqlParameter("@preservativeAdultrants", SqlDbType.Bit);
                pSqlParameter[43].Direction = ParameterDirection.Input;
                pSqlParameter[43].Value = objMainLabProductBO.preservativeAdultrants;

                pSqlParameter[44] = new SqlParameter("@PH", SqlDbType.Bit);
                pSqlParameter[44].Direction = ParameterDirection.Input;
                pSqlParameter[44].Value = objMainLabProductBO.PH;

                pSqlParameter[45] = new SqlParameter("@creamingIndex", SqlDbType.Bit);
                pSqlParameter[45].Direction = ParameterDirection.Input;
                pSqlParameter[45].Value = objMainLabProductBO.creamingIndex;

                pSqlParameter[46] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[46].Direction = ParameterDirection.Input;
                pSqlParameter[46].Value = objMainLabProductBO.IsDeleted;

                pSqlParameter[47] = new SqlParameter("@LastModifiedByID", SqlDbType.Int);
                pSqlParameter[47].Direction = ParameterDirection.Input;
                pSqlParameter[47].Value = objMainLabProductBO.LastModifiedByID;

                pSqlParameter[48] = new SqlParameter("@LastModifiedByDate", SqlDbType.DateTime);
                pSqlParameter[48].Direction = ParameterDirection.Input;
                pSqlParameter[48].Value = objMainLabProductBO.LastModifiedByDate;

                pSqlParameter[49] = new SqlParameter("@AerobicSporecountML", SqlDbType.Bit);
                pSqlParameter[49].Direction = ParameterDirection.Input;
                pSqlParameter[49].Value = objMainLabProductBO.AerobicSporecountML;

                pSqlParameter[50] = new SqlParameter("@ScorchedParticles", SqlDbType.Bit);
                pSqlParameter[50].Direction = ParameterDirection.Input;
                pSqlParameter[50].Value = objMainLabProductBO.ScorchedParticle;

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
                pSqlParameter[0].Value = objMainLabProductBO.ProductID;

                pSqlParameter[1] = new SqlParameter("@UserID", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMainLabProductBO.LastModifiedByID;

                pSqlParameter[2] = new SqlParameter("@DateTime", SqlDbType.DateTime);
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
        
        DateTime dtDateTime = DateTime.UtcNow.AddHours(5.5);
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
   }
    

}
