using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using WindowsFormCSharp.Config;

namespace WindowsFormCSharp._LoginForms
{

    class LoginQuery : Query
    {
        private readonly ODBC _context;

        public LoginQuery()
        {
            _context = ODBC.GetInstance();
        }

        /*
         * 트랜잭션 처리를 위해 반드시 필요
         */
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        public List<Dictionary<string, object>> SelectMemberInfoQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* LoginQuery.SelectMemberInfoQry */
                SELECT COUNT(NO_MEMBER_SEQ) COUNT,
                       NO_MEMBER_SEQ,
                       NO_COMPANY_SEQ
                  FROM TB_MEMBER
                 WHERE MEMBER_ID = :MEMBER_ID
                   AND PASSWORD = :PASSWORD
                 GROUP BY NO_MEMBER_SEQ,
                       NO_COMPANY_SEQ
                """;

                return _context.SelectRawSql(sql, input, transaction);
            } catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetIpQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* LoginQuery.GetIpQry */
                SELECT SYS_CONTEXT('userenv','ip_address') GS_USERIP
                  FROM DUAL
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetWorksInfoQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* LoginQuery.GetWorksInfoQry */
                SELECT NO_WORKS,
                       WORKS_NAME
                  FROM TB_WORKS
                 WHERE NO_WORKS = '178195'
                """;

                return _context.SelectRawSql(sql, input, transaction);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetSysDateQry(Dictionary<string, object>? input, IDbTransaction? transaction)
        {
            try
            {
                string sql = """
                /* LoginQuery.GetSysDateQry */
                SELECT TO_CHAR(SYSDATE, 'YYYYMMDD') GS_SYS_DATE
                  FROM DUAL
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