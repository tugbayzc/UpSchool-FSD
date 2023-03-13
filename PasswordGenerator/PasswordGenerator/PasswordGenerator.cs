namespace PasswordGenerator;

class PasswordGenerator
{
    private readonly int length;
    private readonly bool useUpperCase;
    private readonly bool useLowerCase;
    private readonly bool useSpecialChars;
    private readonly bool useNumbers;
    
    private const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
    private const string specialChars = "!@#$%^&*()_+-=";
    private const string numbers = "0123456789";
    
    public PasswordGenerator(int length, bool useUpperCase, bool useLowerCase, bool useSpecialChars, bool useNumbers)
    {
        this.length = length;
        this.useUpperCase = useUpperCase;
        this.useLowerCase = useLowerCase;
        this.useSpecialChars = useSpecialChars;
        this.useNumbers = useNumbers;
    }

    public string GeneratePassword()
    {
        string allowedChars = "";
        
        if (useUpperCase) allowedChars += upperChars;
        if (useLowerCase) allowedChars += lowerChars;
        if (useSpecialChars) allowedChars += specialChars;
        if (useNumbers) allowedChars += numbers;
        

        Random random = new Random();
        string password = new string(Enumerable.Repeat(allowedChars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());

        return password;
    }
}