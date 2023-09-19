using System;
public partial class Program{  
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public string GetInitials()
        {
            return $"{FirstName} {LastName} -> {FirstName[0]}. {LastName[0]}.";
        }
    }

    public static void Main()
    {
        User user = new User("Anastasia", "Zagorodniuc");
        string initials = user.GetInitials();
        Console.WriteLine(initials);
    }
}
