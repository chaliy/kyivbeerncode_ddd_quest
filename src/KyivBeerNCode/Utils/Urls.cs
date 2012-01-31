using System.Text.RegularExpressions;

namespace KyivBeerNCode.Utils
{
    public static class Urls
    {
        public static string MakeToken(string raw)
        {
            raw = raw.Trim();
            raw = Regex.Replace(raw, "[^\\w-]", " ");
            return Regex.Replace(raw, "[\\W]+", "-").Trim('-');
        }
    }

}
