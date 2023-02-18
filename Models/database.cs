using MySql.Data.MySqlClient;
using System.IO;

namespace Недвижимость.Models
{
    public class database
    {

        public User getUser(string email,string password)
        {

             string path = "datasource=localhost;port=3306;database=nedvijemost;username=root;password=toor";
        string Request = "SELECT id, name, surname, numberphone, email, password FROM nedvijemost.users WHERE email='" + email + "' AND password='"+ password + "';";
            MySqlConnection connection = new MySqlConnection(path);
            connection.Open();
            MySqlCommand command = new MySqlCommand(Request, connection);
            MySqlDataReader reader = command.ExecuteReader();
            User user = null;
            while (reader.Read())
            {
               user= new User();
                user.Id = Convert.ToInt32(reader[0]);
                user.Name = reader[1].ToString();
                user.Email = reader[4].ToString();
                user.Surname = reader[2].ToString();
                user.Number_phone = reader[3].ToString();
                user.Password = reader[5].ToString();
            }
            reader.Close();
            return user;
        }
        public bool AddNewUser(string Name, string Surname, string Number_phone, string Email, string Password)
        {
            string path = "server=localhost;user=root;database=nedvijemost;password=toor;";
            try
            {

                MySqlConnection connection = new MySqlConnection(path);
                connection.Open();
                string sql_zapros = "INSERT INTO `nedvijemost`.`users` (`name`, `surname`, `numberphone`, `email`, `password`) VALUES ('" + Name + "', '" + Surname + "', '" + Number_phone + "', '" + Email + "', '" + Password + "');";
                MySqlCommand command = new MySqlCommand(sql_zapros, connection);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex) {/* Console.WriteLine("Пользователь еще раз нажал /start");*/ }
            return false;
        }
    }
}
