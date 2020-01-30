using Demo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Demo
{
    /// <summary>
    /// Summary description for DALService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
   
    public class DALService : System.Web.Services.WebService
    {
        
        List<Course> courses = new List<Course>();
        List<StudentCourse> studentcourse = new List<StudentCourse>();

        [WebMethod]
        public void GetCourses()
        {





           




            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString()))
            {
                con.Open();
                string qry = "select CourseName,StudentId from Course";
                using (SqlCommand cmd = new SqlCommand(qry, con))
                {

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Course course = new Course();


                            course.CourseName = sdr.GetString(0);
                            course.StudentID = Convert.ToInt32(sdr.GetValue(1));
                            courses.Add(course);
                        }
                        sdr.Close();
                    }
                }
                
                foreach (var c in courses)
                {
                    string qry2 = "select StudentName from Student where StudentId='" + c.StudentID + "'";
                    using (SqlCommand cmd2 = new SqlCommand(qry2, con))
                    {

                        using (SqlDataReader rdr = cmd2.ExecuteReader())
                        {
                            while (rdr.Read())
                            {

                                Dictionary<String, String> dict = new Dictionary<String, String>();
                                StudentCourse sc = new StudentCourse();
                                sc.CourseName = rdr.GetValue(0).ToString();
                                sc.StudentName = c.CourseName;

                                

                                studentcourse.Add(sc);



                            }
                        }
                    }
                }

            

           
          
                }

               


            
                
            
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(studentcourse));

        }
    }
   
}
