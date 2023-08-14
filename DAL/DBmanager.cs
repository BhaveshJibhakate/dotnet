using BOL;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBmanager
    {
        public static string connString = @"server=localhost;port=3306;user=root; password=root123;database=dotnet";

        public static List<Employee> getAllEmployees(){ 
        
         List<Employee> empList = new List<Employee>();
         
         MySqlConnection conn = new MySqlConnection();

            conn.ConnectionString = connString;

            try { 
                conn.Open(); 

                MySqlCommand cmd = new MySqlCommand(); 

                cmd.Connection = conn;

                string query = "SELECT * FROM emp";

                cmd.CommandText = query;

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                   
                    int id = int.Parse(reader["id"].ToString());
                    string firstname = reader["firstname"].ToString();
                    string lastname = reader["lastname"].ToString();
                    Department department = Enum.Parse<Department>(reader["department"].ToString().ToUpper());
                    // DateOnly joiningdate = DateOnly.FromDateTime(DateTime.Parse(reader["joiningdate"].ToString()));  
                    DateOnly joindate =DateOnly.FromDateTime(DateTime.Parse( reader["joindate"].ToString()));  
                    Employee newEmp = new Employee(id,firstname,lastname,department,joindate);
                    empList.Add(newEmp);

                }

            } catch (Exception e){
                Console.WriteLine(e.Message);
            }  finally {
                conn.Close(); 
            }

            return empList;

            }// end of getAllEmployee Method


        public static void insertEmployee(Employee newEmp) {
        
          
            MySqlConnection conn = new MySqlConnection();

            conn.ConnectionString = connString;

            try { 
                            
                conn.Open ();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                string query = "insert into emp  values('" + newEmp.ID + "','" + newEmp.FIRSTNAME + "','"+newEmp.LASTNAME+"','"+newEmp.DEPARTMENT+"','"+newEmp.JOINDATE.ToString("yyyy-MM-dd")+"')";
                cmd.CommandText = query;

                cmd.ExecuteNonQuery();

                 
            }catch (Exception e) { 
            
            Console.WriteLine(e.Message);
            }finally { conn.Close(); }


        }// end of insert employee

        public static void deleteEmployee(int id)
        {

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;


            try { 
                conn.Open ();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                string query = "delete from emp where id = " + id;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            
            }catch (Exception e) { 
                Console.WriteLine();
            }finally { conn.Close(); }


        }// end of delete employee



        }
}