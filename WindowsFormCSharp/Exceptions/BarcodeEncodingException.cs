using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormCSharp.Exceptions
{
    class BarcodeEncodingException : Exception
    {
        public BarcodeEncodingException() { }

        public BarcodeEncodingException(string message) : base(message)
        {
            MessageBox.Show(message, "확인");
        }

        public BarcodeEncodingException(string message, Exception inner) : base(message, inner) { }
    }
}
