using System.Collections.Generic;
using TestSuite.Interfaces;
using TestSuite.Model;

namespace TestSuite.Translations
{
    public class MainPageTranslations : ITranslationRepository
    {
        public List<TranslationModel> Translations
        {
            get
            {
                List<TranslationModel> translations = new List<TranslationModel>();
                translations.Add(new TranslationModel { TranslationKey = " UniversityLogoText", PolishText = "Akademia WSB", EnglishText = "WSB University" });
                translations.Add(new TranslationModel { TranslationKey = "Student", PolishText = "Student", EnglishText = "Student" });
                translations.Add(new TranslationModel { TranslationKey = "Admissions", PolishText = "Kandydat", EnglishText = "Admissions" });
                translations.Add(new TranslationModel { TranslationKey = "Research", PolishText = "Nauka i Badania", EnglishText = "Research" });
                translations.Add(new TranslationModel { TranslationKey = "University", PolishText = "Uczelnia", EnglishText = "Research" });

                return translations;
            }
        }
    }
}
