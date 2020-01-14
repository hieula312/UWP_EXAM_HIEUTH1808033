using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using UWP_RETEST.Models;

namespace UWP_RETEST.Services
{
    class SQLiteService
    {
        private static string DatabaseName = "Exam.db";
        public String query;

        //public SQLiteConnection conn { get; set; }

//        public SQLiteService()
//        {
//            conn = new SQLiteConnection(DatabaseName);
//            CreateDatabase();
//        }

        public void CreateDatabase()
        {
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            query =
                @"Create table if not exists Students (RollNumber Integer PRIMARY KEY AUTOINCREMENT, Name varchar(200), Status Integer DEFAULT 1)";
            using (var stt = conn.Prepare(query))
            {
                stt.Step();
            }
        }

        public bool CreateNewStudent(Student student)
        {
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            query = @"Insert Into Students(Name) values (?)";
            using (var stt = conn.Prepare(query))
            {
                stt.Bind(1, student.Name);
                var result = stt.Step();
                return result == SQLiteResult.DONE;
            }
        }

        public ObservableCollection<Student> GetStudentByStatus(int status)
        {
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            ObservableCollection<Student> list = new ObservableCollection<Student>();
            query = @"Select * FROM Students Where Status = ?";
            using (var stt = conn.Prepare(query))
            {
                while (SQLiteResult.ROW == stt.Step())
                {
                    var _rollNumber = Convert.ToInt32(stt["RollNumber"]);
                    var _name = (string) stt["Name"];
                    var _status = Convert.ToInt32(stt["Status"]);
                    var stu = new Student()
                    {
                        RollNumber = _rollNumber,
                        Name = _name,
                        Status = _status,
                    };
                    list.Add(stu);
                }
            }

            return list;
        }

        public void Delete(String name)
        {
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            query = @"Select * FROM Students WHERE Name = ?";
            using (var stt = conn.Prepare(query))
            {
                stt.Bind(1, $"{name}");
                if (SQLiteResult.ROW == stt.Step())
                {
                    var _rollNumber = Convert.ToInt32(stt["RollNumber"]);
                    Update(_rollNumber);
                }
            }
        }

        public void Update(int rollNumber)
        {
            SQLiteConnection conn = new SQLiteConnection(DatabaseName);
            query = @"Update Students Set Status = 0 where RollNumber = ?)";
            var stt = conn.Prepare(query);
            stt.Step();
        }

    }
}
