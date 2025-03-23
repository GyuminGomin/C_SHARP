using Microsoft.EntityFrameworkCore.Storage;
using WindowsFormCSharp.Config;
using WindowsFormCSharp;
using System.Data;

namespace WindowsFormCSharp._PCMLabel
{
    class PCMLabelQuery : Query
    {
        private readonly ODBC _context;
        public PCMLabelQuery()
        {
            _context = ODBC.GetInstance();
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public List<Dictionary<string, object>> FindProductQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.FindProductQry */
                SELECT ITEM_CD,
                       KIND_CD,
                       ITEM_NAME,
                       ENG_NAME,
                       ITEM_MAIN,
                       (
                        SELECT T2.ITEM_NAME
                          FROM TB_ITEM T2
                         WHERE T2.ITEM_CD = T.ITEM_MAIN
                       ) BUI,
                       ITEM_UNIT,
                       BASE_WT_FRESH,
                       BASE_WT_COOL,
                       BASE_WT_COLD,
                       BOX_FRESH_WT,
                       BOX_COLD_WT,
                       BOX_COOL_WT,
                       BOX_DIV0,
                       BOX_DIV1,
                       BOX_DIV2,
                       COMP_DIV,
                       IE_DIV,
                       ITEM_DIV2,
                       ITEM_FLAG,
                       ITEM_FLAG1,
                       ITEM_OEM,
                       ITEM_RATE,
                       ITEM_RATE_WATER,
                       LABOR_RATE,
                       MAX_WT,
                       MIN_WT,
                       PROD_DIV,
                       TRANS_ITEM_CD1,
                       TRANS_ITEM_CD2,
                       OLD_ITEM,
                       NEW_CODE,
                       NO_WORKS,
                       ID_CREATE,
                       DT_CREATE,
                       IP_CREATE,
                       ID_MODIFY,
                       DT_MODIFY,
                       IP_MODIFY,
                       NVL(CIRCUL_DATE, 0) CIRCUL_DATE,
                       BARCODE
                  FROM TB_ITEM T
                 WHERE KIND_CD = 7
                   AND PROD_DIV = 1
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public List<Dictionary<string, object>> GetItemCdKindQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetItemCdKindQry */
                SELECT TI.ITEM_NAME,
                       TI.ITEM_CD
                  FROM TB_ITEM TI
                 WHERE TI.ITEM_CD LIKE :KIND_CD || '00'
                 ORDER BY TI.ITEM_CD
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }




        public List<Dictionary<string, object>> GetSubItemCdKindQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetSubItemCdKindQry */
                SELECT ITEM_CD,
                       ITEM_NAME,
                       FRZ_DIV3,
                       ENG_NAME
                  FROM TB_ITEM TI
                 WHERE SUBSTR(ITEM_CD,7,2) <> '00'
                   AND TI.ITEM_MAIN = :ITEM_MAIN
                   AND PROD_DIV = '1'
                   AND KIND_CD = 7
                 ORDER BY ITEM_CD
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }





    }
}
