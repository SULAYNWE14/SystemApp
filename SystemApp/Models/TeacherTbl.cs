using System;
using System.Collections.Generic;
namespace SystemApp.Models
{
    public partial class TeacherTbl
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
