using System;
using System.Collections.Generic;
namespace SystemApp.Models
{
    public partial class StudentTbl
    {
        public int Id { get; set; }

        public string? StudentName { get; set; }

        public string? Emailaddress { get; set; }

        public string? Remark { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
