using ADO_NET.Models;

using System.Data.SqlClient;
namespace ADO_NET.DataBase;

public static class DB
{
    public static List<User> users { get; set; } = new List<User>();
    private static SqlConnection connection = null;
    private static SqlCommand command = null;
    private static SqlDataReader reader = null;
    private static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=USERS;Integrated Security=SSPI;";
    public static void WriteUsersToDb()
    {
        using (connection = new(connectionString))
        {
            connection.Open();
            foreach (var user in users)
            {
                command = new SqlCommand($@"INSERT INTO [User](Name,Surname,Age,Login,Password)
                                            VALUES('{user.Name}','{user.Surname}','{user.Age}','{user.Login}','{user.Password}')", connection);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void ReadUsersToDb()
    {
        using (connection = new(connectionString))
        {
            connection.Open();
            command = new($@"SELECT * FROM [User]", connection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                User user = new User();
                user.Name = reader["Name"].ToString();
                user.Surname = reader["Surname"].ToString();
                user.Age = int.Parse(reader["Age"].ToString());
                user.Login = reader["Login"].ToString();
                user.Password = reader["Password"].ToString();


                users.Add(user);
            }

        }
    }


    public static bool CheckPassword(string password, string cPassword)
    {
        if (password == cPassword)
        {
            return true;
        }
        return false;
    }

    public static bool CheckLogin(string login, string password)
    {
        if (login != null && password != null)
        {
            foreach (var user in users)
            {
                if (login == user.Login && password == user.Password)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool CheckUserName(string login)
    {
        foreach (var user in users)
        {
            if (user.Login == login)
            {
                return false;
            }
        }
        return true;
    }

}
