using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerMAUI.Objects
{
    internal class User //TODO: Пределать систему передачи пользователя между контентом
    {
        public string FullName { get; set; }
        public string ProfileColor { get; set; }
        public string ProfileTextColor { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string path = Environment.ExpandEnvironmentVariables(@"%APPDATA%\Messenger");
        public string file = "saveUserData.txt";
        public void saveData()
        {
            //Directory.CreateDirectory("C:\\Users\\Admin\\AppData\\Roaming\\Messenger");
            //Pass the filepath and filename to the StreamWriter Constructor
            StreamWriter sw = new StreamWriter("C:\\Users\\mario\\AppData\\Roaming\\Messenger\\saveUserData.txt");
            //Write a line of text

            sw.WriteLine(FullName);
            sw.WriteLine(ProfileColor);
            sw.WriteLine(ProfileTextColor);
            sw.WriteLine(Login);
            sw.WriteLine(Password);
            //Write a second line of text

            //Close the file
            sw.Close();
            //using (StreamWriter writer = new StreamWriter(path, false))
            //{
            //    writer.WriteLine(FullName);
            //    writer.WriteLine(ProfileColor);
            //    writer.WriteLine(ProfileTextColor);
            //    writer.WriteLine(Login);
            //    writer.WriteLine(Password);
            //}
        }

        public string line;
        public void loadData()
        {
            //Directory.CreateDirectory("C:\\Users\\Admin\\AppData\\Roaming\\Messenger");
            StreamReader sr = new StreamReader("C:\\Users\\mario\\AppData\\Roaming\\Messenger\\saveUserData.txt");
            //Read the first line of text
            //line = sr.ReadLine();
            FullName = sr.ReadLine();
            ProfileColor = sr.ReadLine();
            ProfileTextColor = sr.ReadLine();
            Login = sr.ReadLine();
            Password = sr.ReadLine();
            //close the file
            sr.Close();
            //Console.ReadLine();

            //using (StreamReader reader = new StreamReader(path))
            //{
            //    FullName = reader.ReadLine();
            //    ProfileColor = reader.ReadLine();
            //    ProfileTextColor = reader.ReadLine();
            //    Login = reader.ReadLine();
            //    Password = reader.ReadLine();
            //}
        }
    }

}
