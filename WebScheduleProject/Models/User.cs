namespace WebWTF.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public User(string email, string password, string username)
        {
            Email = email;
            Password = password;
            Username = username;
        }
          
        

    }
}
