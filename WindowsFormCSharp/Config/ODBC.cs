using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Microsoft.EntityFrameworkCore;

namespace WindowsFormCSharp.Config
{
    public class ODBC : DbContext
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
        private static ODBC _instance;
        /*
         * DbContextOptions -> EF Core에서 데이터베이스 연결 설정을 포함하는 클래스
         * DbContextOptions<ODBC> -> ODBC라는 특정 DbContext에 대한 설정을 나타냄
         * -> 예를 들어, 어떤 DB를 사용할지, 연결 문자열은 무엇인지, 트랜잭션 설정은 무엇인지 다양한 옵션을 설정할 수 있음
         * base(options) -> 부모 클래스의 생성자를 호출하는 구문
         * 따라서 ODBC 클래스가 DbContext를 상속받으면서, DbContextOptions<ODBC>를 부모 클래스인 DbContext에 전달하여 ODBC 객체가 설정되도록 하는 역할
         */
        public ODBC(DbContextOptions<ODBC> options) : base(options) { }

        public static ODBC GetInstance()
        {
            if (_instance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ODBC>();
                _instance = new ODBC(optionsBuilder.Options);
            }
            return _instance;
        }

        /*
         * optionsBuilder.IsConfigured -> 현재 DbContext가 구성되었는지 여부를 나타내는 속성
         * ODBC 설정 connectionString에서 받은 정보를 통해 연결 설정
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle(connectionString);
            }
        }

        /*
         * this.Database.GetDbConnection().CreateCommand() -> 현재 DbContext의 연결을 가져와서 Command 객체를 생성
         * command.CommandText = sql; -> Command 객체의 CommandText 속성에 SQL 쿼리를 설정
         * this.Database.OpenConnection(); -> 현재 DbContext의 연결을 열기
         * 
         * command.ExecuteReader() -> Command 객체를 실행하여 DbDataReader 결과를 받아오는 메서드
         * 전체적으로 한번씩 결과를 읽어서 결과값이 있는지 확인한후, 컬럼과 값을 읽어서 ExpandoObject에 추가
         * 그 후, ExpandoObject를 List에 추가하여 반환
         */
        /*
         * Select 쿼리를 실행하는 메서드
         */
        public List<dynamic> SelectRawSql(string sql)
        {
            try
            {
                using (var command = this.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = sql;
                    this.Database.OpenConnection();

                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<dynamic>();
                        while (result.Read())
                        {
                            var expandoObject = new System.Dynamic.ExpandoObject() as IDictionary<string, object>;
                            for (var i = 0; i < result.FieldCount; i++)
                            {
                                expandoObject.Add(result.GetName(i), result.IsDBNull(i) ? null : result.GetValue(i));
                            }
                            entities.Add(expandoObject);
                        }
                        return entities;
                    }
                }
                
            } catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return null;
            }
            
        }

        /*
         * Insert, Update, Delete 쿼리를 실행하는 메서드
         */
        public int ExecuteRawSql(string sql)
        {
            try
            {
                return this.Database.ExecuteSqlRaw(sql);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                return -1;
            }
        }

        private string ReplaceParametersWithPlaceholder(string sql)
        {
            return System.Text.RegularExpressions.Regex.Replace(sql, @"\{.*?\}", m => m.Groups[1].Value + " /**p**/");
        }
    }
}
