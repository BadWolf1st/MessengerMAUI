namespace MessengerMAUI.Objects
{
    public class User //TODO: Пределать систему передачи пользователя между контентом
    {
        public string FullName { get; set; }
        public string ProfileColor { get; set; }
        public string ProfileTextColor { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool userIsAdmin { get; set; }
    }

}
