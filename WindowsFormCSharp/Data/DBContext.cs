using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WindowsFormCSharp.DTO;

namespace WindowsFormCSharp.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
            // 결과를 받을 DTO 클래스 등록
            public DbSet<MemberDTO> MemberDTO { get; set; }
    }
}
