using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMAUI
{
    internal class User
    {
        public string FullName { get; set; }
        public string ProfileColor { get; set; }
        public string ProfileTextColor { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string path = Environment.ExpandEnvironmentVariables(@"%APPDATA%\Messenger");
        public string file = "\\saveUserData.txt";
        public void saveData()
        {   
            using (StreamWriter writer = new StreamWriter(path + file, false))
            {
                writer.WriteLine(FullName);
                writer.WriteLine(ProfileColor);
                writer.WriteLine(ProfileTextColor);
                writer.WriteLine(Login);
                writer.WriteLine(Password);
            }
        }
        
        public void loadData()
        {
            using (StreamReader reader = new StreamReader(path + file))
            {
                FullName = reader.ReadLine();
                ProfileColor = reader.ReadLine();
                ProfileTextColor = reader.ReadLine();
                Login = reader.ReadLine();
                Password = reader.ReadLine();
            }
        }
    }

}
