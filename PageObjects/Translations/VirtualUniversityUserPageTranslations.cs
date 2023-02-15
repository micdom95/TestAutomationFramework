using System.Collections.Generic;
using TestSuite.Interfaces;
using TestSuite.Model;

namespace TestSuite.Translations
{
    public class VirtualUniversityUserPageTranslations : ITranslationRepository
    {
        public List<TranslationModel> Translations
        {
            get
            {
                List<TranslationModel> translations = new List<TranslationModel>();
                translations.Add(new TranslationModel { TranslationKey = "AccouncementsTitleLabel", PolishText = "WIADOMOŚCI", EnglishText = "MESSAGES" });
                translations.Add(new TranslationModel { TranslationKey = "ClearFilterButton", PolishText = "Wyczyść", EnglishText = "Clear" });
                translations.Add(new TranslationModel { TranslationKey = "FilterButton", PolishText = "Filtruj", EnglishText = "Filter" });
                
                return translations;
            }
        }
    }
}
