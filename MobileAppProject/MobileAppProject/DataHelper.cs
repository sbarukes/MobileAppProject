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
