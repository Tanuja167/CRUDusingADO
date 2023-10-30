using System.Data.SqlClient;

namespace CRUDusingADO.Models
{
    public class CourseDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public CourseDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }


        public List<Course> GetCourse()
        {
            List<Course> courses = new List<Course>();
            string qry = "select * from Course";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Course course = new Course();
                    course.Id = Convert.ToInt32(dr["cid"]);
                    course.Name = dr["cname"].ToString();
                    course.Duration = Convert.ToInt32(dr["duration"]);
                    course.Fees = Convert.ToInt32(dr["fees"]);


                    courses.Add(course);
                }
            }
            con.Close();
            return courses;
        }
        public Course GetCourseById(int id)
        {
            Course course = new Course();
            string qry = "select * from Course where cid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                     course.Id = Convert.ToInt32(dr["cid"]);
                     course.Name = dr["cname"].ToString();
                     course.Duration = Convert.ToInt32(dr["duration"]);
                     course.Fees = Convert.ToInt32(dr["fees"]);
                }
            }
            con.Close();
            return course;
        }
        public int AddCourse(Course course)
        {
            int result = 0;
            string qry = "insert into Course values(@name, @duration, @fees)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", course.Name);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            cmd.Parameters.AddWithValue("@fees", course.Fees );
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateCourse(Course course)
        {
            int result = 0;
            string qry = "update Course set cname=@name, duration=@duration, fees=@fees where cid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", course.Name);
            cmd.Parameters.AddWithValue("@duration", course.Duration);
            cmd.Parameters.AddWithValue("@fees", course.Fees);
            cmd.Parameters.AddWithValue("@id", course.Id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteCourse(int id)
        {
            int result = 0;
            string qry = "delete from Course where cid=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
