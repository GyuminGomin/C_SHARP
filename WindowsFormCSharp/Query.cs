using System.Data;
using WindowsFormCSharp.Config;

namespace WindowsFormCSharp
{
    class Query
    {
        protected readonly ODBC _context;

        public Query()
        {
            _context = ODBC.GetInstance();
        }

        public static DataTable fn_createDataTable<T>(T qry, Func<T, List<Dictionary<string, object>>> callback) where T : Query
        {
            DataTable dt = new DataTable();

            var result = callback(qry);

            // Column 추가
            foreach (Dictionary<string, object> row in result)
            {
                // 데이터 테이블에 컬럼 추가
                if (dt.Columns.Count == 0)
                {
                    row.Keys.ToList().ForEach(key =>
                    {
                        if (!dt.Columns.Contains(key))
                        {
                            dt.Columns.Add(key);
                        }
                    });
                }
                // 데이터 테이블에 행 추가
                DataRow dr = dt.NewRow();
                foreach (var key in row.Keys)
                {
                    dr[key] = row[key];
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
