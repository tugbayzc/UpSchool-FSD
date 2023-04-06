using System.Runtime.Intrinsics.X86;

namespace Domain.Extensions;

public static class StringExtension
{
    public static bool IsContainsChar(this string text, int minCount)
    {
        var results= text.Select(x => char.IsLetter(x));

        if (results.Count(x=> x == true)== minCount) //bize gelen text içerisinde en az bir char var==true!
        {
            return true;
        }
       
        return false; 
    }
}