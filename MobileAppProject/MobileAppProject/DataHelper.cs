using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Internals;

namespace MobileAppProject
{
    public class DataHelper
    {
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public bool createDB()
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.CreateTable<DBCourse>();
                    con.CreateTable<DBTerm>();
                    con.CreateTable<DBAssesment>();
                    return true;
                }
            }
            catch(SQLiteException sqlex)
            {
                return false;
            }
        }

        public void createData()
        {
            using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
            {

                DBTerm TermInsert = new DBTerm();
                DBCourse CourseInsert = new DBCourse();
                DBAssesment AssesmentInsert1 = new DBAssesment();
                DBAssesment AssesmentInsert2 = new DBAssesment();

                var termCheck = con.Table<DBTerm>().Where(x => x.title == "Test Term").ToList();

                if(termCheck.Count == 0)
                {
                    TermInsert.title = "Test Term";
                    TermInsert.start = DateTime.Today.AddDays(7);
                    TermInsert.end = DateTime.Today.AddDays(14);
                    InsertIntoTerm(TermInsert);

                    var relatedTermCheck = con.Table<DBTerm>().Where(x => x.title == "Test Term").ToList();

                    if(relatedTermCheck.Count == 1)
                    {
                        CourseInsert.coursetitle = "Test Course";
                        CourseInsert.coursestartdate = DateTime.Today.AddDays(7);
                        CourseInsert.courseenddate = DateTime.Today.AddDays(14);
                        CourseInsert.instructorname = "Austin Rukes";
                        CourseInsert.instructoremail = "arukes@wgu.edu";
                        CourseInsert.instructorphonenumber = "765-592-2466";
                        CourseInsert.termid = relatedTermCheck[0].termid;
                        CourseInsert.status = "Active";
                        InsertIntoCourse(CourseInsert);

                        var relatedCourseCheck = con.Table<DBCourse>().Where(x => x.coursetitle == "Test Course").ToList();

                        if (relatedCourseCheck.Count > 0)
                        {
                            AssesmentInsert1.assesmentname = "Test Course 1";
                            AssesmentInsert1.type = "OA";
                            AssesmentInsert1.assesmentdate = DateTime.Today.AddDays(14);
                            AssesmentInsert1.courseid = relatedCourseCheck[0].courseid;
                            AssesmentInsert2.assesmentname = "Test Course 2";
                            AssesmentInsert2.type = "PA";
                            AssesmentInsert2.assesmentdate = DateTime.Today.AddDays(14);
                            AssesmentInsert2.courseid = relatedCourseCheck[0].courseid;
                            InsertIntoAssesment(AssesmentInsert1);
                            InsertIntoAssesment(AssesmentInsert2);
                        }
                    }
                }
            }
        }


        public bool InsertIntoCourse(DBCourse course)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Insert(course);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public bool InsertIntoTerm(DBTerm term)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Insert(term);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public bool InsertIntoAssesment(DBAssesment assesment)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Insert(assesment);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public bool DeleteCourse(DBCourse course)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Delete(course);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public bool DeleteTerm(DBTerm term)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Delete(term);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public bool DeleteAssesment(DBAssesment assesment)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Delete(assesment);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public List<DBCourse> SelectCourses(int tid)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    return con.Table<DBCourse>().Where(x => x.termid == tid).ToList();
                }
            }
            catch (SQLiteException sqlex)
            {
                return null;
            }
        }

        public List<DBAssesment> SelectAssesments(int cid)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    return con.Table<DBAssesment>().Where(x => x.courseid == cid).ToList();
                }
            }
            catch (SQLiteException sqlex)
            {
                return null;
            }
        }

        public List<DBTerm> SelectTerms()
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    return con.Table<DBTerm>().ToList();
                }
            }
            catch (SQLiteException sqlex)
            {
                return null;
            }
        }

        public bool UpdateCourse(DBCourse course)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Update(course);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public bool UpdateTerm(DBTerm term)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Update(term);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }

        public bool UpdateAssesment(DBAssesment assesment)
        {
            try
            {
                using (var con = new SQLiteConnection(System.IO.Path.Combine(folder, "App.db")))
                {
                    con.Update(assesment);
                    return true;
                }
            }
            catch (SQLiteException sqlex)
            {
                return false;
            }
        }
    }
}
