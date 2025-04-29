using System.Globalization;

namespace SchoolManagment.Data.Commons
{
    public class GeneralLocalizableEntity
    {
        public string GetLocalized(string textAr, string textEN)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEN;
        }
    }
}
