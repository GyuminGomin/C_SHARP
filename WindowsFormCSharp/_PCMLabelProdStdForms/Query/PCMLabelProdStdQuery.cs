using Microsoft.EntityFrameworkCore.Storage;
using WindowsFormCSharp.Config;
using WindowsFormCSharp;
using System.Data;

namespace WindowsFormCSharp._PCMLabelProdStdForms
{
    class PCMLabelProdStdQuery : Query
    {
        private readonly ODBC _context;
        public PCMLabelProdStdQuery()
        {
            _context = ODBC.GetInstance();
        }
        public void ExecuteWithTransaction(Action<IDbTransaction> action)
        {
            _context.ExecuteWithTransaction(action);
        }

        public List<Dictionary<string, object>> FindProductQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelProdStdQuery.FindProductQry */
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

        public List<Dictionary<string, object>> FindProduct2Qry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelProdStdQuery.FindProduct2Qry */
                SELECT ROWNUM,
                       BOX_NO,
                       PROD_DATE,
                       ITEM_CD,
                       (
                        SELECT ITEM_NAME
                          FROM TB_ITEM T
                         WHERE T.ITEM_CD = PROD_CAT.ITEM_CD
                       ) ITEM_NAME,
                       PACK_NO,
                       BOX_FLAG,
                       BOX_QTY,
                       BOX_WT,
                       NO_WORKS,
                       ID_CREATE,
                       DT_CREATE,
                       IP_CREATE,
                       ID_MODIFY,
                       DT_MODIFY,
                       IP_MODIFY,
                       CHANG_NO,
                       TRACE_NO,
                       FRZ_DIV,
                       GRADE,
                       OUT_FLAG,
                       0 CHECK_CNT
                  FROM PROD_CAT
                 WHERE PROD_DATE = :TEMP_DATE
                   AND ITEM_CD = :ITEM_CD
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int SaveProduct2Qry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelProdStdQuery.SaveProduct2Qry */
                UPDATE PROD_CAT
                   SET ID_MODIFY = :ID_MODIFY, -- 가져올 수 없다. (나중에 로그인 로직 최종적으로 완성되면 가능)
                       DT_MODIFY = :DT_MODIFY,
                       IP_MODIFY = :IP_MODIFY,
                       TRACE_NO = :TRACE_NO,
                       FRZ_DIV = :FRZ_DIV,
                       GRADE = :GRADE,
                       OUT_FLAG = :OUT_FLAG
                 WHERE BOX_NO = :BOX_NO
                """;

                return _context.ExecuteRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public List<Dictionary<string, object>> FindProduct3Qry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelProdStdQuery.FindProduct3Qry */
                SELECT 1 CHK,
                       MAX(D.COMPANY_NAME)||' '||MAX(A.TRANS_MAN) COMPANY_NAME,
                       MAX(C.ITEM_NAME) ITEM_NAME,
                       MAX(B.ORDER_QTY) ORDER_QTY,
                       TO_CHAR(D.NO_COMPANY_SEQ) JUMPO_CODE,
                       TO_CHAR(A.ORDER_NO) BUNRYU_CODE,
                       MAX(A.ORDER_NO) ORDER_NO,
                       B.GRADE
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
                   AND D.COMPANY_NAME NOT LIKE '(주)이마트에브리데이%'
                   AND A.COUPANG_NO IS NULL
                 GROUP BY B.ITEM_CD, B.GRADE, D.NO_COMPANY_SEQ, A.ORDER_NO
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
                /* PCMLabelProdStdQuery.GetSubItemCdKindQry */
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

        public List<Dictionary<string, object>> GetItemCdKindQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelProdStdQuery.GetItemCdKindQry */
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

        public List<Dictionary<string, object>> GetTraceInfoQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelProdStdQuery.GetTraceInfoQry */
                SELECT A.ID_CREATE TRACE_NO,
                       DECODE(INSTR(B.ITEM_NAME, '1+', 1), 0, 3, 2) GRADE
                  FROM JOB_DETAIL A, TB_ITEM B
                 WHERE A.JOB_DATE = :TEMP_DATE
                   AND A.KIND_CD = 7
                   AND A.ITEM_CD = :ITEM_CD
                   AND A.ITEM_CD = B.ITEM_CD
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetTraceNoIsExistQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* PCMLabelQuery.GetTraceNoIsExistQry */
                SELECT NVL(A.TRACE_NO, A.ID_CREATE) TRACE_NO
                  FROM JOB_DETAIL A, TB_ITEM B
                 WHERE A.JOB_DATE = :TEMP_DATE
                   AND A.KIND_CD = 7
                   AND A.ITEM_CD = B.ITEM_CD
                   AND SUBSTR(NVL(A.TRACE_NO, A.ID_CREATE), 0, 2) = :GBN
                 GROUP BY NVL(A.TRACE_NO, A.ID_CREATE)
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
                       NVL(A.WORK_FRZ2, 0) WORK_FRZ2,
                       NVL(A.TRACE_NO, A.ID_CREATE) TRACE_NO
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
                SELECT NVL(SUM(B.ORDER_QTY),0) ORDER_QTY
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
                SELECT NVL(SUM(B.ORDER_QTY), 0) ORDER_QTY
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
                SELECT ENG_NAME                         YONGDO, 
                       BASE_WT_COOL                     SALE_WT,
                       TRIM(BARCODE)                    BARCODE,
                       REPLACE(NVL(BOGO_NO1,''),'-','') SUB_BUI,
                       NVL(BOGO_NO2,'')                 CHANGE_BUI,
                       NVL(CIRCUL_DATE, 0)              CIRCUL_DATE,
                       ITEM_NAME                        ITEM_NAME,
                       FNC_ITEM_NAME(ITEM_MAIN)         ITEM_MAIN
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
                SELECT SUBSTR(XMLAGG(XMLELEMENT(x,',',TEXT) ORDER BY ORDB).EXTRACT('//text()').GETSTRINGVAL(), 2) KILL_AREA
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
