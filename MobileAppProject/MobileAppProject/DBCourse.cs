using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppProject
{
    [Table("Courses")]
    public class DBCourse
    {
        [PrimaryKey, AutoIncrement]
        public int courseid { get; set; }

        [ForeignKey(typeof(DBTerm))]
        public int termid { get; set; }
    }
}
