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

        public string coursetitle { get; set; }
        public string status { get; set; }
        public DateTime coursestartdate { get; set; }
        public DateTime courseenddate { get; set; }

        //instructor info
        public string instructorname { get; set; }
        public string instructorphonenumber { get; set; }
        public string instructoremail { get; set; }

        //Assesment Info
        public string paassesmentname { get; set; }
        public string panotes { get; set; }
        public DateTime paassesmentdate { get; set; }
        public string oaassesmentname { get; set; }
        public string oanotes { get; set; }
        public DateTime oaassesmentdate { get; set; }

        //DBTerm Reference
        [ForeignKey(typeof(DBTerm))]
        public int termid { get; set; }
    }
}
