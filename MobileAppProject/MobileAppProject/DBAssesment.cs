using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppProject
{
    [Table("Assesments")]
    public class DBAssesment
    {
        public int assesmentid { get; set; }
        //Assesment Info
        public string type { get; set; }
        public string assesmentname { get; set; }
        public string notes { get; set; }
        public DateTime assesmentdate { get; set; }

        //DBAssesment Reference
        [ForeignKey(typeof(DBCourse))]
        public int courseid { get; set; }
    }
}
