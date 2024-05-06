using Microsoft.Data.SqlClient;

namespace WebApiADO.Model
{
    public class CollegeRep:ICollegeRep
    {
        private string ConnectionString {  get; set; }

        public CollegeRep(IConfiguration configuration)
        {
            ConnectionString = "server=SALEEJK;database=master;Integrated Security=true;TrustServerCertificate=true";
        }
        public List<College> GetColleges()
        {
            using (SqlConnection con =new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from studentC", con);
               
                SqlDataReader sdr=sqlCommand.ExecuteReader();
                List<College>colleges=new List<College>();
                while (sdr.Read())
                {
                    College college= new College();
                    college.Id = Convert.ToInt32(sdr["id"]);
                    college.Name = sdr["Name"].ToString();
                    college.Place = sdr["Place"].ToString();
                    colleges.Add(college);
                }
                return colleges;
            }
        }
        public List<College>GetCollegeById(int id)
        {
            using (SqlConnection con=new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand($"select * from studentC where id ={id}", con);
                con.Open();
                SqlDataReader sdr=sqlCommand.ExecuteReader();
                List<College> colleges=new List<College>();
                while(sdr.Read())
                {
                    College college=new College();
                    college.Id = Convert.ToInt32(sdr["id"]);
                    college.Name = sdr["Name"].ToString();
                    college.Place = sdr["Place"].ToString();
                    colleges.Add(college);

                }
                return colleges;
            }
        }
        public void AddCollege(College college)
        {
            using (SqlConnection con=new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("insert into studentC (id,name,place) values(@id,@name,@place)", con);
                sqlCommand.Parameters.AddWithValue("@id", college.Id);
                sqlCommand.Parameters.AddWithValue("@name", college.Name);
                sqlCommand.Parameters.AddWithValue("@place", college.Place);
                con.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void UpdateCollege(int id,College college)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommmand=new SqlCommand("update studentC set Name = @name,place = @place where id = @id", con);
                sqlCommmand.Parameters.AddWithValue("@name", college.Name);
                sqlCommmand.Parameters.AddWithValue("@place", college.Place);
                sqlCommmand.Parameters.AddWithValue("@id", id);
                con.Open();
                sqlCommmand.ExecuteNonQuery();
            }
        }
        public void DeleteCollege(int id)
        {
            using(SqlConnection con=new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from studentC where id = @id", con);
                command.Parameters.AddWithValue("@id", id);
                con.Open() ;
                command.ExecuteNonQuery();
            }
        }
    }
}
