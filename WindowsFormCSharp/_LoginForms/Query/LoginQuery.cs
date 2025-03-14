using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public void Commit()
        {
            _context.SaveChanges();
        }

        public List<dynamic> selectMemberInfo(string MEMBER_ID, string PASSWORD)
        {
            string sql = $"""
            /* LoginQuery.selectMemberInfo */
            SELECT COUNT(NO_MEMBER_SEQ),
                   NO_MEMBER_SEQ,
                   NO_COMPANY_SEQ
              FROM TB_MEMBER
             WHERE MEMBER_ID = {MEMBER_ID}
               AND PASSWORD = {PASSWORD}
             GROUP BY NO_MEMBER_SEQ,
                   NO_COMPANY_SEQ
            """;

            // TODO SelectRawSql 메서드를 실행하기 전에 sql에 /**p**/를 추가하는 코드를 넣은 후, 작동시킬건데
            // 이거는 계속 메서드를 실행시킬 수는 없는 노릇이니 전역으로 처리할 수 있는 방법을 찾아보자

            return _context.SelectRawSql(sql);
        }
    }
}
public class MemberInfo
{
    public int Count { get; set; }
    public int MemberSeq { get; set; }
    public int CompanySeq { get; set; }
}