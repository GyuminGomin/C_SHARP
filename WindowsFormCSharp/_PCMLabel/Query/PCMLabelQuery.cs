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

        public List<Dictionary<string, object>> GetSubItemFilterEngNameQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetSubItemCdKindFilterQry */
                SELECT ITEM_CD,
                       ITEM_NAME,
                       FRZ_DIV3,
                       ENG_NAME
                  FROM TB_ITEM TI
                 WHERE SUBSTR(ITEM_CD,7,2) <> '00'
                   AND TI.ITEM_MAIN = :ITEM_MAIN
                   AND PROD_DIV = '1'
                   AND KIND_CD = 7
                   AND ENG_NAME LIKE '%1등급이상%'
                 ORDER BY ITEM_CD
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetTraceInfoQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetTraceInfoQry */
                SELECT NVL(A.TRACE_NO, A.ID_CREATE) TRACE_NO
                  FROM JOB_DETAIL A
                 WHERE A.JOB_DATE = :TEMP_DATE
                   AND A.KIND_CD = 7
                   AND A.ITEM_CD = :ITEM_CD
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetSubItemDetailQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetSubItemDetailQry */
                SELECT A.ITEM_CD,
                       B.ITEM_NAME,
                       A.WORK_FRZ2,
                       A.TRACE_NO
                  FROM JOB_DETAIL A, TB_ITEM B
                 WHERE A.JOB_DATE = (
                                     SELECT MAX(JD.JOB_DATE)
                                       FROM JOB_DETAIL JD
                                      WHERE JD.KIND_CD = 7
                                        AND JD.JOB_DATE > TO_CHAR(TO_DATE(:TEMP_DATE,'YYYYMMDD')-7,'YYYYMMDD')
                                        AND JD.JOB_DATE < :TEMP_DATE
                                    )
                   AND A.KIND_CD = 7
                   AND A.ITEM_CD = B.ITEM_CD
                   AND A.ITEM_CD = :ITEM_CD
                   AND A.WORK_FRZ2 > 0
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetOrderQtyEveryQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetOrderQtyEveryQry */
                SELECT SUM(B.ORDER_QTY) ORDER_QTY
                  FROM ORDER_REF A,
                       ORDER_DETAIL B,
                       TB_ITEM C,
                       TB_COMPANY D
                 WHERE A.KIND_CD = 7
                   AND A.ORDER_DATE = B.ORDER_DATE
                   AND A.ORDER_NO = B.ORDER_NO
                   AND B.ITEM_CD = C.ITEM_CD
                   AND A.NO_COMPANY_SEQ = D.NO_COMPANY_SEQ
                   AND A.CHANG_NO = 7
                   AND A.ORDER_DATE = :ORDER_DATE
                   AND B.ITEM_CD = :ITEM_CD
                   AND D.COMPANY_NAME LIKE '%에브리데이%'
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetOrderQtyNotEveryQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetOrderQtyNotEveryQry */
                SELECT SUM(B.ORDER_QTY) ORDER_QTY
                  FROM ORDER_REF A,
                       ORDER_DETAIL B,
                       TB_ITEM C,
                       TB_COMPANY D
                 WHERE A.KIND_CD = 7
                   AND A.ORDER_DATE = B.ORDER_DATE
                   AND A.ORDER_NO = B.ORDER_NO
                   AND B.ITEM_CD = C.ITEM_CD
                   AND A.NO_COMPANY_SEQ = D.NO_COMPANY_SEQ
                   AND A.CHANG_NO = 7
                   AND A.ORDER_DATE = :ORDER_DATE
                   AND B.ITEM_CD = :ITEM_CD
                   AND D.COMPANY_NAME NOT LIKE '%에브리데이%'
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetYukGagongItemInfoQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetYukGagongItemInfoQry */
                SELECT ENG_NAME YONGDO, 
                       BASE_WT_COOL SALE_WT,
                       TRIM(BARCODE) BARCODE, -- 88 코드?
                       REPLACE(NVL(BOGO_NO1,''),'-','') SUB_BUI,
                       NVL(BOGO_NO2,'') CHANGE_BUI,
                       NVL(CIRCUL_DATE, 0) CIRCUL_DATE,
                       ITEM_NAME ITEM_NAME,
                       FNC_ITEM_NAME(ITEM_MAIN) ITEM_MAIN
                  FROM TB_ITEM
                 WHERE ITEM_CD = :PCM_ITEM
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        // 존재이유 : 부경축산물공판장만 작업하는가 아니면, 둘다 작업하는가, 제일리버스만 작업하는가를 가져오기 위해
        public List<Dictionary<string, object>> GetYukGagongKillAreaL1Qry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetYukGagongKillAreaL1Qry */
                SELECT (XMLAGG(XMLELEMENT(x,',',TEXT) ORDER BY ORDB).EXTRACT('//TEXT()').getstringVal(), 2) KILL_AREA
                  FROM (
                        SELECT DISTINCT DECODE(SUBSTR(J.ID_MODIFY, 9, 4), '9195', '부경축산물공판장'
                                                                        , '9925', '(주)제일리버스') TEXT,
                               SUBSTR(J.ID_MODIFY, 9, 4) ORDB
                          FROM JOB_ORDER J
                         WHERE J.ID_CREATE = :TRACE_NO
                      )
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetYukGagongKillAreaL0Qry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetYukGagongKillAreaL0Qry */
                SELECT DECODE(COUNT(*), 2, '김해축산물공판장,부경축산물공판장', MAX(AREA)) KILL_AREA
                  FROM (
                        SELECT DISTINCT B.GRADE,
                               DECODE(B.WORK_AREA, 1, '김해축산물공판장','부경축산물공판장') AREA
                          FROM OUT_REF A,
                               PROD_COW B
                         WHERE A.KIND_CD = 1
                           AND A.BOX_NO = B.BOX_NO
                           AND B.OLD_CODE IS NOT NULL
                           AND A.OUT_FLAG = 1
                           AND A.NO_COMPANY_SEQ = 10503
                           AND B.PROD_DATE > TO_CHAR(ADD_MONTHS(SYSDATE, -12), 'YYYYMMDD')
                           AND B.OLD_CODE IN (
                                              SELECT JO.ID_MODIFY
                                                FROM JOB_ORDER JO
                                               WHERE JO.ID_CREATE = :TRACE_NO
                                                 AND JO.KIND_CD = 7
                                             )
                      )
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
