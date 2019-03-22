using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLitePCL;
using SQLiteNetExtensions.Attributes;

namespace MobileAppProject
{

    [Table("Terms")]
    public class DBTerm
    {
        [PrimaryKey, AutoIncrement]
        public int termid { get; set; }

        public string title { get; set; }

        public DateTime start { get; set; }
        public DateTime end { get; set; }


        [OneToMany]
        public List<DBCourse> Courses { get; set; }
    }
}
