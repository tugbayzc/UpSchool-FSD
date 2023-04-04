using System.Runtime.Intrinsics.X86;

namespace Domain.Extensions;

public static class StringExtension
{
    public static bool IsContainsChar(this string text)
    {
        var results= text.Select(x => char.IsLetter(x));

        if (results.Any(x=>x==true))
        {
            return true;
        }
       
        return false;
    }
}