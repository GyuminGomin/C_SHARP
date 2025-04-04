﻿using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;
using System.Transactions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WindowsFormCSharp.Config
{
    public class ODBC : DbContext
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
        private static ODBC _instance;
        private DbConnection _connection;

        private bool _tranasaction; // true - 트랜잭션 성공, false - 트랜잭션 실패

        /*
         * 중요!!!!
         * 현재 프로젝트 SQL 연결 상태는
         * 1. EF에서 OnConfiguring으로 DB Connector 설정
         * 2. EF의 Database.GetDbConnection()으로 DbConnection 객체 생성
         * 3. DB Context에서 DB Instacne 생성
         * 4. Instacne로 CRUD Query 실행 설정 (Dapper의 Select와 Execute 실행)
         */

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

        // DbConnection을 클래스 수준에서 관리하고, 필요할 때 열고 닫는 형식으로 사용
        public ODBC(DbContextOptions<ODBC> options) : base(options) 
        {
            _connection = this.Database.GetDbConnection();
        }

        /*
         * DbContextOptions -> EF Core에서 데이터베이스 연결 설정을 포함하는 클래스
         * DbContextOptions<ODBC> -> ODBC라는 특정 DbContext에 대한 설정을 나타냄
         * -> 예를 들어, 어떤 DB를 사용할지, 연결 문자열은 무엇인지, 트랜잭션 설정은 무엇인지 다양한 옵션을 설정할 수 있음
         * base(options) -> 부모 클래스의 생성자를 호출하는 구문
         * 따라서 ODBC 클래스가 DbContext를 상속받으면서, DbContextOptions<ODBC>를 부모 클래스인 DbContext에 전달하여 ODBC 객체가 설정되도록 하는 역할
         */
        public static ODBC GetInstance()
        {
            if (_instance == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ODBC>();
                _instance = new ODBC(optionsBuilder.Options);
            }
            return _instance;
        }

        public void ExecuteWithTransaction(Action<IDbTransaction> action)
        {
            using (var transaction = _connection.BeginTransaction()) // 트랜잭션 시작
            {
                try
                {
                    // 트랜잭션을 포함한 작업 시작
                    action(transaction);
                    // 모든 작업이 성공적으로 끝나면 커밋
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // 예외가 발생하면 롤백
                    transaction.Rollback();
                    throw;
                }
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
         * params : 메서드에 전달되는 인수의 개수가 가변적일 때 사용
         * ? : nullable 형식을 나타내는 연산자 (null이 가능)
         * dynamic : 동적 타입 (컴파일 시점에 타입이 결정되지 않고, 런타임 시점에 결정되는 타입) -> object와 비슷하지만, object보다 더 유연하게 사용 가능
         *      -> 현재 시점에서 List<dynamic>은 List<Dictionary<string, object>>와 같은 역할을 함
         */
        /*
         * Select 쿼리를 실행하는 메서드 (기본적으로 클래스를 매핑해서 사용해야 하므로 새롭게 추가)
         */
        public List<Dictionary<string, object>> SelectRawSql(string sql, Dictionary<string, object>? parameters, IDbTransaction? transaction)
        {
            try
            {
                // Dapper를 사용하여 Raw SQL 실행
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                IEnumerable<dynamic> result = null;
                if (parameters == null)
                {
                    result = _connection.Query(sql).ToList();
                } else
                {
                    result = _connection.Query(sql, parameters).ToList();
                }

                // 결과를 Dictionary 형태로 변환
                /*
                * Dapper가 반환하는 IEnumerable<dynamic>을 List<Dictionary<string, object>>로 변환
                */
                var results = result.Select(row => (IDictionary<string, object>)row)
                                    .Select(row => row.ToDictionary(k => k.Key, v => v.Value))
                                    .ToList();
                return results;
            } catch (Exception e)
            {
                throw;
            }
            finally
            {
                // 현재 실행되는 폼 정보를 콘솔에 출력
                string modifiedSql = null;
                if (parameters != null)
                {
                    modifiedSql = replaceParameterMarker(sql, parameters);
                } else
                {
                    modifiedSql = sql;
                }
                Console.WriteLine(modifiedSql+"\n");
            }
        }

        /*
         * Insert, Update, Delete 쿼리를 실행하는 메서드
         */
        public int ExecuteRawSql(string sql, Dictionary<string, object>? parameters, IDbTransaction transaction)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                var result = _connection.Execute(sql, parameters, transaction);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                string modifiedSql = replaceParameterMarker(sql, parameters);
                Console.WriteLine(modifiedSql);
            }
        }

        // : 뒤에 /**p**/를 추가한 쿼리를 출력
        private string replaceParameterMarker(string sql, Dictionary<string, object> parameters)
        {
            // : 뒤에 /**p**/를 추가한 쿼리를 출력
            string modifiedSql = Regex.Replace(sql, @":\w+", m => m.Value + " /**p**/");

            foreach (var param in parameters)
            {
                modifiedSql = modifiedSql.Replace($":" + param.Key, '\''+param.Value?.ToString()+'\'');
            }

            return modifiedSql;
        }
    }
}
