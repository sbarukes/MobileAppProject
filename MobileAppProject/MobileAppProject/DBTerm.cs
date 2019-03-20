using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppProject
{

    [Table("Terms")]
    public class DBTerm
    {
        [PrimaryKey, AutoIncrement, Column("termid")]
        public int termid { get; set; }
        public string title { get; set; }
        public int courseid { get; set; }
    }
}
