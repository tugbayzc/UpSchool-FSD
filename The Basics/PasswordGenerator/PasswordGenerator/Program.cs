namespace PasswordGenerator;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Password Generator!");

        Console.WriteLine("How long would you like your password to be?");
        int length = int.Parse(Console.ReadLine());

        Console.WriteLine("Would you like to use capital characters in your password? (Y/N)");
        bool useUpperCase = Console.ReadLine().ToLower() == "y";

        Console.WriteLine("Would you like to use lowercase characters in your password? (Y/N)");
        bool useLowerCase = Console.ReadLine().ToLower() == "y";

        Console.WriteLine("Would you like to use special characters in your password? (Y/N)");
        bool useSpecialChars = Console.ReadLine().ToLower() == "y";

        Console.WriteLine("Would you like to use numbers in your password? (Y/N)");
        bool useNumbers = Console.ReadLine().ToLower() == "y";

        PasswordGenerator passwordGenerator = new PasswordGenerator(length, useUpperCase, useLowerCase, useSpecialChars, useNumbers);

        if (!useSpecialChars && !useLowerCase && !useNumbers && !useUpperCase)
            Console.WriteLine("Your password could not be created because you did not make any selections.Please try again!");
        
        Console.WriteLine("Şifreniz: " + passwordGenerator.GeneratePassword());
        
        Console.ReadLine();
    }
}


        
    


