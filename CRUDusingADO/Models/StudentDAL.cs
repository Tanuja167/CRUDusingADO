using System.Data.SqlClient;

namespace CRUDusingADO.Models
{
    public class StudentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public StudentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string qry = "select * from Student";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(dr["id"]);
                    student.Name = dr["sname"].ToString();
                    student.Percentage =Convert.ToInt32( dr["spercentage"]);
                    student.City = dr["city"].ToString();


                    students.Add(student);
                }
            }
            con.Close();
            return students;
        }
        public Student GetStudentById(int id)
        {
            Student student = new Student();
            string qry = "select * from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.Id = Convert.ToInt32(dr["id"]);
                    student.Name = dr["sname"].ToString();
                    student.Percentage = Convert.ToInt32(dr["spercentage"]);
                    student.City = dr["city"].ToString();


                }
            }
            con.Close();
            return student;
        }
        public int AddStudent(Student student)
        {
            int result = 0;
            string qry = "insert into Student values(@name,@percentage,@city)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@city", student.City);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateStudent(Student student)
        {
            int result = 0;
            string qry = "update Student set sname=@name,spercentage=@percentage,city=@city where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@percentage", student.Percentage);
            cmd.Parameters.AddWithValue("@city", student.City);
            cmd.Parameters.AddWithValue("@id", student.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteStudent(int id)
        {
            int result = 0;
            string qry = "delete from Student where id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }

    }
}

