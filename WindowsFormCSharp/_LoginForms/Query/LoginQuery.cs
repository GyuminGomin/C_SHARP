using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Oracle.ManagedDataAccess.Client;
using WindowsFormCSharp.Config;

namespace WindowsFormCSharp._LoginForms.Query
{

    public class LoginQuery
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
        public List<Dictionary<string, object>> SelectMemberInfo(Dictionary<string, object> memberInfo)
        {
            try
            {
                string sql = """
                /* LoginQuery.SelectMemberInfo */
                SELECT COUNT(NO_MEMBER_SEQ) COUNT,
                       NO_MEMBER_SEQ,
                       NO_COMPANY_SEQ
                  FROM TB_MEMBER
                 WHERE MEMBER_ID = :MEMBER_ID
                   AND PASSWORD = :PASSWORD
                 GROUP BY NO_MEMBER_SEQ,
                       NO_COMPANY_SEQ
                """;

                return _context.SelectRawSql(sql, memberInfo);
            } catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetIp(Dictionary<string, object> memberInfo)
        {
            try
            {
                string sql = """
                /* LoginQuery.GetIp */
                SELECT SYS_CONTEXT('userenv','ip_address') GS_USERIP
                  FROM DUAL
                """;

                return _context.SelectRawSql(sql, memberInfo);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Dictionary<string, object>> GetMemberInfo(Dictionary<string, object> memberInfo)
        {
            try
            {
                string sql = """
                /* LoginQuery.GetMemberInfo */
                SELECT NO_WORKS,
                       WORKS_NAME
                  FROM TB_WORKS
                 WHERE NO_WORKS = '178195'
                """;

                return _context.SelectRawSql(sql, memberInfo);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}