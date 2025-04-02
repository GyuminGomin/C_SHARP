using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using WindowsFormCSharp;
using WindowsFormCSharp.Config;

namespace WindowsFormCSharp._PCMLabelProdStdForms
{
    class PCMLabelProdStdQuery_P1 : Query
    {
        private readonly ODBC _context;
        public PCMLabelProdStdQuery_P1()
        {
            _context = ODBC.GetInstance();
        }
        public void ExecuteWithTransaction(Action<IDbTransaction> action)
        {
            _context.ExecuteWithTransaction(action);
        }


    }
}
